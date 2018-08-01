using System;
using LabPractice.Models.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LabPractice.Models.View
{
    public class CreateStudentView
    {
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Gender")]
        public Gender Gender { get; set; }
        [Required]
        [DisplayName("Birthday")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Birthday { get; set; }
        [Required]
        [DisplayName("Email")]
        //[Required(ErrorMessage = "Please Enter Your Email Address.")]
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9._]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid")]
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
        [ReadOnly(true)]
        public string Note { get; set; }

        public int GetAge()
        {
            var existedTime = DateTime.Now - Birthday;
            return (int)(existedTime.TotalDays / 365.2425);
        }
    }
}
