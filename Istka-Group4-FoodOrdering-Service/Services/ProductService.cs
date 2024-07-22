using AutoMapper;
using Istka_Group4_FoodOrdering_Entity.Entities;
using Istka_Group4_FoodOrdering_Entity.Services;
using Istka_Group4_FoodOrdering_Entity.UnitOfWorks;
using Istka_Group4_FoodOrdering_Entity.ViewModels;

namespace Istka_Group4_FoodOrdering_Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Add(ProductViewModel model)
        {
            Product product = _mapper.Map<Product>(model);
            await _uow.GetRepository<Product>().Add(product);
            await _uow.CommitAsync();
        }

        public async Task Delete(ProductViewModel model)
        {
            Product product = await _uow.GetRepository<Product>().GetByIdAsync(model.Id);
            if (product != null)
            {
                _uow.GetRepository<Product>().Delete(product);
                await _uow.CommitAsync();
            }
        }

        public async Task<ProductViewModel> Get(int id)
        {
            var product = await _uow.GetRepository<Product>().GetByIdAsync(id);
            return _mapper.Map<ProductViewModel>(product);
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            var list = await _uow.GetRepository<Product>().GetAllAsync();
            return _mapper.Map<List<ProductViewModel>>(list);
        }

        public async Task Update(ProductViewModel model)
        {
            Product product = _mapper.Map<Product>(model);
            _uow.GetRepository<Product>().Update(product);
            await _uow.CommitAsync();
        }

    }
}
