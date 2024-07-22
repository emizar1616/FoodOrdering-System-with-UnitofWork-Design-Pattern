using AutoMapper;
using Istka_Group4_FoodOrdering_Entity.Entities;
using Istka_Group4_FoodOrdering_Entity.Services;
using Istka_Group4_FoodOrdering_Entity.UnitOfWorks;
using Istka_Group4_FoodOrdering_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istka_Group4_FoodOrdering_Service.Services
{
    public class ProductSaleDetailService : IProductSaleDetailService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ProductSaleDetailService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Add(ProductSaleDetailViewModel model)
        {
            ProductSaleDetail pSaleDetail = new ProductSaleDetail();
            pSaleDetail = _mapper.Map<ProductSaleDetail>(model);
            await _uow.GetRepository<ProductSaleDetail>().Add(pSaleDetail);
            await _uow.CommitAsync();
        }
        public async Task<List<ProductSaleDetailViewModel>> GetAll()
        {
            var list = await _uow.GetRepository<ProductSaleDetail>().GetAllAsync();
            return _mapper.Map<List<ProductSaleDetailViewModel>>(list);
        }
        public async Task<List<ProductSaleDetailViewModel>> GetByProductSaleId(int id)
        {
            var list = await _uow.GetRepository<ProductSaleDetail>().GetAll(c => c.ProductSaleId == id);
            return _mapper.Map<List<ProductSaleDetailViewModel>>(list);
        }
        public bool AddRange(List<SepetDetay> sepet, int productSaleId)
        {
            foreach (var item in sepet)
            {
                ProductSaleDetail newDetail = new ProductSaleDetail()
                {
                    ProductSaleId = productSaleId,
                    ProductId = item.ProductId,
                    Number = item.ProductQuantity,
                    UnitPrice = item.ProductPrice,
                };
                _uow.GetRepository<ProductSaleDetail>().AddNormal(newDetail);
            }
                try
                {
                    _uow.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
                return false;
            }
        



            //public async Task AddRange(List<SepetDetay> sepet, int productSaleId)
            //{
            //    // Transaction'ı dışarıda başlat
            //    using (var transaction = await _uow.BeginTransactionAsync())
            //    {
            //        try
            //        {
            //            // Her bir ürün detayı için
            //            foreach (var item in sepet)
            //            {
            //                ProductSaleDetail newDetail = new ProductSaleDetail()
            //                {
            //                    ProductSaleId = productSaleId,
            //                    ProductId = item.ProductId,
            //                    Number = item.ProductQuantity,
            //                    UnitPrice = item.ProductPrice,
            //                };

            //                // Ürün detayını ekle
            //                await _uow.GetRepository<ProductSaleDetail>().Add(newDetail);
            //            }

            //            // Değişiklikleri kaydet
            //            await _uow.CommitAsync();
            //            await transaction.CommitAsync();
            //        }
            //        catch (Exception ex)
            //        {
            //            // Hata durumunda işlemi geri al
            //            await transaction.RollbackAsync();
            //            // Hataları loglayarak detaylı bilgi almak için:
            //            Console.WriteLine($"Error adding sale details: {ex.Message}");
            //            throw; // Hata fırlat, çağıran kod bilgilendirilsin
            //        }
            //    }
           //}
    }
}
