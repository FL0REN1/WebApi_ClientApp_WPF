namespace Chat_proj.Models.ChatModel
{
    public class ChatRep : IChatRep
    {
        #region [DATA]

        private readonly ChatContext _context;

        #endregion

        /// <summary>
        /// [ChatRep Constructor]
        /// </summary>
        /// <param name="context"></param>
        /// <param name="repository"></param>
        public ChatRep(ChatContext context)
        {
            _context = context;
        }

        #region [INTERFACE IMPLEMENTATION]

        /// <summary>
        /// [CLEAR_CHAT]
        /// </summary>
        /// <param name="chat"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void ClearChat()
        {
            _context.Chats.RemoveRange(_context.Chats);
        }

        /// <summary>
        /// [CREATE_MESSAGE]
        /// </summary>
        /// <param name="message"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public bool CreateMessage(Chat message)
        {
            if (message == null)
            {
                string logMessage = "[X] Failed to create message because it is empty";
                Chat_RabbitMQ.ChatErrorMQ.SendMessage(logMessage);
                return false;
            }
            _context.Chats.Add(message);
            return true;
        }

        /// <summary>
        /// [DELETE_MESSAGE]
        /// </summary>
        /// <param name="message"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public bool DeleteMessage(int id)
        {
            Chat? message = _context.Chats.FirstOrDefault(m => m.Id == id);
            if (message == null)
            {
                string logMessage = "[X] Failed to delete message because it is empty";
                Chat_RabbitMQ.ChatErrorMQ.SendMessage(logMessage);
                return false;
            }
            _context.Chats.Remove(message);
            return true;
        }

        /// <summary>
        /// [CHANGE_MESSAGE]
        /// </summary>
        /// <param name="message"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public bool ChangeMessage(Chat message)
        {
            if (message == null)
            {
                string logMessage = "[X] Failed to changed message because argument passed is null";
                Chat_RabbitMQ.ChatErrorMQ.SendMessage(logMessage);
                return false;
            }

            Chat? chatToUpdate = _context.Chats.Find(message.Id);
            if (chatToUpdate == null)
            {
                string logMessage = "[X] Failed to changed message because it is null";
                Chat_RabbitMQ.ChatErrorMQ.SendMessage(logMessage);
                return false;
            }

            chatToUpdate.Message = message.Message;
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// [GET_ALL_MESSAGES]
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Chat> GetAllMessages()
        {
            return _context.Chats.ToList();
        }

        /// <summary>
        /// [GET_MESSAGE_BY_ID]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Chat? GetMessageById(int id)
        {
            Chat? IdChat = _context.Chats.FirstOrDefault(x => x.Id == id);
            if (IdChat == null)
            {
                string message = $"[X] DB: [Chat], has no ID: [{id}]";
                Chat_RabbitMQ.ChatErrorMQ.SendMessage(message);
            }
            return IdChat;
        }

        /// <summary>
        /// [SAVE_CHANGES]
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        #endregion
    }
}
