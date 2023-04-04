using System;

namespace WPF_Library.Models.Chat
{
    public class ChatCreateModel
    {
        public string username { get; set; }
        public string message { get; set; }
        public DateTime dispatchTime { get; set; }
    }
}
