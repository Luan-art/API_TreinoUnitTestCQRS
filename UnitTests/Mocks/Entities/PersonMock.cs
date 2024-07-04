using Domain.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Mocks.Entities
{
    public static class PersonMock
    {
        public static Person GetSuccessMock() =>
       new() { Name = "Leonardo", CPF = "456.073.28-02", Birthday = new DateTime(1995, 5, 5), Phone = "988396290", Email = "teste@gmail.com", Address = new Domain.ValueObjects.v1.Address("123123", "Rua X", "123", string.Empty, "Araraquara", "SP") };
    }
}
