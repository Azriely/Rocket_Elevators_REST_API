﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Rocket_Elevators_REST_API.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Batteries = new HashSet<Battery>();
            Interventions = new HashSet<Intervention>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Battery> Batteries { get; set; }
        public virtual ICollection<Intervention> Interventions { get; set; }
    }
}