using Domain.ValueObjects.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Queries.v1.GetPersonById
{
    public class GetPersonByIdQueryResponse
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime Birthday { get; set; }
        public Address? Address { get; set; }
        public Guid Id { get; set; }
    }
}
