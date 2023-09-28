using Microsoft.EntityFrameworkCore;
using ThucTapSavis_API.Data;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Services_IServices.Servies
{
	public class RoleServices : IRoleServices
	{
		public MyDbContext context;
		public RoleServices(MyDbContext _context)
		{
			context = _context;
		}
		public async Task<Role> AddRole(Role Role)
		{
			try
			{
				var a = await context.Roles.AddAsync(Role);
				context.SaveChanges();
				return Role;
			}
			catch (Exception e)
			{

				return null;
			}

		}

		public async Task<bool> DeleteRole(Guid Id)
		{
			try
			{
				var a = await context.Roles.FindAsync(Id);
				context.Roles.Remove(a);
				context.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public async Task<List<Role>> GetAllRole()
		{
			var a = await context.Roles.ToListAsync();
			return a;
		}
		public async Task<Role> GetRoleById(Guid Id)
		{
			var x = await context.Roles.FirstOrDefaultAsync(c => c.Id == Id);
			return x;
		}
		public async Task<List<Role>> GetAllRoleById(Guid Id)
		{
			var x = await context.Roles.Where(c => c.Id == Id).ToListAsync();
			return x;
		}
		//public Guid Id { get; set; }
		//public string Name { get; set; }
		//public int Status { get; set; }
		public async Task<Role> UpdateRole(Role Role)
		{
			try
			{
				var a = await context.Roles.FindAsync(Role.Id);
				a.Name = Role.Name;
				a.Status = Role.Status;
				context.Roles.Update(a);
				context.SaveChanges();
				return a;
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}
