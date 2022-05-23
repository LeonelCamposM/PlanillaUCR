﻿using System;

namespace Domain.Employees.Entities
{
    public class Employee
    {
        public String Email { get; }

        public Employee(String email)
        {
            Email = email;
        }
    }
}