using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Models;
namespace MyProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AboutUs()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Courses()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Scholar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Register(Student s)
        {
            string pass, cpass, msg;
            pass = Request["Password"];
            cpass = Request["ConfirmPassword"];
            if (pass == cpass)
            {
                HttpPostedFileBase myfile = Request.Files["UserPic"];
                
                if (myfile != null)
                {
                    s.UserPicName = myfile.FileName;
                    // Saving file in folder of server
                    myfile.SaveAs(Server.MapPath("~/Content/UserPics/" + s.UserPicName));
                }
                else
                {
                    if (s.Gender == "Male")
                        s.UserPicName = "male.jpg";
                    else
                        s.UserPicName = "female.jpg";
                }
                s.RegisteredOn = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                // save record in student table
                s.AddNewStudent(s);
                // save record in login table
                Login lg = new Login();
                lg.UserId = s.GetMaxRollNo().ToString();
                lg.Password = pass;
                bool b = lg.SaveLoginDetails(lg);
                if (b == true)
                    msg = "Congratulations ! You are Registered Successfully";
                else msg = "Unable to Register";
            }
            else
                msg = "Password & Confirm Password must be same";

            ViewBag.Message = msg;
            return View();
        }

        [HttpGet]
        public ActionResult ContactUs()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string UserId, string Password)
        {
            Login lg = new Login();
            lg.UserId = UserId;
            lg.Password = Password;
            bool b = lg.ValidateUserLogin();
            if (b == true)
            {
                //creating a session
                Session["uid"] = lg.UserId;
                return RedirectToAction("Welcome", "User");
            }
            else
            {
                ViewBag.Message = "Invalid user or password";
            }
            return View();
        }
        [HttpGet]
        public ActionResult ShowAll()
        { 
            Student s= new Student();

            var students = s.GetAllStudents();

            return View(students);
        }
    }
}