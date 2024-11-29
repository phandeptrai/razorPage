using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPageHW.Models.Validation // Đảm bảo namespace khớp với cấu trúc thư mục của bạn
{
    public class CustomBirthDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime birthDate)
            {
                if (birthDate < DateTime.Now)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(ErrorMessage ?? "Ngày sinh phải nhỏ hơn ngày hiện tại.");
                }
            }
            return new ValidationResult("Định dạng ngày không hợp lệ.");
        }
    }
}
