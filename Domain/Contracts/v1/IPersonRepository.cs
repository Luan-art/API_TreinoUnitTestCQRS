using Domain.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.v1
{
    public interface IPersonRepository : IRepository<Person, Guid>
    {
    }
}
