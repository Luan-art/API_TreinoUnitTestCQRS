using Domain.Commands.v1.CreatePerson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Mocks.Commands.v1
{
    public class CreatePersonCommandMock
    {
        public static CreatePersonCommand GetSuccessMock() =>
       new() { Name = "Leonardo", CPF = "456.073.28-02", Birthday = new DateTime(1995, 5, 5), Phone = "988396290", Email = "teste@gmail.com", Address = new Domain.ValueObjects.v1.Address("123123", "Rua X", "123", string.Empty, "Araraquara", "SP") };

        public static CreatePersonCommand GetNameFailMock() =>
       new() { Name = null, CPF = "456.073.28-02", Birthday = new DateTime(1995, 5, 5), Phone = "988396290", Email = "teste@gmail.com", Address = new Domain.ValueObjects.v1.Address("123123", "Rua X", "123", string.Empty, "Araraquara", "SP") };

        //public static CreateCustomerCommand GetBirthDayInvalidMock() =>
        //    .RuleFor(fake => fake.Birthday)
    }
}
