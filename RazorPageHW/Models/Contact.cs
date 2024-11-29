using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RazorPageHW.Models.Validation; 


namespace RazorPageHW.Models
{
    public class Contact
    {
        [BindProperty]
        [DisplayName("Id cua ban la")]
        [Range(1,100,ErrorMessage ="Nhap sai")]
        public int ContactId { get; set; }

        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        [DataType(DataType.Date)]
        [CustomBirthDate(ErrorMessage = "ngay sinh nhor hon ngay hien tai")]
        public DateTime DateOfBirth { get; set; }

        [BindProperty]
        [EmailAddress(ErrorMessage = "email sai dinh dang")]
        public string Email { get; set; }
    }
}
