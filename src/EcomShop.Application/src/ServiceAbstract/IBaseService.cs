using EcomShop.Core.src.Common;

namespace EcomShop.Application.src.ServiceAbstract
{
    public interface IBaseService<TReadDTO, TCreateDTO, TUpdateDTO, TQueryOptions> where TQueryOptions : QueryOptions
    {
        Task<IEnumerable<TReadDTO>> GetAllAsync(TQueryOptions options);
        Task<TReadDTO> GetByIdAsync(Guid id);
        Task<TReadDTO> CreateAsync(TCreateDTO createDto);
        Task<TReadDTO> UpdateAsync(Guid id, TUpdateDTO updateDto);
        Task<bool> DeleteAsync(Guid id);
    }
}