using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Course { get; set; }
        public string CourseYear { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string UserPicName { get; set; }
        public string RegisteredOn { get; set; }
        string command, msg;
        DBManager dm = new DBManager();
        internal string AddNewStudent(Student s)
        {
            command = "insert into StudentMaster values('" + s.Name + "','" + s.Gender + "','" + s.Course + "','" + s.CourseYear + "','" + s.EmailId + "','" + s.MobileNo + "','" + s.UserPicName + "','" + s.RegisteredOn + "')";
            bool b = dm.ExecuteMyInsertUpdateOrDelete(command);
            msg = b == true ? "Congratulation ! you are registered successfully." : "Sorry ! Unable to create your account";
            return msg;
        }

        internal int GetMaxRollNo()
        {
            command = "select Max(RollNo) from StudentMaster";
            DataTable dt = dm.ExecuteMySelect(command);
            int rno = int.Parse(dt.Rows[0][0].ToString());
            return rno;


        }

        public List<Student> GetAllStudents()
        {
            string command = "select *from StudentMaster";
            DataTable dt = dm.ExecuteMySelect(command);
            List<Student> students = new List<Student>();
            foreach (DataRow dr in dt.Rows)
            {
                Student p = new Student();
                p.RollNo = int.Parse(dr[0].ToString());
                p.Name = dr[1].ToString();
                p.Gender = dr[2].ToString();
                p.Course = dr[3].ToString();
                p.CourseYear = dr[4].ToString();
                p.EmailId = dr[5].ToString();
                p.MobileNo = dr[6].ToString();
                p.UserPicName = dr[7].ToString();
                p.RegisteredOn = dr[8].ToString();
                students.Add(p);
            }
            return students;
        }
    }
}
