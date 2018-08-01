using System;
using System.ComponentModel.DataAnnotations;

namespace LabPractice.Models.Data
{
	public class Student
	{
        public Guid Uuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Note { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
	}

    public enum Gender
    {
        Male,
        Female
    }
}
