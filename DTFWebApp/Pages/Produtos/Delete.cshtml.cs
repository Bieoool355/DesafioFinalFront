using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DTFWebApp.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace DTFWebApp.Pages.Produtos
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Produto Produto { get; set; }
        string baseUrl = "https://localhost:44392/";
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Produtos/" + id);

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    Produto = JsonConvert.DeserializeObject<Produto>(result);
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (Produto.ID != id)
            {
                return BadRequest();
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.DeleteAsync("api/Produtos/" + id);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("./Index");
                }
                else
                {
                    return Page();
                }
            }
        }
    }
}
