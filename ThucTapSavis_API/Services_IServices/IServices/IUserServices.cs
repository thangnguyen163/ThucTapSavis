﻿using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Services_IServices.IServices
{
    public interface IUserServices
    {
		public Task<User> AddUser(User User);
		public Task<User> UpdateUser(User User);
		public Task<bool> DeleteUser(Guid Id);
		public Task<List<User>> GetAllUser();
		public Task<List<User>> GetAllUserById(Guid Id);
	}
}
