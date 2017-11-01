using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Crm.Account.Api.Constant;
using Crm.Account.Api.Service.Exception;
using Crm.Account.Api.Service.Interfaces.Services;
using JWT;
using JWT.Serializers;

namespace Crm.Account.Api.Service.Services
{
    [ExcludeFromCodeCoverage]
    public class EllieJwtService : IEllieJwtService
    {
        public bool Validate(string validingJwt, string encoded64Secret)
        {
            if (string.IsNullOrEmpty(validingJwt))
            {
                throw new MyAuthorizationException(ErrorMessage.JwtEmpty, ErrorCodeCategory.CrmAuthorization.ToString());
            }

            var base64Decode = Base64Decode(encoded64Secret);
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                decoder.Decode(validingJwt, base64Decode, verify: true);
            }
            catch (TokenExpiredException)
            {
                throw new MyAuthorizationException(ErrorMessage.JwtExpired, ErrorCodeCategory.CrmAuthorization.ToString());
            }
            catch (SignatureVerificationException)
            {
                throw new MyAuthorizationException(ErrorMessage.JwtInvalid, ErrorCodeCategory.CrmAuthorization.ToString());
            }
            catch (System.Exception ex)
            {
                throw new MyAuthorizationException(ErrorMessage.JwtUnexpectedException, ErrorCodeCategory.CrmAuthorization.ToString(), ex.InnerException);
            }

            return true;
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
