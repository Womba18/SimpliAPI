using Google.Apis.Auth.OAuth2;
using Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class FirebaseLogin : IFirebaseLogin
    {
        public static string databaseName = "simplitest-b2430";
        private static string serviceAccountEmail = "webapi@simplitest-b2430.iam.gserviceaccount.com";
        public ServiceAccountCredential ServiceAccountCredential { get; set; }

        public FirebaseLogin()
        {
            Login();
        }
        private void Login()
        {
            var keyPath = Path.Combine(Environment.CurrentDirectory, "key.p12");
            var certificate = new X509Certificate2(keyPath, "notasecret", X509KeyStorageFlags.Exportable);

            ServiceAccountCredential credential = new ServiceAccountCredential(
               new ServiceAccountCredential.Initializer(serviceAccountEmail)
               {
                   Scopes = new[]
                   {
                        "https://www.googleapis.com/auth/userinfo.email",
                        "https://www.googleapis.com/auth/firebase.database"
                   }
               }
               .FromCertificate(certificate));

            ServiceAccountCredential = credential;
            ServiceAccountCredential.RequestAccessTokenAsync(new System.Threading.CancellationToken()).Wait();
        }

        public ServiceAccountCredential RenewToken()
        {
            if (ServiceAccountCredential.Token.IsExpired(Google.Apis.Util.SystemClock.Default))
            {
                Login();
            }
            return ServiceAccountCredential;
        }
    }
}
