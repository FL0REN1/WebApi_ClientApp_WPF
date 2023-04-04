namespace User_proj.Models.UserModel
{
    public static class PrepUser
    {
        public static void PrepPopiltaion(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<UserContext>());
            }
        }
        private static void SeedData(UserContext context)
        {
            if (!context.Users.Any())
            {
                string message = "--> Filling the DB [Users], initial data...";
                UserRabbitMQ.UserActionMQ.SendMessage(message);

                context.AddRange(
                    new User() { Username = "Admin", Age = 18, IsOnline = false, Login = "sa", Password = "123", IsAdmin = true },
                    new User() { Username = "M1cky44", Age = 19, IsOnline = false, Login = "micky", Password = "M1ckyyy", IsAdmin = false },
                    new User() { Username = "D0g123", Age = 21, IsOnline = false, Login = "WoofWoof", Password = "W00f", IsAdmin = false }
                    );

                context.SaveChanges();

                string message2 = "--> Filling the DB [Users] with initial data was successful !";
                UserRabbitMQ.UserActionMQ.SendMessage(message2);
            }
            else
            {
                string message = "[X] Trying to fill DB [Users], initial data failed. The data has already been filled in earlier !";
                UserRabbitMQ.UserErrorMQ.SendMessage(message);
            }
        }
    }
}
