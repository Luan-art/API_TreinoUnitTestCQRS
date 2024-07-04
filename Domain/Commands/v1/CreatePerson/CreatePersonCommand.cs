using Domain.ValueObjects.v1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.v1.CreatePerson
{
    public class CreatePersonCommand : IRequest<CreatePersonCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public Address? Address { get; set; }
    }
}
