using Microsoft.EntityFrameworkCore;
using ThucTapSavis_API.Data;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Services_IServices.Servies
{
    public class UserServices : IUserServices
	{
		public MyDbContext context;
		public UserServices(MyDbContext _context)
		{
			context = _context;
		}
		public async Task<User> AddUser(User User)
		{
			try
			{
				var a = await context.Users.AddAsync(User);
				context.SaveChanges();
				return User;
			}
			catch (Exception e)
			{

				return null;
			}

		}

		public async Task<bool> DeleteUser(Guid Id)
		{
			try
			{
				var a = await context.Users.FindAsync(Id);
				context.Users.Remove(a);
				context.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public async Task<List<User>> GetAllUser()
		{
			var a = await context.Users.ToListAsync();
			return a;
		}
		public async Task<User> GetUserById(Guid Id)
		{
			var x = await context.Users.FirstOrDefaultAsync(c => c.Id == Id);
			return x;
		}
		public async Task<List<User>> GetAllUserById(Guid Id)
		{
			var x = await context.Users.Where(c => c.Id == Id).ToListAsync();
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
		public async Task<User> UpdateUser(User User)
		{
			try
			{
				var a = await context.Users.FindAsync(User.Id);
				a.FullName = User.FullName;
				a.UserName = User.UserName;
				a.Password = User.Password;
				a.Email = User.Email;
				a.NumberPhone = User.NumberPhone;
				a.Tinh = User.Tinh;
				a.Huyen = User.Huyen;
				a.Xa = User.Xa;
				a.DiaChiCuThe = User.DiaChiCuThe;
				a.Status = User.Status;
				context.Users.Update(a);
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
