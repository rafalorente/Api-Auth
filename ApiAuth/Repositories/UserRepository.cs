using ApiAuth.Models;

namespace ApiAuth.Repositories
{
    public static class UserRepository
    {
        public static UserModel GetUser(string username, string password)
        {
            var users = new List<UserModel> 
            {
                new() {Id = 1, Username = "rafael", Password = "123456", Role = "manager" },
                new() {Id = 2, Username = "giovanna", Password = "1234567", Role = "employee" }
            };

            return users.FirstOrDefault(X => X.Username == username && X.Password == password);
        }
    }
}
