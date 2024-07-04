using AutoMapper;
using Domain.Contracts.v1;
using Domain.Entities.v1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.v1.CreatePerson
{
    public class CreatePersonCommandHandler(IPersonRepository repository, IMapper mapper, IDomainNotificationService domainNotification)
    : IRequestHandler<CreatePersonCommand, CreatePersonCommandResponse>
    {
        public async Task<CreatePersonCommandResponse> Handle(
            CreatePersonCommand request,
            CancellationToken cancellationToken)
        {
            var person = mapper.Map<CreatePersonCommand, Person>(request);
            await repository.AddAsync(person, cancellationToken);

            return mapper.Map<CreatePersonCommandResponse>(person);
        }
    }
}
