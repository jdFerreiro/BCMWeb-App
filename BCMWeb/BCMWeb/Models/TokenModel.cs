using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCMWeb.Models
{
    public class TokenModel : GenericModel
    {
        private string acessToken;

        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken
        {
            get { return acessToken; }
            set { acessToken = value; }
        }

        private string tokenType;

        [JsonProperty(PropertyName = "token_type")]
        public string TokenType
        {
            get { return tokenType; }
            set { tokenType = value; }
        }

        private int expiresIn;

        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn
        {
            get { return expiresIn; }
            set { expiresIn = value; }
        }

    }
}
