using Sports.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sports.Domain.TestAggregate
{
    public interface ITestRepository
    {
        IUnitOfWork UnitOfWork { get; }
        void Create(Test test);
        void Update(Test test);
        Task<Test> GetAsync(Guid id);
    }
}
