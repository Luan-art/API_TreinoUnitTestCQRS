using AutoMapper;
using Domain.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Queries.v1.GetPersonById
{
    public class GetPersonByIdQueryProfile : Profile
    {
        public GetPersonByIdQueryProfile()
        {
            CreateMap<Person, GetPersonByIdQueryResponse>();
        }
    }
}
