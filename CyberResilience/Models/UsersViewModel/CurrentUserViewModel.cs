using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static CyberResilience.Common.Enums;

namespace CyberResilience.Models.UsersViewModel
{
    public class CurrentUserViewModel
    {
        public string FullName { get; set; }

        public string ProfileImagePath { get; set; }

        public UserType UserType { get; set; }

        public string WorkspaceLayout { get; set; }
        public string WorkspaceControllerName { get; set; }
    }
}