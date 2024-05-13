using Microsoft.AspNetCore.Mvc;
using EcomShop.Application.src.DTO;
using EcomShop.Application.src.ServiceAbstract;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace EcomShop.Controllers.src
{
    [ApiController]
    [Route("api/v1/addresses")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<AddressReadDto>> GetAllAddressesByUserIdAsync()
        {
            string customerId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value; ;
            int idValue = int.Parse(customerId);
            var addresses = await _addressService.GetAllAddressesByUserIdAsync(idValue);
            return addresses;
        }

        [HttpGet("{addressId:int}")]
        public async Task<AddressReadDto> GetAddressByIdAsync([FromRoute] int addressId)
        {
            var address = await _addressService.GetAddressByIdAsync(addressId);

            return address;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<AddressReadDto>> CreateAddressAsync([FromBody] AddressCreateDto addressDto)
        {
            if (addressDto == null)
            {
                return BadRequest("Invalid request body");
            }
            string customerId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value; ;
            int idValue = int.Parse(customerId);
            var createdAddress = await _addressService.CreateAddressAsync(addressDto, idValue);
            if (createdAddress == null)
            {
                return StatusCode(500, "Failed to create address");
            }

            return createdAddress;
        }

        [Authorize]
        [HttpPut("{addressId:int}")]
        public async Task<ActionResult<AddressReadDto>> UpdateAddressByIdAsync([FromRoute] int addressId, [FromBody] AddressUpdateDto updateDto)
        {
            if (updateDto == null)
            {
                return BadRequest("Invalid request body");
            }

            // updateDto.Id = addressId;

            var updatedAddress = await _addressService.UpdateAddressByIdAsync(updateDto, addressId);

            return Ok(updatedAddress);
        }

        [Authorize]
        [HttpDelete("{addressId:int}")]
        public async Task<IActionResult> DeleteAddress([FromRoute] int addressId)
        {
            var result = await _addressService.DeleteAddressByIdAsync(addressId);

            if (!result)
            {
                return NotFound($"Address with ID {addressId} not found");
            }

            return NoContent();
        }
    }
}
