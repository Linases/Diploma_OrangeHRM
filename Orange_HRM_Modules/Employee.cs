using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constants;
using Utilities;

namespace Orange_HRM_Modules
{
    public class Employee
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string MiddleName { get; set; }
        public required string Lastname { get; set; }

        public static Employee Default
        {
            get
            {
                return new Employee
                {
                    Id = 1,
                    FirstName = $"First_{RandomHelper.RandomGenerate(5)}",
                    MiddleName = $"Middle_{RandomHelper.RandomGenerate(5)}",
                    Lastname = $"Last_{RandomHelper.RandomGenerate(5)}",
                };
            }
        }
    }
}

