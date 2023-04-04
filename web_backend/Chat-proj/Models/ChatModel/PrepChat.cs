namespace Chat_proj.Models.ChatModel
{
    public static class PrepChat
    {
        public static void PrepPopiltaion(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<ChatContext>());
            }
        }
        private static void SeedData(ChatContext context)
        {
            if (!context.Chats.Any())
            {
                string message = "--> Filling the DB [Chats], initial data...";
                Chat_RabbitMQ.ChatActionMQ.SendMessage(message);

                context.AddRange(
                    new Chat() { Username = "Admin", Message = "Hello, World!", DispatchTime = DateTime.Now }
                    );
                context.SaveChanges();

                string message2 = "--> Filling the DB [Chats] with initial data was successful !";
                Chat_RabbitMQ.ChatActionMQ.SendMessage(message2);
            }
            else
            {
                string message = "[X] Trying to fill DB [Chats], initial data failed. The data has already been filled in earlier !";
                Chat_RabbitMQ.ChatErrorMQ.SendMessage(message);
            }
        }
    }
}
