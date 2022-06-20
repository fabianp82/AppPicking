﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPicking.Model
{
    public class UserBasicInfo
    {
        public string FullName { get; set; }
        public string Usuario { get; set; }
        public string Pass { get; set; }
        public int RoleID { get; set; }
        public string RoleText { get; set; }
    }

    public enum RoleDetails
    {
        Student = 1,
        Teacher,
        Admin,
    }
}
