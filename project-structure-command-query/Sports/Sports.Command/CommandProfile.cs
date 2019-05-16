using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sports.Command
{
    public class CommandProfile : Profile
    {
        public CommandProfile()
        {
            CreateMap<CreateTestCommand, Domain.TestAggregate.Test>()
                .ForMember(des => des.Type, m => m.MapFrom(x => x.Type == "CooperTest" ? Domain.TestAggregate.TestType.CooperTest : Domain.TestAggregate.TestType.None))
                .ForMember(des => des.Athletes, m => m.Ignore());
        }
    }
}
