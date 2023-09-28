using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Services_IServices.IServices
{
	public interface IRoleServices
	{
		public Task<Role> AddRole(Role Role);
		public Task<Role> UpdateRole(Role Role);
		public Task<bool> DeleteRole(Guid Id);
		public Task<List<Role>> GetAllRole();
		public Task<List<Role>> GetAllRoleById(Guid Id);
	}
}
