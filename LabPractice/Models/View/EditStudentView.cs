using LabPractice.Models.Data;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LabPractice.Models.View
{
    public class EditStudentView
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
        public string Email { get; set; }
        [StringLength(256)]
        public string Note { get; set; }
        public int GetAge()
        {
            var existedTime = DateTime.Now - Birthday;
            return (int)(existedTime.TotalDays / 365.2425);
        }
    }
}
