using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NotShopee.Client.Models;

namespace NotShopee.Client.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _accessor;

        public ProductsService(IHttpClientFactory clientFactory, IHttpContextAccessor accessor)
        {
            _clientFactory = clientFactory;
            _accessor = accessor;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/Products/");
            var client = _clientFactory.CreateClient("NotShopee");
            
            var userId = _accessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            client.DefaultRequestHeaders.Add("userId", userId);
            
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                IEnumerable<ProductViewModel> result = 
                    JsonConvert.DeserializeObject<List<ProductViewModel>>(responseJson);
                return result;
            }

            return new List<ProductViewModel>();
        }

        public async Task<ProductViewModel> Get(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/Products/{id}");
            var client = _clientFactory.CreateClient("NotShopee");
            var userId = _accessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            client.DefaultRequestHeaders.Add("userId", userId);
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                ProductViewModel result = 
                    JsonConvert.DeserializeObject<ProductViewModel>(responseJson);
                return result;
            }

            return null;
        }

        public async Task<ProductViewModel> Create(ProductViewModel product)
        {
            var userId = _accessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            product.UserId = userId;
            
            var jsonContent = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            var client = _clientFactory.CreateClient("NotShopee");
            var response = await client.PostAsync("/api/Products/", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                ProductViewModel result = 
                    JsonConvert.DeserializeObject<ProductViewModel>(responseJson);
                return result;
            }
            
            return new ProductViewModel();
        }

        public async Task Edit(ProductViewModel product)
        {
            var userId = _accessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            product.UserId = userId;
            var jsonContent = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            var client = _clientFactory.CreateClient("NotShopee");
            await client.PutAsync($"/api/Products/{product.Id}", jsonContent);
        }

        public async Task Delete(int id)
        {
            var client = _clientFactory.CreateClient("NotShopee");
            var userId = _accessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            client.DefaultRequestHeaders.Add("userId", userId);
            await client.DeleteAsync($"/api/Products/{id}");
        }
    }
}