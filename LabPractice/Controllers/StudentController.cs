using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

using LabPractice.Models.Business;
using LabPractice.Models.Data;
using LabPractice.Models.View;

namespace LabPractice.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Index()
        {
            try {
                StudentService studentService = new StudentService();

                List<Student> studentList = studentService.GetStudents();

                List<StudentListItemView> studentItemViewList = Mapper.Map<List<StudentListItemView>>(studentList);
                return View (studentItemViewList);
            }
            catch (Exception e) {
                throw (e);
            }
        }

        public ActionResult Details(int id)
        {
            return View ();
        }

        public ActionResult Create()
        {
            return View (new CreateStudentView());
        } 

        [HttpPost]
        public ActionResult Create(CreateStudentView FormData)
        {
            try {
                if (!ModelState.IsValid)
                {
                    return View(FormData);
                }
                StudentService studentService = new StudentService();

                List<Student> studentList = studentService.GetStudents();

                Student student = Mapper.Map<Student>(FormData);

                student.Uuid = Guid.NewGuid();
                student.LastLogin = null;
                student.CreatedAt = DateTime.Now;
                student.UpdatedAt = DateTime.Now;

                studentService.AddStudent(student);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return View();
            }
        }

        public ActionResult Edit(Guid id)
        {
            try
            {
                return View(Mapper.Map<EditStudentView>(new StudentService().GetStudentById(id)));
            }
            catch (Exception e)
            {
                throw(e);
            }
        }

        [HttpPost]
        public ActionResult Edit(Guid id, EditStudentView editStudentView)
        {
            try
            {
                if (editStudentView.GetAge() <= 18)
                {
                    ModelState.AddModelError(String.Empty, "User must be older or equal 18 years old");
                }
                if (!ModelState.IsValid)
                {
                    return View(editStudentView);
                }
                new StudentService().UpdateStudentById(id, Mapper.Map<Student>(editStudentView));
                return RedirectToAction("Index");
                //StudentService studentService = new StudentService();
                //Student student = studentService.GetStudentById(id);

                //EditStudentView selectedStudent = Mapper.Map<EditStudentView>(student);

                //return View(selectedStudent);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(Guid id)
        {
            try
            {
                ViewBag.student = new StudentService().GetStudentById(id);
            }
            catch (Exception e)
            {
                throw(e);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Guid id, Student student)
        {
            try
            {
                new StudentService().DeleteStudentById(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
