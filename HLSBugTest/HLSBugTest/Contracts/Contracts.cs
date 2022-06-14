using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HLSBugTest.Contracts
{
    [DataContract]
    public class LoginRequest
    {
        /// <summary>
        /// The username or email address
        /// </summary>
        [DataMember(Name = "login")]
        public string Login { get; set; }

        /// <summary>
        /// The password
        /// </summary>
        [DataMember(Name = "password")]
        public string Password { get; set; }

        /// <summary>
        /// The challenge response object
        /// </summary>
        [DataMember(Name = "challengeResponse")]
        public ChallengeResponse ChallengeResponse { get; set; }


        [DataMember(Name = "strongAuthInitializationKey", IsRequired = false)]
        public string StrongAuthInitKey { get; set; }

        [DataMember(Name = "strongAuthToken", IsRequired = false)]
        public string StrongAuthToken { get; set; }

        /// <summary>
        /// TLD host the request is being made on. Valid examples include "api.draftkings.com", "draftkings.com", "de.draftkings.com", ".draftkings.com"
        /// </summary>
        [DataMember(Name = "host")]
        public string Host { get; set; }
    }
    
    /// <summary>
    /// Response object to a user attempting to log in.
    /// </summary>
    [DataContract]
    public class LoginResponse
    {
        /// <summary>
        /// If login was unsuccessful, this list may include possible challenges that a user can complete in order to successfully log in.
        /// </summary>
        [DataMember(Name = "possibleChallenges")]
        public List<Challenge> PossibleChallenges { get; set; }

        /// <summary>
        /// If populated, this user must finish a strong auth challenge in order to log in.
        /// </summary>
        [DataMember(Name = "strongAuthInitializationKey", IsRequired = false)]
        public string StrongAuthInitializationKey { get; set; }

        /// <summary>
        /// If populated, this user must finish a strong auth challenge in order to log in.
        /// </summary>
        [DataMember(Name = "strongAuthRequest", IsRequired = false)]
        public StrongAuthRequest StrongAuthRequest { get; set; }

        /// <summary>   
        /// If populated, this object indicates that the user successfully logged in but must be redirected to a different top-level domain.
        /// </summary>
        [DataMember(Name = "domainRedirect", IsRequired = false)]
        public DomainRedirect DomainRedirect { get; set; }

        /// <summary>
        /// Error status object that is populated on unsuccessful login attempts
        /// </summary>
        [DataMember(Name = "errorStatus", IsRequired = false)]
        public ErrorStatus ErrorStatus { get; set; }

        /// <summary>
        /// Error status object that is populated on unsuccessful login attempts
        /// </summary>
        [DataMember(Name = "responseStatus", IsRequired = false)]
        public ErrorStatusV4 ResponseStatus { get; set; }
    }
    /// <summary>
    /// Object included in a login or registration response indicating that the user should be redirect to a different top-level domain.
    /// </summary>
    [DataContract]
    public class DomainRedirect
    {
        /// <summary>
        /// Token that can be used to log in the user on the different top-level domain.
        /// </summary>
        [DataMember(Name = "redirectLoginToken")]
        public string RedirectLoginToken { get; set; }

        /// <summary>
        /// The top-level domain that the user should be redirected to.
        /// </summary>
        [DataMember(Name = "loginDomain")]
        public string LoginDomain { get; set; }
    }
    
    /// <summary>
    /// Data class that holds a strong auth request related information
    /// </summary>
    [DataContract]
    public class StrongAuthRequest
    {
        /// <summary>
        /// The Strong Auth type
        /// </summary>
        [DataMember(Name = "strongAuthType")]
        public string StrongAuthType { get; set; }

        /// <summary>
        /// The unique identifier (GUID) associated with the strong auth request
        /// </summary>
        [DataMember(Name = "strongAuthRequestKey")]
        public string StrongAuthRequestKey { get; set; }

        /// <summary>
        /// The contact info associated with the strong auth request
        /// </summary>
        [DataMember(Name = "strongAuthContactInfo")]
        public string StrongAuthContactInfo { get; set; }
    }
    
    [DataContract]
    public class ErrorStatus
    {
        /// <summary>
        /// Error Codes ex. "USR-001"
        /// </summary>
        [DataMember(Name = "code")]
        public string Code { get; set; }

        /// <summary>
        /// Developer Message ex. "Unauthorized request"
        /// </summary>
        [DataMember(Name = "developerMessage")]
        public string DeveloperMessage { get; set; }
    }
    [DataContract]
    public class ErrorStatusV4
    {
        /// <summary>
        /// Error Codes ex. "USR-001"
        /// </summary>
        [DataMember(Name = "errorCode")]
        public string Code { get; set; }

        /// <summary>
        /// Developer Message ex. "Unauthorized request"
        /// </summary>
        [DataMember(Name = "message")]
        public string DeveloperMessage { get; set; }
    }
    
    
    [DataContract]
    public class ChallengeResponse
    {
        /// <summary>
        /// The solution to the challenge
        /// </summary>
        [DataMember(Name = "solution")]
        public string Solution { get; set; }

        /// <summary>
        /// The type of challenge
        /// </summary>
        [DataMember(Name = "type")]
        public ChallengeResponseType Type { get; set; }
    }
    /// <summary>
    /// An enumeration of supported challenge-response types
    /// </summary>
    public enum ChallengeResponseType
    {
        /// <summary>
        /// Unknown challenge response type
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Recaptcha
        /// </summary>
        Recaptcha = 1,

        /// <summary>
        /// HashCash using Sha256 algorithm
        /// </summary>
        HashCashSha256 = 2,

        /// <summary>
        /// RecaptchaV3
        /// </summary>
        RecaptchaV3 = 3
    }
    [DataContract]
    public class Challenge
    {
        /// <summary>
        /// The type of the challenge
        /// </summary>
        [DataMember(Name = "challengeType")]
        public ChallengeResponseType ChallengeType { get; set; }

        /// <summary>
        /// The difficulty of the challenge
        /// </summary>
        [DataMember(Name = "difficulty")]
        public string Difficulty { get; set; }
    }
}
