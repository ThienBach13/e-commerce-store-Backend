using EcomShop.Core.src.Entity;

namespace EcomShop.Core.src.RepoAbstract
{
    public interface IAddressRepo
    {
        Task<IEnumerable<Address>> GetAllAddressesByUserIdAsync(int customerId);
        Task<Address> GetAddressByIdAsync(int addressId);
        Task<Address> CreateAddressAsync(Address address);
        Task<bool> UpdateAddressByIdAsync(Address address);
        Task<bool> DeleteAddressByIdAsync(int addressId);
    }
}