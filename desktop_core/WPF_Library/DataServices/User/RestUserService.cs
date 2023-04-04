using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WPF_Library.Models.User;

namespace WPF_Library.DataServices.User
{
    public class RestUserService : IRestUserService
    {
        #region [DATA]

        private readonly HttpClient _httpClient;

        #endregion

        /// <summary>
        /// [CONSTRUCTOR]
        /// </summary>
        public RestUserService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5026/api/");
        }

        #region [INTERFACE IMPLEMENTATION]

        /// <summary>
        /// [GET_ALL_USERS]
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ObservableCollection<UserReadModel>> GetAllUsers()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("User/");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                ObservableCollection<UserReadModel> users = JsonConvert.DeserializeObject<ObservableCollection<UserReadModel>>(json);
                return users;
            }
            return null;
        }

        /// <summary>
        /// [GET_USER_BY_ID]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserReadModel> GetUserById(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"User/id?id={id}");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                UserReadModel user = JsonConvert.DeserializeObject<UserReadModel>(json);
                return user;
            }
            return null;
        }

        /// <summary>
        /// [ADD_USER]
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<UserReadModel> CreateUser(UserCreateModel userCreateModel)
        {
            string json = JsonConvert.SerializeObject(userCreateModel);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("User", content);
            if (response.IsSuccessStatusCode)
            {
                string jsonResult = await response.Content.ReadAsStringAsync();
                UserReadModel result = JsonConvert.DeserializeObject<UserReadModel>(jsonResult);
                return result;
            }
            return null;
        }

        /// <summary>
        /// [CHANGE_USER]
        /// </summary>
        /// <param name="user"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task ChangeUser(UserChangeModel userChangeModel, int id) 
        {
            var json = System.Text.Json.JsonSerializer.Serialize(userChangeModel);
            var request = new HttpRequestMessage(HttpMethod.Put, $"{_httpClient.BaseAddress}User/change/{id}");
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return;
        }


        /// <summary>
        /// [DELETE_USER]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task DeleteUser(UserDeleteModel userDeleteModel)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(userDeleteModel);
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{_httpClient.BaseAddress}User");
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return;
        }

        /// <summary>
        /// [CLEAR_USERS]
        /// </summary>
        /// <returns></returns>
        public async Task ClearUsers()
        {
            await _httpClient.DeleteAsync($"{_httpClient.BaseAddress}User/clearAll");
            return;
        }

        #endregion
    }
}
