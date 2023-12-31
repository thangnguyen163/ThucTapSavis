﻿using Microsoft.AspNetCore.Mvc;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThucTapSavis_API.Controllers
{
	[Route("api/User")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserServices _User;
		public UserController(IUserServices User)
		{
			_User = User;
		}

		[HttpGet("get-user")]
		public async Task<List<User>> GetAllUser()
		{
			var User = await _User.GetAllUser();
			return User;
		}
		[HttpGet("{Id}")]
		public async Task<User> GetUserById(Guid Id)
		{
			var x = await _User.GetUserById(Id);
			return x;
		}
		//public Guid Id { get; set; }
		//public string FirstName { get; set; }
		//public string LastName { get; set; }
		//public string UserName { get; set; }
		//public string Password { get; set; }
		//public string Email { get; set; }
		//public string NumberPhone { get; set; }
		//public bool Sex { get; set; }
		//public int Status { get; set; }
		//public string Tinh { get; set; }
		//public string Huyen { get; set; }
		//public string Xa { get; set; }
		//public string DiaChiCuThe { get; set; }
		[HttpPost("add-user")]
		public async Task<ActionResult> PostUser(User_VM rvm)
		{
			User User = new User();
			User.Id = rvm.Id;
			User.FullName = rvm.FullName;
			User.UserName = rvm.UserName;
			User.Password = rvm.Password;
			User.Email = rvm.Email;
			User.NumberPhone = rvm.NumberPhone;
			User.Tinh = rvm.Tinh;
			User.Huyen = rvm.Huyen;
			User.Xa = rvm.Xa;
			User.DiaChiCuThe = rvm.DiaChiCuThe;
			User.Status = rvm.Status;
			User.IdRole = Guid.Parse("1001d4d6-ebae-4c35-8332-7d2b1a60fa44");
			await _User.AddUser(User);
			return Ok();
		}
		[HttpPut("update-user")]
		public async Task<ActionResult<User>> PutUser(User_VM rvm)
		{
			User User = await _User.GetUserById(rvm.Id);
			User.FullName = rvm.FullName;
			User.UserName = rvm.UserName;
			User.Password = rvm.Password;
			User.Email = rvm.Email;
			User.NumberPhone = rvm.NumberPhone;
			User.Tinh = rvm.Tinh;
			User.Huyen = rvm.Huyen;
			User.Xa = rvm.Xa;
			User.DiaChiCuThe = rvm.DiaChiCuThe;
			User.Status = rvm.Status;
			User.IdRole=rvm.IdRole;
			await _User.UpdateUser(User);
			return Ok();
		}
		[HttpPut("change-password")]
		public async Task<ActionResult<User>> ChangPassword(User_VM rvm)
		{
			User User = await _User.GetUserById(rvm.Id);
			User.Password = rvm.Password;
			await _User.UpdateUser(User);
			return Ok();
		}
		[HttpDelete("delete-user")]
		public async Task<ActionResult<User>> Delete(Guid id)
		{
			await _User.DeleteUser(id);
			return Ok();
		}
	}
}
