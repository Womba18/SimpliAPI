using ApplicationCore.Domain.BusinessDomain;
using ApplicationCore.Domain.Repository_Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util;
using Infrastructure.Repository.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CustomerRepository : IRepository<Customer>
    {
       private IFirebaseLogin _firebaseClient;
       private string path = @"/users/";


        public CustomerRepository(IFirebaseLogin firebaseLogin)
        {
            _firebaseClient = firebaseLogin;
            _firebaseClient.RenewToken();
        }

        public Customer BuildObject()
        {
            throw new NotImplementedException();
        }

        public List<Customer> BuildObjects()
        {
            throw new NotImplementedException();
        }

        public string Create(Customer t)
        {
            throw new NotImplementedException();
        }

        public Customer DeconstructObject()
        {
            throw new NotImplementedException();
        }

        public List<Customer> DeconstructObjects()
        {
            throw new NotImplementedException();
        }

        public string Delete(Customer t)
        {
            throw new NotImplementedException();
        }

        public List<Customer> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Customer Read(string ID)
        {
            HttpWebRequest request = generateHttpRequest(ID);
            WebResponse response = request.GetResponse();
            
            var json = (new StreamReader(response.GetResponseStream())).ReadToEnd();
            var userObject = JsonConvert.DeserializeObject<RepositoryDomain.User>(json);
        
            return userObject?.MapTo(ID);
            //into mesthod later aligator! yir boi!
            //GETALL STUFF RIGHT HERE
            //var temp = JsonConvert.DeserializeObject<Dictionary<string, RepositoryDomain.User>>(json);
            //var cl = new List<Customer>();
            //foreach (var item in temp)
            //{
            //    cl.Add(item.Value.MapTo(item.Key));
            //}
        }

        public string Update(Customer t)
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
