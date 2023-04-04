using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using User_proj.Models.UserModel.Dto;
using User_proj.Models.UserModel;

namespace User_proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region [DATA]

        private readonly IUserRep _repository;
        private readonly IMapper _mapper;

        #endregion

        public UserController(IUserRep repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #region [WebAPI]

        /// <summary>
        /// [CREATE_USER]
        /// </summary>
        /// <param name="userCreateDto"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateUser")]
        public ActionResult<UserReadDto> CreateUser([FromBody] UserCreateDto userCreateDto)
        {
            string logMessage = $"--> User creation: {userCreateDto.Username}...";
            UserRabbitMQ.UserActionMQ.SendMessage(logMessage);

            User userModel = _mapper.Map<User>(userCreateDto);
            bool success = _repository.CreateUser(userModel);
            if (!success) return NotFound();
            _repository.SaveChanges();

            UserReadDto userReadDto = _mapper.Map<UserReadDto>(userModel);

            string logMessage2 = $"--> User created successfully ! [{userReadDto.Id}] : {userReadDto.Username}";
            UserRabbitMQ.UserActionMQ.SendMessage(logMessage2);

            return Ok(userReadDto);
        }

        /// <summary>
        /// [DELETE_USER]
        /// </summary>
        /// <param name="userDeleteDto"></param>
        /// <returns></returns>
        [HttpDelete(Name = "DeleteUser")]
        public ActionResult<UserReadDto> DeleteUser([FromBody] UserDeleteDto userDeleteDto)
        {
            string logMessage = $"--> Deleting a user: {userDeleteDto.Username}...";
            UserRabbitMQ.UserActionMQ.SendMessage(logMessage);

            User userModel = _mapper.Map<User>(userDeleteDto);
            bool success = _repository.DeleteUser(userModel.Id);
            if (!success) return NotFound();
            _repository.SaveChanges();

            UserReadDto userReadDto = _mapper.Map<UserReadDto>(userModel);

            string logMessage2 = $"--> User deleted successfully ! [{userReadDto.Id}] : {userReadDto.Username}";
            UserRabbitMQ.UserActionMQ.SendMessage(logMessage2);

            return Ok(userReadDto);
        }

        /// <summary>
        /// [CHANGE_USER]
        /// </summary>
        /// <param name="userChangeDto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("change/{id}", Name = "ChangeUser")]
        public ActionResult<UserReadDto> ChangeUser(UserChangeDto userChangeDto, int id) 
        {
            string logMessage = $"--> Changing a user: {userChangeDto.Username}...";
            UserRabbitMQ.UserActionMQ.SendMessage(logMessage);

            User userModel = _mapper.Map<User>(userChangeDto);
            bool success = _repository.ChangeUser(userModel, id);
            if (!success) return NotFound();
            _repository.SaveChanges();

            UserReadDto userReadDto = _mapper.Map<UserReadDto>(userModel);

            string logMessage2 = $"--> User changed successfully ! [{userReadDto.Id}] : {userReadDto.Username}";
            UserRabbitMQ.UserActionMQ.SendMessage(logMessage2);

            return Ok(userReadDto);
        }

        /// <summary>
        /// [CLEAR_USERS]
        /// </summary>
        /// <returns></returns>
        [HttpDelete("clearAll", Name = "ClearUsers")]
        public ActionResult<UserReadDto> ClearUsers()
        {
            string logMessage = "--> Clearing all users...";
            UserRabbitMQ.UserActionMQ.SendMessage(logMessage);

            _repository.ClearUsers();
            _repository.SaveChanges();

            string logMessage2 = $"--> users deleted successfully !";
            UserRabbitMQ.UserActionMQ.SendMessage(logMessage2);

            return Ok();
        }

        /// <summary>
        /// [GET_ALL_MESSAGESS]
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetAllUsers")]
        public ActionResult<IEnumerable<UserReadDto>> GetAllUsers()
        {
            string logMessage = "--> Getting all users...";
            UserRabbitMQ.UserActionMQ.SendMessage(logMessage);

            var userModel = _repository.GetAllUsers();

            string logMessage2 = $"--> Users received successfully !";
            UserRabbitMQ.UserActionMQ.SendMessage(logMessage2);

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userModel));
        }

        /// <summary>
        /// [GET_USER_BY_ID]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id", Name = "GetUserById")]
        public ActionResult<UserReadDto> GetUserById(int id)
        {
            string logMessage = $"--> Getting user N: [{id}]...";
            UserRabbitMQ.UserActionMQ.SendMessage(logMessage);

            var userModel = _repository.GetUserById(id);
            if (userModel == null) return NotFound();

            string logMessage2 = $"--> User N: [{id}] successfully received !";
            UserRabbitMQ.UserActionMQ.SendMessage(logMessage2);

            return Ok(_mapper.Map<UserReadDto>(userModel));
        }
        /// <summary>
        /// [CHECK_LOGIN]
        /// </summary>
        /// <param name="userLoginDto"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public ActionResult<UserReadDto> CheckLogin([FromBody] UserLoginDto userLoginDto)
        {
            string logMessage = $"--> Getting user by login and password...";
            UserRabbitMQ.UserActionMQ.SendMessage(logMessage);

            var userModel = _repository.GetUserByLoginAndPassword(userLoginDto);
            if ( userModel == null ) return NotFound();

            string logMessage2 = $"--> User by login and password received successfully !";
            UserRabbitMQ.UserActionMQ.SendMessage(logMessage2);

            return Ok(_mapper.Map<UserReadDto>(userModel));
        }
        /// <summary>
        /// [CHANGE_STATUS]
        /// </summary>
        /// <param name="id"></param>
        /// <param name="IsOnline"></param>
        /// <returns></returns>
        [HttpPut("id", Name = "ChangeStatus")]
        public ActionResult<UserReadDto> ChangeStatus(int id, bool IsOnline)
        {
            string logMessage = $"--> Getting user by id...";
            UserRabbitMQ.UserActionMQ.SendMessage(logMessage);

            bool success = _repository.ChangeUserStatus(id, IsOnline);
            if (!success) return NotFound();
            _repository.SaveChanges();

            return Ok();
        }

        #endregion
    }
}
