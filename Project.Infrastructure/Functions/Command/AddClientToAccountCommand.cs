﻿using MediatR;
using Project.Infrastructure.Models;
using Project.Infrastructure.Models.Client;

namespace Project.Infrastructure.Functions.Command
{
    public class AddClientToAccountCommand : IRequest<ServiceResponse<bool>>
    {
        public int clientId { get; set; }
        public int accountId { get; set; }
    }
}
