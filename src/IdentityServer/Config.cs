using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServerAspNetIdentity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("holApi", "HOL REST Api"),
                new ApiResource("ballastWaterApi", "Ballast Water REST Api")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "holSpa",
                    ClientName = "HOL Angular Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = new List<string> {"openid", "profile"},
                    RedirectUris = new List<string> { "http://localhost:4200/assets/oidc-login-redirect.html", "http://localhost:4200/auth-callback", "http://localhost:4200/silent-refresh.html" +
                    "http://deqwebdev/hol_dev/assets/oidc-login-redirect.html", "http://deqwebdev/hol_dev/assets/auth-callback", "http://deqwebdev/hol_dev/assets/silent-refresh.html"},
                    PostLogoutRedirectUris = new List<string> {"http://localhost:4200/"},
                    AllowedCorsOrigins = new List<string> {"http://localhost:4200"},
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    IdentityTokenLifetime = 86400,
                    AccessTokenLifetime = 84600,
                    EnableLocalLogin = false,
                    //AllowRememberConsent = true,
                },
                 new Client
                {
                    ClientId = "ballastWaterSpa",
                    ClientName = "Ballast Water Angular Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = new List<string> {"openid", "profile"},
                    RedirectUris = new List<string> { "http://localhost:4200/assets/oidc-login-redirect.html", "http://localhost:4200/auth-callback", "http://localhost:4200/silent-refresh.html" +
                    "http://deqwebdev/bal_dev/assets/oidc-login-redirect.html", "http://deqwebdev/bal_dev/assets/auth-callback", "http://deqwebdev/bal_dev/assets/silent-refresh.html"},
                    PostLogoutRedirectUris = new List<string> {"http://localhost:4200/"},
                    AllowedCorsOrigins = new List<string> {"http://localhost:4200"},
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    IdentityTokenLifetime = 86400,
                    AccessTokenLifetime = 84600,
                    EnableLocalLogin = false,
                    //AllowRememberConsent = true,
                }
            };
        }
    }
}