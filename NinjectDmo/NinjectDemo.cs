using System;
using System.Collections.Generic;
using demoprojMVC.IBLL;
using demoprojMVC.Model;
using Ninject;

namespace NinjectDmo
{
    public class NinjectDemo
    {

        private Itd_studentsService studentsService;

        public NinjectDemo(Itd_studentsService param)
        {
            studentsService = param;
        }
        public void Print()
        {
            IEnumerable<td_students> student = studentsService.GetEntities(u => u.school_code == "15190206");
            foreach (var stu in student)
            {
                Console.WriteLine(stu.school_code + stu.student_name);
            }
        }
        
}
}