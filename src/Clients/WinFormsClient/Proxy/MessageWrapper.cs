using Newtonsoft.Json;
using WinFormsClient.Proxy.Models;

namespace WinFormsClient.Proxy
{
    internal class MessageWrapper
    {
        private HttpClient _httpClient;

        public MessageWrapper( string host )
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri( host )
            };
        }

        public User? GetUserByEmailOrDefault( string email )
        {
            var response = _httpClient.GetAsync( $"/api/user/email/{email}" ).Result;
            if( response.IsSuccessStatusCode )
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var user = JsonConvert.DeserializeObject<User>( content );
                return user;
            }
            return default;
        }
    }
}
