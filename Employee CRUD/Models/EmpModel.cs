﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Employee_CRUD.Models
{
    public partial class EmpModel
    {
        public class Emp
        {
            public int EmpId { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Tel { get; set; }
            public string Address { get; set; }
            public int JobId { get; set; }
            public int DepartmentId { get; set; }
            public DateTime JoinedDate { get; set; }
            public int UserId { get; set; }
            public DateTime TransDate { get; set; }
        }
        public class Jobs
        {
            public int JobId { get; set; }
            public string JobName { get; set; }
        }
        public class Departments
        {
            public int DepartmentId { get; set; }
            public string DepartmentName { get; set; }
        }

        public class ViewEmp
        {
            public int EmpId { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Tel { get; set; }
            public string Address { get; set; }
            public int JobId { get; set; }
            public int DepartmentId { get; set; }
            public DateTime JoinedDate { get; set; }
            public string JobName { get; set; }
            public string DepartmentName { get; set; }
        }
        public class Messages
        {
            public string Message { get; set; }
        }
    
    }
}