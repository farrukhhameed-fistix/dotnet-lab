using AutoMapper;
using MediatR;
using Sports.Domain.TestAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sports.Command
{
    public class CreateTestCommandHandler : IRequestHandler<CreateTestCommand, bool>
    {
        private readonly IMapper _mapper = null;
        private readonly ITestRepository _testRepository = null;
        public CreateTestCommandHandler(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateTestCommand command, CancellationToken cancellationToken)
        {
           
            Test test = _mapper.Map<CreateTestCommand, Test>(command);

            _testRepository.Create(test);

            var noOfRecordsAffected = await _testRepository.UnitOfWork.SaveChangesAsync();

            if (noOfRecordsAffected > 0) return true;

            return false;
        }
    }
}
