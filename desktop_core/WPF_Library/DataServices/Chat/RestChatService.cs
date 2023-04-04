using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WPF_Library.Models.Chat;
using Xamarin.Essentials;

namespace WPF_Library.DataServices.Chat
{
    public class RestChatService : IRestChatService
    {
        #region [DATA]

        private readonly HttpClient _httpClient;

        #endregion

        /// <summary>
        /// [CONSTRUCTOR]
        /// </summary>
        public RestChatService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5163/api/");
        }

        #region [INTERFACE IMPLEMENTATION]

        /// <summary>
        /// [GET_ALL_MESSAGES]
        /// </summary>
        /// <returns></returns>
        public async Task<ObservableCollection<ChatReadModel>> GetAllMessages()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("Chat/");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                ObservableCollection<ChatReadModel> chats = JsonConvert.DeserializeObject<ObservableCollection<ChatReadModel>>(json);
                return chats;
            }
            return null;
        }
        
        /// <summary>
        /// [GET_CHAT_BY_ID]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ChatReadModel> GetChatById(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"Chat/id?id={id}");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                ChatReadModel result = JsonConvert.DeserializeObject<ChatReadModel>(json);
                return result;
            }
            return null;
        }

        /// <summary>
        /// [CREATE_CHAT]
        /// </summary>
        /// <param name="chatCreateModel"></param>
        /// <returns></returns>
        public async Task<ChatReadModel> CreateChat(ChatCreateModel chatCreateModel)
        {
            string json = JsonConvert.SerializeObject(chatCreateModel);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("Chat", content);
            if (response.IsSuccessStatusCode)
            {
                string jsonResult = await response.Content.ReadAsStringAsync();
                ChatReadModel result = JsonConvert.DeserializeObject<ChatReadModel>(jsonResult);
                return result;
            }
            return null;
        }

        /// <summary>
        /// [CHANGE_CHAT]
        /// </summary>
        /// <param name="chatChangeModel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task ChangeChat(ChatChangeModel chatChangeModel)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(chatChangeModel);
            var request = new HttpRequestMessage(HttpMethod.Put, $"{_httpClient.BaseAddress}Chat");
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return;
        }

        /// <summary>
        /// [DELETE_CHAT]
        /// </summary>
        /// <param name="chatDeleteModel"></param>
        /// <returns></returns>
        public async Task DeleteChat(ChatDeleteModel chatDeleteModel)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(chatDeleteModel);
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{_httpClient.BaseAddress}Chat/{chatDeleteModel.id}");
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return;
        }

        /// <summary>
        /// [CLEAR_CHAT]
        /// </summary>
        /// <returns></returns>
        public async Task ClearChat()
        {
            await _httpClient.DeleteAsync($"{_httpClient.BaseAddress}Chat/");
            return;
        }

        #endregion
    }
}
