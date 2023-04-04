using AutoMapper;
using Chat_proj.Models.ChatModel.Dto;
using Chat_proj.Models.ChatModel;
using Microsoft.AspNetCore.Mvc;

namespace Chat_proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        #region [DATA]

        private readonly IChatRep _repository;
        private readonly IMapper _mapper;

        #endregion

        /// <summary>
        /// [ChatController]
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logging"></param>
        /// <param name="mapper"></param>
        public ChatController(IChatRep repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #region [WebAPI]

        /// <summary>
        /// [CLEAR_CHAT]
        /// </summary>
        /// <param name="chatDeleteDto"></param>
        /// <returns></returns>
        [HttpDelete(Name = "ClearChat")]
        public ActionResult<ChatReadDto> ClearChat()
        {
            string logMessage = "--> Deliting a chat...";
            Chat_RabbitMQ.ChatActionMQ.SendMessage(logMessage);

            _repository.ClearChat();
            _repository.SaveChanges();

            string logMessage2 = $"--> Chat deleted successfully !";
            Chat_RabbitMQ.ChatActionMQ.SendMessage(logMessage2);

            return Ok();
        }

        /// <summary>
        /// [CREATE_MESSAGE]
        /// </summary>
        /// <param name="chatCreateDto"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateMessage")]
        public ActionResult<ChatReadDto> CreateMessage(ChatCreateDto chatCreateDto)
        {
            string logMessage = $"--> Create a message: {chatCreateDto.Message}...";
            Chat_RabbitMQ.ChatActionMQ.SendMessage(logMessage);

            Chat chatModel = _mapper.Map<Chat>(chatCreateDto);
            bool success = _repository.CreateMessage(chatModel);
            if (!success) return NotFound();
            _repository.SaveChanges();

            ChatReadDto chatReadDto = _mapper.Map<ChatReadDto>(chatModel);

            string logMessage2 = $"--> Message created successfully !";
            Chat_RabbitMQ.ChatActionMQ.SendMessage(logMessage2);

            return Ok(chatReadDto);
        }

        /// <summary>
        /// [DELETE_MESSAGE]
        /// </summary>
        /// <param name="chatDeleteDto"></param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteMessage")]
        public ActionResult<ChatReadDto> DeleteMessage(ChatDeleteDto chatDeleteDto)
        {
            string logMessage = $"--> Deleting a message: {chatDeleteDto.Message}...";
            Chat_RabbitMQ.ChatActionMQ.SendMessage(logMessage);

            Chat chatModel = _mapper.Map<Chat>(chatDeleteDto);
            bool success = _repository.DeleteMessage(chatModel.Id);
            if (!success) return NotFound();
            _repository.SaveChanges();

            ChatReadDto chatReadDto = _mapper.Map<ChatReadDto>(chatModel);

            string logMessage2 = $"--> Message deleted successfully !";
            Chat_RabbitMQ.ChatActionMQ.SendMessage(logMessage2);

            return Ok(chatReadDto);
        }

        /// <summary>
        /// [CHANGE_MESSAGE]
        /// </summary>
        /// <param name="chatChangeDto"></param>
        /// <returns></returns>
        [HttpPut(Name = "ChangeMessage")]
        public ActionResult<ChatReadDto> ChangeMessage(ChatChangeDto chatChangeDto)
        {
            string logMessage = $"--> Edit message: {chatChangeDto.Message} | [{chatChangeDto.Id}]...";
            Chat_RabbitMQ.ChatActionMQ.SendMessage(logMessage);

            var existingModel = _repository.GetMessageById(chatChangeDto.Id);
            if (existingModel == null) NotFound();

            Chat chatModel = _mapper.Map<Chat>(chatChangeDto);
            bool success = _repository.ChangeMessage(chatModel);
            if (!success) return NotFound();

            ChatReadDto chatReadDto = _mapper.Map<ChatReadDto>(chatModel);

            string logMessage2 = $"--> Message successfully changed ! [{existingModel.Username}]: {existingModel.Message} --> [{chatReadDto.Username}]: {chatReadDto.Message}";
            Chat_RabbitMQ.ChatActionMQ.SendMessage(logMessage2);

            return Ok(chatReadDto);
        }

        /// <summary>
        /// [GET_ALL_MESSAGESS]
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetAllMessages")]
        public ActionResult<IEnumerable<ChatReadDto>> GetAllMessages()
        {
            string logMessage = "--> Get all messages...";
            Chat_RabbitMQ.ChatActionMQ.SendMessage(logMessage);

            var chatModel = _repository.GetAllMessages();

            string logMessage2 = $"--> Messages received successfully !";
            Chat_RabbitMQ.ChatActionMQ.SendMessage(logMessage2);

            return Ok(_mapper.Map<IEnumerable<ChatReadDto>>(chatModel));
        }

        /// <summary>
        /// [GET_MESSAGE_BY_ID]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id", Name = "GetMessageById")]
        public ActionResult<ChatReadDto> GetMessageById(int id)
        {
            string logMessage = $"--> Receiving message N: [{id}]...";
            Chat_RabbitMQ.ChatActionMQ.SendMessage(logMessage);

            var chatModel = _repository.GetMessageById(id);
            if (chatModel == null) return NotFound();

            string logMessage2 = $"--> Message N: [{id}] successfully received !";
            Chat_RabbitMQ.ChatActionMQ.SendMessage(logMessage2);

            return Ok(_mapper.Map<ChatReadDto>(chatModel));
        }

        #endregion
    }
}
