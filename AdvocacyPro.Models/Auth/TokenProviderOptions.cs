using System;
using Microsoft.IdentityModel.Tokens;

namespace AdvocacyPro.Models.Auth
{
    public class TokenProviderOptions
    {
        /// The relative request path to listen on.
        /// </summary>

        /// <remarks>The default path is <c>/token</c>.</remarks>
        public string Path { get; set; } = "/api/Auth/token";

        ///  The Issuer (iss) claim for generated tokens.
        /// </summary>

        public string Issuer { get; set; }

        /// The Audience (aud) claim for the generated tokens.
        /// </summary>

        public string Audience { get; set; }

        /// The expiration time for the generated tokens.
        /// </summary>

        /// <remarks>The default is five minutes (300 seconds).</remarks>
        public TimeSpan Expiration { get; set; } = TimeSpan.FromMinutes(60);

        /// The signing key to use when generating tokens.
        /// </summary>

        public SigningCredentials SigningCredentials { get; set; }

    }
}
