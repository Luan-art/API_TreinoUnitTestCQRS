using Domain.Commands.v1.CreatePerson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Mocks.Commands.v1
{
    public static class CreatePersonCommandResponseMock
    {
        public static CreatePersonCommandResponse GetSuccessMock() =>
            new() { Id = Guid.NewGuid(), Name = "Leonardo" };
    }
}
