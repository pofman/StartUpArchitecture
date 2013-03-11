using System.Runtime.Serialization;

namespace CnG.Services.Contracts.Dtos
{
    [DataContract]
    public class AuthenticationDto
    {
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}