using MediatR;
using Project.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Functions.Command
{
    public class ChangeDebitStatusCommandHandler : IRequestHandler<ChangeAccountStatusCommand, ServiceResponse<string>>
    {
        public Task<ServiceResponse<string>> Handle(ChangeAccountStatusCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
