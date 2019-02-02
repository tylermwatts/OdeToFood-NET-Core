using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restData;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)] // this property should recieve information from http request
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config,
                         IRestaurantData restData)
        {
            this.config = config;
            this.restData = restData;
        }

        public void OnGet()
        {
            Message = config["Message"];
            Restaurants = restData.GetRestaurantsByName(SearchTerm);
        }
    }
}