using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.Interfaces
{
    public interface IFirebaseLogin
    {
        ServiceAccountCredential ServiceAccountCredential { get; }
        ServiceAccountCredential RenewToken();
    }
}
