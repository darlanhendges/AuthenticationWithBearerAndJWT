using AuthenticationWithBearerAndJWT.Models;

namespace AuthenticationWithBearerAndJWT.Repositories
{
    public class UserRepository
    {
        public static User? Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "batman", Password = "batman", Role = "manager", Email="batman@gmail.com" });
            users.Add(new User { Id = 2, Username = "robin", Password = "robin", Role = "employee", Email = "robin@gmail.com" });

            return users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password);
        }
    }
}
