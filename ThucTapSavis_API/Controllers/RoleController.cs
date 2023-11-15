using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_API.Controllers
{
	[Route("api/Role")]
	[ApiController]
	public class RoleController : ControllerBase
	{
		private readonly IRoleServices _role;
		public RoleController(IRoleServices role)
		{
			_role = role;
		}
		
		[HttpGet]
		public async Task<List<Role>> GetAllRole()
		{
			var role = await _role.GetAllRole();
			return role;
		}
		[HttpGet("{Id}")]
		public async Task<Role> GetRoleById(Guid Id)
		{
			var x = await _role.GetRoleById(Id);
			return x;
		}
		[HttpPost("Add")]
		public async Task<ActionResult<Role>> PostRole(Role_VM rvm)
		{
			Role role = new Role();
			role.Id = Guid.NewGuid();
			role.Name = rvm.RoleName;
			role.Status = 1;
			await _role.AddRole(role);
			return Ok();
		}
		[HttpPut("update")]
		public async Task<ActionResult<Role>> PutRole(Role_VM rvm)
		{
			Role role = await _role.GetRoleById(rvm.Id);
			role.Name = rvm.RoleName;
			role.Status = rvm.Status;
			await _role.UpdateRole(role);
			return Ok();
		}
		[HttpDelete("Id")]
		public async Task<ActionResult<Role>> Delete(Guid id)
		{
			await _role.DeleteRole(id);
			return Ok();
		}
	}
}
