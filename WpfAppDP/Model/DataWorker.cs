using WpfAppDP.Model.Data;
using System.Collections.Generic;
using System.Linq;
namespace WpfAppDP.Model
{
    public static class DataWorker
    {
        //get all employees
        public static List<User> GetAllUsers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Users.ToList();
                return result;
            }
        }

        //create an employee
        public static string CreateUser(string name, string surName, string phone, string comment)
        {
            string result = "Already exists";
            using (ApplicationContext db = new ApplicationContext())
            {
                //check the user is exist
                bool checkIsExist = db.Users.Any(el => el.Name == name && el.SurName == surName && el.Comment == comment);
                if (!checkIsExist)
                {
                    User newUser = new User
                    {
                        Name = name,
                        SurName = surName,
                        Phone = phone,
                        Comment = comment
                    };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    result = "Done!";
                }
                return result;
            }
        }

        //remove employee
        public static string DeleteUser(User user)
        {
            string result = "This employee does not exist";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Remove(user);
                db.SaveChanges();
                result = "Done! Employee" + user.Name + " fired";
            }
            return result;
        }

        //edit employee
        public static string EditUser(User oldUser, string newName, string newSurName, string newPhone, string newComment)
        {
            string result = "This employee does not exist";
            using (ApplicationContext db = new ApplicationContext())
            {
                //check user is exist
                User user = db.Users.FirstOrDefault(p => p.Id == oldUser.Id);
                if (user != null)
                {
                    user.Name = newName;
                    user.SurName = newSurName;
                    user.Phone = newPhone;
                    user.Comment = newComment;
                    db.SaveChanges();
                    result = "Done! Employee " + user.Name + " changed";
                }
            }
            return result;
        }

        //getting all positions by department id
        public static List<User> GetAllUsersByPositionId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<User> users = (from user in GetAllUsers() where user.Id == id select user).ToList();
                return users;
            }
        }
    }
}
