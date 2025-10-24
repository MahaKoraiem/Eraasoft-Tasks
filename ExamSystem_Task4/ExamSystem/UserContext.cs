using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{

    enum UserRole
    {
        Student,
        Instructor,
        Guest
    }
    internal class UserContext
    {
        public string Name { get; set; }
        public UserRole Role { get; set; } = UserRole.Guest;


        public bool IsInRole(UserRole role)
        {
            return Role == role;
        }
    }
}
