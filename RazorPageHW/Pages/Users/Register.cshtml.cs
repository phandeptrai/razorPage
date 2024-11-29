using RazorPageHW.Models;
using RazorPageHW.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace RazorPageHW.Pages.Users
{
    public class RegisterModel : PageModel
    {
        private readonly UserService _userService;

        public RegisterModel(UserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public User User { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _userService.RegisterAsync(User);
            if (result)
            {
                return RedirectToPage("/Users/Login");
            }
            else
            {
                Message = "Email đã tồn tại!";
                return Page();
            }
        }
    }
}
