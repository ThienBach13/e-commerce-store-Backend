using EcomShop.Api.src.Persistence;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.RepoAbstract;
using Microsoft.EntityFrameworkCore;

namespace EcomShop.Api.Database
{
    public class AddressRepository : IAddressRepo
    {
        private readonly EcomShopDbContext _dbContext;

        public AddressRepository(EcomShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Address>> GetAllAddressesByUserIdAsync(int customerId)
        {
            var customerAddresses = await _dbContext.Addresses
                .Where(address => address.UserId == customerId)
                .ToListAsync();
            return customerAddresses;
        }
        public async Task<Address> GetAddressByIdAsync(int addressId)
        {
            return await _dbContext.Addresses.FindAsync(addressId);
        }

        public async Task<Address> CreateAddressAsync(Address address)
        {
            _dbContext.Addresses.Add(address);
            await _dbContext.SaveChangesAsync();

            return address;
        }

        public async Task<bool> UpdateAddressByIdAsync(Address address)
        {
            var existingAddress = await _dbContext.Addresses.FindAsync(address.Id);
            if (existingAddress == null)
                return false;

            existingAddress.StreetName = address.StreetName;
            existingAddress.StreetNumber = address.StreetNumber;
            existingAddress.UnitNumber = address.UnitNumber;
            existingAddress.PostalCode = address.PostalCode;
            existingAddress.City = address.City;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAddressByIdAsync(int addressId)
        {
            var address = await _dbContext.Addresses.FindAsync(addressId);

            if (address is null)
            {
                return false;
            }

            _dbContext.Addresses.Remove(address);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}