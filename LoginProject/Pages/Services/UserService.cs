using LoginProject.Data;
using LoginProject.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginProject.Pages.Services
{
    public class UserService
    {
        private IDbContextFactory<LoginDbContext> _dbContextFactory;

        public UserService(IDbContextFactory<LoginDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void AddUser(User user)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
        public User GetUserByName(string username)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var user = context.Users.SingleOrDefault(x => x.UserName == username);
                return user;
            }
        }

        //public bool ValidateUser(string username, string password)
        //{
        //    using(var context = _dbContextFactory.CreateDbContext())
        //    {
        //        bool isUser = false;
        //        var usersName = context.Users.SingleOrDefault(x => x.UserName == username);
        //        var usersPass = context.Users.SingleOrDefault(x => x.Password == password);
        //        if(usersName != null && usersPass != null)
        //        {
        //            isUser = true;
        //        }
        //        return isUser;
        //    }
        //}

        public void UpdateUserByName(string username, string password)
        {
            var user = GetUserByName(username);
            if (user == null)
            {
                throw new Exception("Customer Does Not Extist. Cannot Update");
            }
            user.Password = password;
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Update(user);
                context.SaveChanges();
            }
        }

        public bool GetUserByUserName(User userLogin)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var user = context.Users.SingleOrDefault(x => x.UserName == userLogin.UserName) != null ? context.Users.SingleOrDefault(x => x.UserName == userLogin.UserName) : null;
                return user != null && (user.Password == userLogin.Password) ? true : false;
            }
        }
        public bool isLoggedIn { get; set; }

        public User[] GetUsers()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                User[] allUsers = context.Users.ToArray();
                return allUsers;
            }
        }

    }
}
