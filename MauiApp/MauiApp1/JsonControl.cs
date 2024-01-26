using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MauiApp1.Models
{
    public class JsonControl
    {
        private static string FilePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "users.json");

        public static List<User> LoadUsers()
        {
            if (!File.Exists(FilePath))
            {
                InitializeFileWithDefaultUser();
            }

            string json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<User>>(json);
        }

        public static void SaveUsers(List<User> users)
        {
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }

        private static void InitializeFileWithDefaultUser()
        {
            User defaultUser = new User
            {
                FirstName = "Pedro",
                LastName = "Rodrigues",
                BirthDate = new DateTime(1992, 04, 27),
                IsMember = true,
                Gender = "Male"
            };

            List<User> initialUsers = new List<User> { defaultUser };
            SaveUsers(initialUsers);
        }
    }
}


