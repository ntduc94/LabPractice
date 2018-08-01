using System;
using System.Collections.Generic;
using LabPractice.Models.Data;
using Newtonsoft.Json;

namespace LabPractice.Models.Business
{
    public class StudentService
    {
        private readonly DataService dataService;
        public StudentService()
        {
            this.dataService = new DataService("Student");

        }

        public List<Student> GetStudents() {
            string dataString = this.dataService.ReadData();
            List<Student> studentList = null;

            if (dataString != "")
            {
                studentList = JsonConvert.DeserializeObject<List<Student>>(dataString);
            }
            else
            {
                studentList = new List<Student>();
            }
            return studentList;
        }

        public void AddStudent(Student student) {
            List<Student> studentList = this.GetStudents();
            studentList.Add(student);

            this.dataService.WriteData(JsonConvert.SerializeObject(studentList));
        }

        public Student GetStudentById(Guid id)
        {
            var studentList = GetStudents();

            if (studentList.Count > 0)
            {
                return studentList.Find(s => s.Uuid == id);
            }

            return null;
        }

        public void UpdateStudentById(Guid id, Student student)
        {
            var studentList = GetStudents();
            if (studentList.Count > 0)
            {
                var studentToBeEdit = studentList.Find(x => x.Uuid == id);

                var index = studentList.FindIndex(x => x.Uuid == id);

                if (studentToBeEdit != null && index > -1)
                {
                    studentToBeEdit.FirstName = student.FirstName;
                    studentToBeEdit.LastName = student.LastName;
                    studentToBeEdit.Gender = student.Gender;
                    studentToBeEdit.Email = student.Email;
                    studentToBeEdit.Birthday = student.Birthday;
                    studentToBeEdit.Note = student.Note;

                    studentList[index] = studentToBeEdit;

                    dataService.WriteData(Newtonsoft.Json.JsonConvert.SerializeObject(studentList));
                }
            }
        }

        public void DeleteStudentById(Guid id)
        {
            var studentList = GetStudents();
            var stundentTobeDelete = studentList.Find(x => x.Uuid == id);
            if (stundentTobeDelete != null)
            {
                studentList.Remove(stundentTobeDelete);
                dataService.WriteData(Newtonsoft.Json.JsonConvert.SerializeObject(studentList));
            }
        }
    }
}
