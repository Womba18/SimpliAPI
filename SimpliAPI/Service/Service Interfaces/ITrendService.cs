using ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Service.Service_Interfaces
{
    public interface ITrendService
    {
        void GenerateTrends();   
        List<FamilyTrends> FamilyTrends { get; }
    }
}
