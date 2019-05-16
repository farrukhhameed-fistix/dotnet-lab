using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sports.Command
{
    public class CreateTestCommand : IRequest<bool>
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
    }

    public class CreateTestCommandValidator : AbstractValidator<CreateTestCommand>
    {
        public CreateTestCommandValidator()
        {
            RuleFor(x => x.Type).NotEmpty();
        }
    }
}
