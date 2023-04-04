using AutoMapper;
using Chat_proj.Models.ChatModel.Dto;

namespace Chat_proj.Models.ChatModel
{
    public class ChatProfile : Profile
    {
        public ChatProfile()
        {
            CreateMap<Chat, ChatReadDto>(); // Прямой mapping ( 1 к 1 )
            CreateMap<ChatDeleteDto, Chat>();
            CreateMap<ChatCreateDto, Chat>();
            CreateMap<ChatChangeDto, Chat>();
        }
    }
}
