using EcomShop.Application.src.DTO;

namespace EcomShop.Application.src.ServiceAbstract
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressReadDto>> GetAllAddressesByUserIdAsync(int customerId);
        Task<AddressReadDto> GetAddressByIdAsync(int addressId);
        Task<AddressReadDto> CreateAddressAsync(AddressCreateDto addressDto, int userId);
        Task<bool> UpdateAddressByIdAsync(AddressUpdateDto address , int addressId);
        Task<bool> DeleteAddressByIdAsync(int addressId);
    }
}