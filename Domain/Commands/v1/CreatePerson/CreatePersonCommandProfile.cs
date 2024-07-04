using AutoMapper;
using Domain.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.v1.CreatePerson
{
    public class CreatePersonCommandProfile : Profile
    {
        public CreatePersonCommandProfile()
        {
            CreateMap<CreatePersonCommand, Person>()
                .ForMember(fieldOutput => fieldOutput.CPF, option => option
                    .MapFrom(input => GetOnlyNumbers(input.CPF)));

            CreateMap<Person, CreatePersonCommandResponse>();
        }

        public static string GetOnlyNumbers(string text)
        {
            var stringNumber = new String((text ?? string.Empty).Where(Char.IsDigit).ToArray());
            return stringNumber;
        }
    }
}
