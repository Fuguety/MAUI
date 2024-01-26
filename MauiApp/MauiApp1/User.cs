using System;
using System.Collections.Generic;
using System.Linq;

namespace MauiApp1.Models
{
    public class User
    {
        private static List<int> UsedCodes = new List<int>();

        public User()
        {
            Code = GenerateUniqueCode();
        }

        public int Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsMember { get; set; }
        public string Gender { get; set; }

        private int GenerateUniqueCode()
        {
            int newCode = 1;

            if (UsedCodes.Any())
            {
                newCode = UsedCodes.Max() + 1;
            }

            UsedCodes.Add(newCode);

            return newCode;
        }
    }
}


