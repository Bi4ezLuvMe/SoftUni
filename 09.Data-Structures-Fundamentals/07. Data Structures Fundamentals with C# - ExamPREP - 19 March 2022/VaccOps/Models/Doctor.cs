﻿using System.Collections.Generic;

namespace VaccOps.Models
{
    public class Doctor
    {
        public Doctor(string name, int popularity)
        {
            this.Name = name;
            this.Popularity = popularity;
            patients = new List<Patient>();
        }

        public string Name { get; set; }
        public int Popularity { get; set; }
        public List<Patient> patients { get; set; }
    }
}
