using System.Collections.Generic;
using System.Threading.Tasks;
using NotShopee.Client.Models;

namespace NotShopee.Client.Services
{
    public interface IProductsService
    {
        public Task<IEnumerable<ProductViewModel>> GetAll();
        
        public Task<ProductViewModel> Get(int id);

        public Task<ProductViewModel> Create(ProductViewModel product);
        
        public Task<ProductViewModel> Edit(ProductViewModel product);
        
        public Task Delete(int id);
    }
}