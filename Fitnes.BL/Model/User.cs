﻿using System;

namespace Fitnes.BL.Model
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { set; get; }
        public DateTime BirthDate { set; get; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } set { } }
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или NULL", nameof(name));
            }
            Name = name;
        }
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или NULL", nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException("Гендер не может быть равен NULL", nameof(gender));
            }
            if (birthDate > DateTime.Now || birthDate < DateTime.Parse("01.01.1900"))
            {
                throw new ArgumentException("Невозможная дата рождения", nameof(birthDate));
            }
            if (weight <= 0)
            {
                throw new ArgumentException("Вес не может быть меньше либо равен нулю", nameof(weight));
            }
            if (height <=0)
            {
                throw new ArgumentException("Рост не может быть меньше либо равен нулю.", nameof(height));
            }
            Name=name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }    
        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
