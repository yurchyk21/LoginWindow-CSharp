using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;

namespace LoginWindow
{
    [Serializable]
    public class ClassUser
    {
        [Serializable]
        public class User
        {
            public string Email;
            public string Phone;
            public string UserName;
            public string Password;
            public User(string email, string phone, string username, string password)
            {
                Email = email;
                Phone = phone;
                UserName = username;
                Password = password;
            }
        }
        static List<User> userList = new List<User>();
        public static int search(string login, string pass)
        {
            foreach (User item in userList)
            {
                if (item.Email == login && item.Password == pass)
                    return 1;
                else if (item.Email == login)
                    return -1;
                else if (item.Password == pass)
                    return -2;
            }
            return 0;
        }
        public static bool searchPhone(string phone)
        {
            foreach (User item in userList)
            {
                if (item.Phone == phone)
                    return true;
            }
            return false;

        }
        public static void AddUser(string email, string phone, string username, string password)
        {
            userList.Add(new User(email, phone, username, password));
            MessageBox.Show("User added", "Info", MessageBoxButton.OK);
        }
        public static void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using(FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if(fs.CanWrite)
                formatter.Serialize(fs, userList);
                else
                    MessageBox.Show("Cannot save file", "Error", MessageBoxButton.OK);
            }
        }
        public static void Load()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (fs.CanRead)
                userList.AddRange((List<User>)formatter.Deserialize(fs));
                else
                    MessageBox.Show("Cannot load userbase", "Error", MessageBoxButton.OK);

            }
        }
    }
}
