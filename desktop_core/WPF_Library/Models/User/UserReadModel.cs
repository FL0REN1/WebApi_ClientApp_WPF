using System;

namespace WPF_Library.Models.User
{
    public class UserReadModel
    {
        public int id { get; set; }
        public string username { get; set; }
        public int age { get; set; }
        public bool isOnline { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public bool isAdmin { get; set; }

        public static implicit operator UserReadModel(UserCreateModel v)
        {
            throw new NotImplementedException();
        }
    }
}
