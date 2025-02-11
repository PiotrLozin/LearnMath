using LearnMath.Application.Addresses;
using LearnMath.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Users.MappingProfiles
{
    public static class UserMappingProfile
    {
        public static AddressDto MapToAddressDto(this Address address)
        {
            AddressDto addressDto = new AddressDto(
                address.Street,
                address.City,
                address.Country,
                address.PostCode);

            return addressDto;
        }
    }
}
