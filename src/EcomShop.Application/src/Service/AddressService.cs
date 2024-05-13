using EcomShop.Application.src.DTO;
using EcomShop.Application.src.ServiceAbstract;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.RepoAbstract;

namespace EcomShop.Application.src.Service
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepo _addressRepo;

        public AddressService(IAddressRepo addressRepo)
        {
            _addressRepo = addressRepo;
        }

        public async Task<IEnumerable<AddressReadDto>> GetAllAddressesByUserIdAsync(int customerId)
        {
            var addresses = await _addressRepo.GetAllAddressesByUserIdAsync(customerId);
            return AddressReadDto.ConvertList(addresses);
        }

        public async Task<AddressReadDto> GetAddressByIdAsync(int addressId)
        {
            var address = await _addressRepo.GetAddressByIdAsync(addressId);
            var addressReadDto = new AddressReadDto();
            addressReadDto.Transform(address);
            return addressReadDto;
        }


        public async Task<AddressReadDto> CreateAddressAsync(AddressCreateDto addressDto, int userId)
        {
            var address = addressDto.CreateAddress(new Address());
            address.UserId = userId;
            var createdAddress = await _addressRepo.CreateAddressAsync(address);
            var addressReadDto = new AddressReadDto();
            addressReadDto.Transform(createdAddress);
            return addressReadDto;
        }

        public async Task<bool> UpdateAddressByIdAsync(AddressUpdateDto addressDto , int addressId)
        {
            var existingAddress = await _addressRepo.GetAddressByIdAsync(addressId);
            if (existingAddress == null)
                return false;

            existingAddress = addressDto.UpdateAddress(existingAddress);
            return await _addressRepo.UpdateAddressByIdAsync(existingAddress);
        }

        public async Task<bool> DeleteAddressByIdAsync(int addressId)
        {
            return await _addressRepo.DeleteAddressByIdAsync(addressId);
        }
    }
}