using System;
using System.Collections.Generic;
using System.ServiceModel;
using CnG.Services.Contracts.Dtos;

namespace CnG.Services.Contracts
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        bool Authenticate(string userName, string password);

        [OperationContract]
        Guid Create(UserContract userContract);

        [OperationContract]
        UserContract Get(Guid id);

        [OperationContract]
        IEnumerable<UserContract> GetUsers();
    }
}
