using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageHW.Models;

namespace RazorPageHW.Pages.Contacts
{
    public class ContactPageModel : PageModel
    {
        [BindProperty]
        public Contact contact { get; set; }

        public ContactPageModel() 
        {
            contact = new Contact();
        }
        public void OnGet()
        {
    
        }
        public string thongbao { get; set; }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                thongbao = "hople";
            } else {
                thongbao = " m cuc";
            }


        }

    }
}
