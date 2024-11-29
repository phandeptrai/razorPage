using Microsoft.AspNetCore.Mvc;
using RazorPageHW.Models;
using RazorPageHW.Services;

namespace RazorPageHW.Pages.Components.ProductBox
{
    public class ProductBox : ViewComponent
    {
        //List<Product> products = new List<Product>()
        //{

        //   new Product() {Name="Iphone 16 min",Description="Iphone dỏm",Price = 20000 },
        //   new Product() { Name = "SamSung s24", Description = "Dễ bị sọc màn hình", Price = 50000 },
        //   new Product() { Name = "Oppo tàu", Description = "Hàng Tàu", Price = 5000 },


        //};

        List<Product> products = null;


        public IViewComponentResult Invoke()
        {
            return View<List<Product>>(products);
        }
    }

}
