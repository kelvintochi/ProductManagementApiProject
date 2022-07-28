using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagementApi.Models;
using ProductManagementApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
		private readonly IJWTManagerRepository _jWTManager;

		public UserController(IJWTManagerRepository jWTManager)
		{
			this._jWTManager = jWTManager;
		}
		//[Authorize]
		[HttpGet]
		public List<string> Get()
		{
			var users = new List<string>
			{
					"Satinder Singh"
			
			};

			return users;
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("authenticate")]
		public IActionResult Authenticate(User usersdata)
		{
			var token = _jWTManager.Authenticate(usersdata);

			if (token == null)
			{
				return Unauthorized();
			}

			return Ok(token);
		}
	}
}
