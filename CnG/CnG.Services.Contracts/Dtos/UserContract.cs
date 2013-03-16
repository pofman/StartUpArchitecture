using System;
using System.Runtime.Serialization;

namespace CnG.Services.Contracts.Dtos
{
    [DataContract]
    public class UserContract
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }
    }
}