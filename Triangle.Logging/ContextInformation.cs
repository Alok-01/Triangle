
namespace Triangle.Logging
{
    /// <summary>
    /// Context Information Class
    /// </summary>
    public class ContextInformation
    {
        /// <summary>
        /// Host
        /// </summary>
        public string Host { get; set; }
        
        /// <summary>
        /// Method
        /// </summary>
        public string Method { get; set; }
        
        /// <summary>
        /// RemoteIp Address
        /// </summary>
        public string RemoteIpAddress { get; set; }
        
        /// <summary>
        /// Protocol
        /// </summary>
        public string Protocol { get; set; }
        
        /// <summary>
        /// User Information Object
        /// </summary>
        public UserInformation UserInfo { get; set; }
    }
}
