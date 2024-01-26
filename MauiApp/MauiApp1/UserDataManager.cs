using System;
using System.Collections.Generic;
using System.Linq;

namespace MauiApp1.Models
{
    public class UserDataManager
    {
        private static List<User> users;

        static UserDataManager()
        {
            LoadUsers();
        }

        public static List<User> GetAllUsers()
        {
            return users;
        }

        public static void AddUser(User user)
        {
            user.Code = GenerateUniqueCode();
            users.Add(user);
            SaveUsers();
        }

        public static void DeleteUser(int codeToDelete)
        {
            User userToDelete = users.FirstOrDefault(u => u.Code == codeToDelete);
            if (userToDelete != null)
            {
                users.Remove(userToDelete);
                SaveUsers();
            }
        }

        private static void LoadUsers()
        {
            users = JsonControl.LoadUsers();
        }

        public static void SaveUsers()
        {
            JsonControl.SaveUsers(users);
        }

        private static int GenerateUniqueCode()
        {
            int newCode = 1;
            if (users.Any())
            {
                newCode = users.Max(u => u.Code) + 1;
            }
            return newCode;
        }
    }
}


