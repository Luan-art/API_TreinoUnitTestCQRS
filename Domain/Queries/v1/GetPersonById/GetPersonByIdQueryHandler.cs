using AutoMapper;
using Domain.Contracts.v1;
using Domain.Entities.v1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Queries.v1.GetPersonById
{
    public class GetPersonByIdQueryHandler(
    IMapper mapper,
    IPersonRepository repository
    ) : IRequestHandler<GetPersonByIdQuery, GetPersonByIdQueryResponse>
    {
        public async Task<GetPersonByIdQueryResponse> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {

            Expression<Func<Person, bool>> predicate = x => x.Id == request.Id;

            var customer = await repository.GetSingleOrDefaultAsync(predicate, cancellationToken);

            return mapper.Map<GetPersonByIdQueryResponse>(customer);
        }
    }
}
