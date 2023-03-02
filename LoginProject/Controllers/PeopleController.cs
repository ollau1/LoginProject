using LoginProject.Data.Models;
using LoginProject.Pages.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoginProject.Controllers
{
    public class PeopleController
    {
        private readonly UserService _userService;
        [Route("api/GetPeople")]
        [HttpGet]
        public User[] GetUsers()
        {
            return _userService.GetUsers();
        }
    }
}
