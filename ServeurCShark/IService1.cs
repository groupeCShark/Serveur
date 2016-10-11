using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServeurCShark
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {

        /*[OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: ajoutez vos opérations de service ici
        */

        [OperationContract]
        LogRes auth(string username);

        [OperationContract]

        bool startSession(string username);

        [OperationContract]
        bool send(string message);

        [OperationContract]
        bool endSession();

        [OperationContract]
        void logout();  

    }


    [DataContract]
    public class LogRes
    {
        bool connectRes = false;
        List<string> userList=new List<string>();

        [DataMember]
        public bool ConnectRes
        {
            get { return connectRes; }
            set { connectRes = value; }
        }

        [DataMember]
        public List<string> UserList
        {
            get { return userList; }
        }

    }



    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    /*[DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
    */
}
