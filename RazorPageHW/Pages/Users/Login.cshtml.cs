using RazorPageHW.Models;
using RazorPageHW.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace RazorPageHW.Pages.Users
{
    public class LoginModel : PageModel
    {
        private readonly UserService _userService;

        public LoginModel(UserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userService.LoginAsync(Email, Password);
            if (user == null)
            {
                Message = "Sai email hoặc mật khẩu!";
                return Page();
            }

            // Lưu tên người dùng vào session
            HttpContext.Session.SetString("Username", user.Name);

            // Redirect đến trang chính sau khi đăng nhập thành công
            return RedirectToPage("/Index");
        }
        // Thêm phương thức xử lý Logout
        public IActionResult OnPostLogout()
        {
            // Xóa session
            HttpContext.Session.Clear();

            // Chuyển hướng đến trang đăng nhập
            return RedirectToPage("/Users/Login");
        }

    }
}
