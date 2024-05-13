using EcomShop.Core.src.Entity;

namespace EcomShop.Application.src.DTO
{
    public class AddressCreateDto
    {
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string UnitNumber { get; set; }
        // public string AddressLine1 { get; set; }
        // public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public Address CreateAddress(Address address)
        {
            return new Address
            {
                StreetName = StreetName,
                StreetNumber = StreetNumber,
                UnitNumber = UnitNumber,
                // AddressLine1 = AddressLine1,
                // AddressLine2 = AddressLine2,
                PostalCode = PostalCode,
                City = City
            };
        }
    }

    public class AddressReadDto
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string UnitNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public void Transform(Address address)
        {
            Id = address.Id;
            StreetName = address.StreetName;
            StreetNumber = address.StreetNumber;
            UnitNumber = address.UnitNumber;
            // AddressLine1 = address.AddressLine1;
            // AddressLine2 = address.AddressLine2;
            PostalCode = address.PostalCode;
            City = address.City;
        }

        public static IEnumerable<AddressReadDto> ConvertList(IEnumerable<Address> addresses)
        {
            var addressReadDtos = new List<AddressReadDto>();

            foreach (var address in addresses)
            {
                var addressReadDto = new AddressReadDto();
                addressReadDto.Transform(address);
                addressReadDtos.Add(addressReadDto);
            }

            return addressReadDtos;
        }
    }

    public class AddressUpdateDto
    {
        // public int Id { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string UnitNumber { get; set; }
        // public string AddressLine1 { get; set; }
        // public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public Address UpdateAddress(Address oldAddress)
        {
            oldAddress.StreetName = StreetName;
            oldAddress.StreetNumber = StreetNumber;
            oldAddress.UnitNumber = UnitNumber;
            // oldAddress.AddressLine1 = AddressLine1;
            // oldAddress.AddressLine2 = AddressLine2;
            oldAddress.PostalCode = PostalCode;
            oldAddress.City = City;
            return oldAddress;
        }
    }
}
