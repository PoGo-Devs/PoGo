namespace PoGo.ApiClient
{
    internal static class Constants
    {
        public const string ApiUrl = "https://pgorelease.nianticlabs.com/plfe/rpc";

        public const string LoginUrl = "https://sso.pokemon.com/sso/login?service=https%3A%2F%2Fsso.pokemon.com%2Fsso%2Foauth2.0%2FcallbackAuthorize";
        public const string LoginUserAgent = "niantic";
        public const string LoginOAuthUrl = "https://sso.pokemon.com/sso/oauth2.0/accessToken";

        public const string PtcAuthTicketEventId = "submit";
        public const string PtcOAuthClientId = "mobile-app_pokemon-go";
        public const string PtcOAuthRedirectUri = "https://www.nianticlabs.com/pokemongo/error";
        public const string PtcOAuthClientSecret = "w8ScCUXJQc6kXKw8FiOhd8Fixzht18Dq3PEVkUCP5ZPxtgyWsbTvWHFLm2wNY0JR";
        public const string PtcOAuthGrantType = "refresh_token";

        public const string GoogleOAuthService = "audience:server:client_id:848232511240-7so421jotr2609rmqakceuu1luuq0ptb.apps.googleusercontent.com";
        public const string GoogleOAuthAndroidId = "9774d56d682e549c";
        public const string GoogleOAuthApp = "com.nianticlabs.pokemongo";
        public const string GoogleOAuthClientSig = "321187995bc7cdc2b5fc91b11a96e2baa8602c62";

        public const string HttpClientUserAgent = "Niantic App";
        public const string HttpClientConnection = "keep-alive";
        public const string HttpClientAccept = "*/*";
        public const string HttpClientContentType = "application/x-www-form-urlencoded";

    }
}
