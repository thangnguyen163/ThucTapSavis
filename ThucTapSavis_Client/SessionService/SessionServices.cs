using ThucTapSavis_Shared.ViewModel;
using Newtonsoft.Json;

namespace ThucTapSavis_Client.SessionService
{
    public static class SessionServices
    {
        public static List<CartItem_VM> GetLstFromSession_LstCI(ISession session, string key)
        {
            // Lấy string Json từ Session
            var JsonData = session.GetString(key);
            if (JsonData == null) return new List<CartItem_VM>();

            // Chuyển đổi dữ liệu vừa lấy được từ sang dạng mong muốn
            var s = JsonConvert.DeserializeObject<List<CartItem_VM>>(JsonData);
            // Nếu null thì trả về 1 list rỗng
            return s;
        }
        public static bool SetLstFromSession_LstCI(ISession session, string key, List<CartItem_VM> values)
        {
            try
            {
                var JsonData = JsonConvert.SerializeObject(values);
                session.SetString(key, JsonData);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

		public static User_VM GetUserFromSession_User_VM(ISession session, string key)
		{
			// Lấy string Json từ Session
			var JsonData = session.GetString(key);
			if (JsonData == null) return new User_VM();

			// Chuyển đổi dữ liệu vừa lấy được từ sang dạng mong muốn
			var s = JsonConvert.DeserializeObject<User_VM>(JsonData);
			// Nếu null thì trả về 1 list rỗng
			return s;
		}
	}
}
