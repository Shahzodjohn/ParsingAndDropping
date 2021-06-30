using Microsoft.AspNetCore.Mvc;
using ParsingAndDropping.Context;
using ParsingAndDropping.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ParsingAndDropping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly AppDbContext _context;
        static object locker = new object();
        public ValuesController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("NEVAZHNO")]
        public async Task Index()
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Cookie", "_ga=GA1.2.221135562.1624701188; _gid=GA1.2.1385425427.1624701188; e572d25e2f77b01121404f0eef127450=9bc049bdb4429808830937c27178a858; _gat_gtag_UA_132313057_1=1; XSRF-TOKEN=eyJpdiI6ImwrdWxNY2RPenRSWFwvMDQ1dEdlbk9RPT0iLCJ2YWx1ZSI6InJlNG5Db3BWWDlHZStBQVQ3N0lBc2dFZFU3dU1tVGkranJoc0ZyQXVuWFRqMkhVUUwwQXI3TTBOeG93SVplS0UiLCJtYWMiOiJlYjYyZDQyZjFlMTRhMmQ0NWUxZGRmZjczNDQ4YTRjNWNlOTcwZjBmNjRiN2QxZjJjNTM4N2ZmNTcwYTc5MWZiIn0%3D; laravel_session=eyJpdiI6InA5K1VNTDVJb3lrT3BmMThSbExkbFE9PSIsInZhbHVlIjoiUHM0QmliRFwvVmcwZkFaKytZcm9aVkZCRms1SThibHNsb3JpTnIzTjIxdTdZNWlcLzNVRVVOTHZcL0JcLzhyb2xJMEciLCJtYWMiOiIxOWE0ZjYzYTViNDQxM2Y3NGM3YTAxZTFmZjRmM2ZiZWU5MzFkOGQ4NDRkNTVmNTk1ZDM1YzczYmZiMWI1MmQ2In0%3D"
            );
            var content = client.GetAsync("https://mojegs1.pl/moje-produkty/sortowanie/nazwa/kierunek/rosnaco/1?amountPerPage=154&searchText=pan").Result;
            var result = content.Content.ReadAsStringAsync().Result;
            HtmlAgilityPack.HtmlDocument web = new HtmlAgilityPack.HtmlDocument();
            //web.head
            web.LoadHtml(result);

            //var xpath = "//table[@class='table table-hover table-striped table-responsive']";
            var gting = new List<string>();
            var xpath = "//tr";
            
            foreach (var item in web.DocumentNode.SelectNodes(xpath).Skip(1))
            {
                Monitor.Enter(locker);
                Console.WriteLine($"...{item.InnerText.Trim().Split("\n")}...");
                //gting.Add(item.InnerText);
                var items = item.ChildNodes;

                _context.Droppings.Add(new Dropping
                {
                    DATA = items[7].InnerText.Trim(),
                    NAZWAPRODUKTU = items[1].InnerText.Trim(),
                    GTIN = items[3].InnerText.Trim(),
                    KLASYFIKACJAGPC = items[5].InnerText.Trim(),
                });
                
                Monitor.Exit(locker);
            };
            await _context.SaveChangesAsync();
        }
    }
}
