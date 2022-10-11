using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Abstractions.Storage;
using ECommerce.Application.Repositories.IProductImageFileRepositories;
using ECommerce.Application.Repositories.IProductRepositories;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Features.Commands.ProductImageFileCommands.UploadProductImage
{
    public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommandRequest, UploadProductImageCommandResponse>
    {
        private readonly IStorageService _storageService;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductImageFileWriteRepository _productImageFileWriteRepository;

        public UploadProductImageCommandHandler(IStorageService storage, IProductReadRepository productReadRepository, IProductImageFileWriteRepository productImageFileWriteRepository)
        {
            _storageService = storage;
            _productReadRepository = productReadRepository;
            _productImageFileWriteRepository = productImageFileWriteRepository;
        }

        public async Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _productReadRepository.GetByIdAsync(request.Id, true);
            List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", request.Files);
            _productImageFileWriteRepository.AddRange(result.Select(r => new ProductImageFile()
            {
                FileName = r.fileName,
                Path = r.pathOrContainerName,
                Storage = _storageService.StorageName,
                Products = new List<Domain.Entities.Product>() { product }
            }).ToList());

            await _productImageFileWriteRepository.SaveAsync();
            return new();
        }
    }
}
