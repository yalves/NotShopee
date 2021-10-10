using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NotShopee.Client.Models;

namespace NotShopee.Client.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductsService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            var client = _clientFactory.CreateClient("NotShopee");
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/Products");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                IEnumerable<ProductViewModel> models = 
                    JsonConvert.DeserializeObject<List<ProductViewModel>>(responseStream);
                return models;
            }

            return new List<ProductViewModel>();
        }

        public Task<ProductViewModel> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProductViewModel> Create(ProductViewModel product)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProductViewModel> Edit(ProductViewModel product)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}