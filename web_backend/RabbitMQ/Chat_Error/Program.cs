Task task = RabbitMQ_library.Consumer.RabbitMQ_ConsumerAsync("Chat_Error_Queue", "Chat_Error_Exchange");
task.Wait();