using Domain.Contracts.v1;
using Domain.ValueObjects.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.v1
{
    public class Person : IEntity<Guid>
    {
        public Person()
        {
            Id = Guid.NewGuid();
        }

        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime Birthday { get; set; }
        public Address? Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Guid Id { get; set; }

    }
}