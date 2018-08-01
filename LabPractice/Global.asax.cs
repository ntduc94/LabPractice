using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using LabPractice.Models.Data;
using LabPractice.Models.View;

namespace LabPractice
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Model Mappers
            Mapper.Initialize(cfg => {
                cfg.CreateMap<CreateStudentView, Student>();
                cfg.CreateMap<Student, StudentListItemView>();
                cfg.CreateMap<Student, EditStudentView>();
                cfg.CreateMap<EditStudentView, Student>();
            });
        }
    }
}
