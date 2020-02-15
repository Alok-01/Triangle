using System.Collections.Generic;

namespace Triangle.Logging
{
    /// <summary>
    /// User Information Class
    /// </summary>
    public class UserInformation
    {
        /// <summary>
        /// User ID
        /// </summary>
        public string UserId { get; set; }
        
        /// <summary>
        /// User Name
        /// </summary>
        public string UserName { get; set; }
        
        /// <summary>
        /// User Claims
        /// </summary>
        public Dictionary<string, List<string>> UserClaims { get; set; }
    }
}
