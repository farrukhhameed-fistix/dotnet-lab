using Sports.Domain.TestAggregate;
using Sports.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sports.Persistence;

namespace Sports.Peristence
{
    public class TestRepository : ITestRepository
    {
        SportsTestContext _sportsTestContext = null;

        public IUnitOfWork UnitOfWork => _sportsTestContext;

        public TestRepository(SportsTestContext sportsTestContext)
        {
            _sportsTestContext = sportsTestContext;
        }
        public void Create(Test test)
        {
            _sportsTestContext.Tests.Add(test);
        }

        public void Update(Test test)
        {
            _sportsTestContext.Entry<Test>(test).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public Task<Test> GetAsync(Guid id)
        {
            return _sportsTestContext.Tests.FindAsync(id);
        }
    }
}
