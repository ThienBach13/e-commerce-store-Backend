using EcomShop.Application.src.ServiceAbstract;
using EcomShop.Core.src.Common;
using EcomShop.Core.src.RepoAbstract;
using AutoMapper;

namespace EcomShop.Application.src.Service
{
    public class BaseService<TEntity, TReadDTO, TCreateDTO, TUpdateDTO, TQueryOptions> : IBaseService<TReadDTO, TCreateDTO, TUpdateDTO, TQueryOptions>
    where TEntity : class
    where TQueryOptions : QueryOptions
    {
        protected readonly IBaseRepository<TEntity, TQueryOptions> _repository;
        protected readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity, TQueryOptions> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public virtual async Task<TReadDTO> CreateAsync(TCreateDTO createDto)
        {
            var entity = _mapper.Map<TEntity>(createDto);
            entity = await _repository.AddAsync(entity);
            return _mapper.Map<TReadDTO>(entity);
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public virtual async Task<IEnumerable<TReadDTO>> GetAllAsync(TQueryOptions options)
        {
            var entities = await _repository.GetListAsync(options);
            return _mapper.Map<IEnumerable<TReadDTO>>(entities);
        }

        public virtual async Task<TReadDTO> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Entity not found");
            return _mapper.Map<TReadDTO>(entity);
        }

        public virtual async Task<TReadDTO> UpdateAsync(Guid id, TUpdateDTO updateDto)
        {
            var entity = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Entity not found for update");

            _mapper.Map(updateDto, entity);
            Console.WriteLine($"Entity before update: {entity}");

            foreach (var property in updateDto!.GetType().GetProperties())
            {
                var propertyName = property.Name;

                var propertyValue = property.GetValue(updateDto);

                // Find the corresponding property on the entity object
                var entityProperty = entity.GetType().GetProperty(propertyName);

                // Check if the entity property exists and is writable
                if (entityProperty != null && entityProperty.CanWrite)
                {
                    // Set the value of the entity property
                    entityProperty.SetValue(entity, propertyValue);

                }
            }

            Console.WriteLine($"Entity after update: {entity}");

            entity = await _repository.UpdateAsync(entity);
            return _mapper.Map<TReadDTO>(entity);
        }
    }
}