Task task = RabbitMQ_library.Consumer.RabbitMQ_ConsumerAsync("User_Error_Queue", "User_Error_Exchange");
task.Wait();