using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServeurCShark
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {

        private List<string> pendingUsers = new List<string>();

        public LogResult Auth(string Username)
        {
            pendingUsers.Add(Username);
            LogManager.WriteLogMessage("New pending client: " + Username);
            
            // Add other users for testing
            pendingUsers.Add("Appo");
            pendingUsers.Add("Oliver");
            pendingUsers.Add("God");
            
            return new LogResult(pendingUsers);
        }

        public bool StartSession(string Username)
        {
            return false;
        }

        public bool Send(string Username, string Message)
        {
            LogManager.WriteLogMessage(Username + ": " + Crypto.Decrypt(Message));
            return true;
        }

        public bool EndSession()
        {
            return false;
        }

        public void Logout()
        {

        }



        /*public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }*/

    }
}
