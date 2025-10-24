using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    internal abstract class ValidationHandler
    {
        protected ValidationHandler Next {  get; private set; }
        public ValidationHandler SetNext(ValidationHandler next)
        {
            return Next = next;
        }
        public bool Handle(RequestContext request)
        {
            if(!Process(request)) return false;
            return Next?.Handle(request) ?? true;

        }

        protected abstract bool Process(RequestContext request);
    }


    internal class RequestContext
    {
        public UserContext User { get; set; }
        public Test test { get; set; }
        public string Action { get; set; }
        public string MessageIfFailed { get; set; }
    }


    internal class AuthValidationHnadler : ValidationHandler
    {
        private readonly UserRole _requiredrole;
        public AuthValidationHnadler(UserRole role)
        {
            _requiredrole = role;
        }
        protected override bool Process(RequestContext request)
        {
            if(request.User == null || request.User.Role != _requiredrole)
            {
                request.MessageIfFailed = "You are not authorized!!";
                return false;
            }
            return true;
        }

    }

    internal class TestNotEmptyHandler : ValidationHandler
    {
        protected override bool Process(RequestContext request)
        {
            if (request.test == null || request.test.Questions.Count == 0)
            {
                request.MessageIfFailed = "No Available Exams right now.";
                return false;
            }
            return true;
        }
    }


    internal class StudentHasAccessHandler : ValidationHandler
    {
        protected override bool Process(RequestContext request)
        {
            if (request.User == null || request.User.Role != UserRole.Student)
            {
                request.MessageIfFailed = "The student is not registered / Unauthorized.";
                return false;
            }
            return true;
        }
    }
}
