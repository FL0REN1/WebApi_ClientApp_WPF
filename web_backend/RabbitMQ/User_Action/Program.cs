Task task = RabbitMQ_library.Consumer.RabbitMQ_ConsumerAsync("User_Action_Queue", "User_Action_Exchange");
task.Wait();