using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Queries.v1.GetPersonById
{
    public class GetPersonByIdQuery(Guid Id) : IRequest<GetPersonByIdQueryResponse>
    {
        public Guid Id { get; set; } = Id;
    }
}
