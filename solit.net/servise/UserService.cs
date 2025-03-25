using data;
using data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servise
{
    public class UserService
    {
        private UsersRepository _userRepository;
        public UserService()
        {
            _userRepository = new UsersRepository();
        }
        public List<User> GetAllUsers()
        {
            return _userRepository.GetUsers();
        }


        public User GetUserById(int id)
        {
            User user= _userRepository.GetUserById(id);
            user.Password=DecodedPassword(user.Password);
            return user;
        }


        public User AddUser(User user)
        {
            user.Password = EncodePassword(user.Password);

            if (_userRepository.GetUserByEmail(user.Email) != null)
            {
                Console.WriteLine(_userRepository.GetUserByEmail(user.Email));
                throw new Exception("User Exists");
            }
            User toReturn = new User();
            toReturn.Email = user.Email;
            toReturn.Name = user.Name;
            toReturn.Id = user.Id;
            toReturn.Password=DecodedPassword(user.Password);
            return _userRepository.AddUser(user);
        }

        public User UpdateUser(int id, User user)
        {
            return _userRepository.UpdateUser(id, user);
        }

        public User DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }

        public void SendEmailToUser(int id)
        {
            User to = _userRepository.GetUserById(id);
            string userEmail = to.Email;

        }

            private string EncodePassword(string password)
            {
                string hashedPassword = "";//כל תו ייוצג ע''י תו שנמצא 30 מקומות אחריו
                for (int i = 0; i < password.Length; i++)
                {
                    hashedPassword += password[i] + 30;
                }
                return hashedPassword;
            }
        private string DecodedPassword(string password)
        {
            string hashedPassword = "";//כל תו ייוצג ע''י תו שנמצא 30 מקומות אחריו
            for (int i = 0; i < password.Length; i++)
            {
                hashedPassword += password[i] - 30;
            }
            return hashedPassword;

        }
     }
}
