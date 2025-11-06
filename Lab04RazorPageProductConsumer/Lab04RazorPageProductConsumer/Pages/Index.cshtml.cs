using Lab04RazorPageProductConsumer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab04RazorPageProductConsumer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        public IEnumerable<Product>?  Products = new List<Product>();

        public IndexModel(ILogger<IndexModel> logger,IHttpClientFactory httpFactory)
        {
            _logger = logger;
            _httpClientFactory=httpFactory;
        }

        public async Task OnGet()
        {
           HttpClient httpClient= _httpClientFactory.CreateClient("remoteApiFactory");
           HttpResponseMessage response  = await httpClient.GetAsync("api/v1/products");
            if (response.IsSuccessStatusCode)
            {

                Stream? contentStream =  await response.Content.ReadAsStreamAsync();
                JsonSerializerOptions? options = new JsonSerializerOptions { 
                    PropertyNameCaseInsensitive = true,
                };
               
               Products = await JsonSerializer.DeserializeAsync<IEnumerable<Product>>(contentStream, options);
                
            }
        }
    }
}
