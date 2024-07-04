using Domain.Contracts.v1;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Person.v1
{
    public class PersonRepository(IMongoClient client) : BaseDbRepository<Domain.Entities.v1.Person, Guid>(client), IPersonRepository;

}
