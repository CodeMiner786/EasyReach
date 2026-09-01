using AutoMapper;
using EasyReach_Application.CQRS.Commands.Cataloges;
using EasyReach_Application.DTOs.Catalogs;
using EasyReach_Application.Interfaces;
using EasyReach_Application.IRedis;
using EasyReach_Domain.Entities.Catalogs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.CommandHandlers.Cataloges
{
    public class CreateCategoryCommandHandler(
        IGenericRepository<Category> categoryRepository,
        IMapper mapper,
        ICacheHelper cacheHelper) : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryEntity = mapper.Map<Category>(request.Dto);
            categoryEntity.Id = Guid.NewGuid();
            categoryEntity.CreatedAt = DateTime.UtcNow;

            await categoryRepository.AddAsync(categoryEntity);
            await categoryRepository.SaveChangesAsync();

            await cacheHelper.RemoveAsync("categories:all");

            return mapper.Map<CategoryDto>(categoryEntity);
        }
    }
}
