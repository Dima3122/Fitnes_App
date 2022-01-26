using Fitnes.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitnes.BL.Controller
{
    public class UserController : ControllerBase
    {
        public List<User> Users { get; }
        public User CurrentUser { get; }
        private const string USERS_FILE_NAME = "users.dat";
        public bool IsNewUser { get; } = false;
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }
            Users = Get_Users_Data();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }
        private List<User> Get_Users_Data()
        {
            return Load<List<User>>(USERS_FILE_NAME) ?? new List<User>();
        }
        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            if (genderName == null)
            {
                throw new ArgumentNullException("Гендер не может быть равен NULL", nameof(genderName));
            }
            if (birthDate > DateTime.Now || birthDate < DateTime.Parse("01.01.1900"))
            {
                throw new ArgumentException("Невозможная дата рождения", nameof(birthDate));
            }
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Height = height;
            CurrentUser.Weight = weight;
        }
        public void Save()
        {
            Save(USERS_FILE_NAME, Users);
        }      
    }
}
