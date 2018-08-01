using System;
namespace LabPractice.Models.View
{
    public class StudentListItemView
    {
        public Guid Uuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int GetAge() {
            var existedTime = DateTime.Now - this.Birthday;

            return (int)(existedTime.TotalDays / 365.2425);
        }
    }
}
