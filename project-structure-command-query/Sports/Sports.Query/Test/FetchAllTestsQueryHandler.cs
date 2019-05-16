using AutoMapper;
using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Sports.Query.Test
{
  public class FetchAllTestsQueryHandler : IRequestHandler<FetchAllTestsQuery, IEnumerable<TestViewModel>>
  {   
    private readonly IConfiguration _configuration = null;
    public FetchAllTestsQueryHandler(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    public async Task<IEnumerable<TestViewModel>> Handle(FetchAllTestsQuery query, CancellationToken cancellationToken)
    {
      IEnumerable<TestViewModel> items = null;
      using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
      {
        items = await connection.QueryAsync<TestViewModel>(@"select 
              case when Type = 1 THEN 'CooperTest' else '' end as Type , 
              Date, 
              Count(AthleteTests.Id) as NumberOfParticipants 
            from Tests left outer join AthleteTests on Tests.Id =  AthleteTests.TestId 
            group by Tests.Id, Tests.Type, Tests.Date");
      }

      return items;
    }
  }
}
