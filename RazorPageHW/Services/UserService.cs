﻿using RazorPageHW.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using RazorPageHW.Context;

namespace RazorPageHW.Services
{
    public class UserService
    {
        private readonly DBContext _context;

        public UserService(DBContext context)
        {
            _context = context;
        }

        // Đăng ký người dùng mới
        public async Task<bool> RegisterAsync(User user)
        {
            var existingUser = await _context.users
                .Where(u => u.Email == user.Email)
                .FirstOrDefaultAsync();
            if (existingUser != null)
            {
                return false; // Email đã tồn tại
            }

            // Lưu người dùng vào cơ sở dữ liệu
            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        // Đăng nhập người dùng
        public async Task<User> LoginAsync(string email, string password)
        {
            var user = await _context.users
                .Where(u => u.Email == email && u.Password == password)
                .FirstOrDefaultAsync();
            return user;
        }
    }
}
