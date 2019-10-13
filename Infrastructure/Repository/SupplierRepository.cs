using ApplicationCore.Domain.BusinessDomain;
using ApplicationCore.Domain.Repository_Interfaces;
using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Infrastructure.Repository.Interfaces;

namespace Infrastructure.Repository
{

    public class SupplierRepository : IRepository<Supplier>
    {
        private IFirebaseLogin _firebaseClient;
        private string path = @"/suppliers/";

        public SupplierRepository(IFirebaseLogin firebaseLogin)
        {
            _firebaseClient = firebaseLogin;
            _firebaseClient.RenewToken();
        }
        public Supplier BuildObject()
        {
            throw new NotImplementedException();
        }

        public List<Supplier> BuildObjects()
        {
            throw new NotImplementedException();
        }

        public string Create(Supplier t)
        {
            throw new NotImplementedException();
        }

        public Supplier DeconstructObject()
        {
            throw new NotImplementedException();
        }

        public List<Supplier> DeconstructObjects()
        {
            throw new NotImplementedException();
        }

        public string Delete(Supplier t)
        {
            throw new NotImplementedException();
        }

        public Supplier Read(string ID)
        {

            HttpWebRequest request = generateHttpRequest(ID);
            WebResponse response = request.GetResponse();

            var json = (new StreamReader(response.GetResponseStream())).ReadToEnd();
            var userObject = JsonConvert.DeserializeObject<RepositoryDomain.Supplier>(json);

            return userObject.MapTo(ID);
        }

        public List<Supplier> ReadAll()
        {
            HttpWebRequest request = generateHttpRequest();
            WebResponse response = request.GetResponse();

            var json = (new StreamReader(response.GetResponseStream())).ReadToEnd();

            var temp = JsonConvert.DeserializeObject<Dictionary<string, RepositoryDomain.Supplier>>(json);
            var sl = new List<Supplier>();
            foreach (var item in temp)
            {
                sl.Add(item.Value.MapTo(item.Key));
            }
            return sl;

        }

        public string Update(Supplier t)
        {
            throw new NotImplementedException();
        }
        private HttpWebRequest generateHttpRequest(string ID = "", string httpMethod = "GET")
        {
            var request = WebRequest.CreateHttp(String.Format("https://{0}.firebaseio.com{1}{2}.json?access_token={3}", FirebaseLogin.databaseName, path, ID, _firebaseClient.RenewToken().Token.AccessToken));
            request.Method = httpMethod;
            return request;
        }
    }
}
