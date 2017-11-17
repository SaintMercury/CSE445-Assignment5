using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IXmlAccessService" in both code and config file together.
    [ServiceContract]
    public interface IXmlAccessService
    {
        [OperationContract]
        bool AuthenticateMember(string userNameIn, string passwordIn);

        [OperationContract]
        bool AuthenticateStaff(string userNameIn, string passwordIn);

        [OperationContract]
        void RegisterMember(string userName, string password);

        [OperationContract]
        void RegisterStaff(string userName, string password);
    }
}
