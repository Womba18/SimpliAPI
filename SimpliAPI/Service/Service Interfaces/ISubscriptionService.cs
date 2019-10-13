using ApplicationCore.Domain;
using ApplicationCore.Domain.BusinessDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Service.Service_Interfaces
{
    public interface ISubscriptionService
    {

        Dictionary<string, List<Subscription>> GenerateSubscriptions(string customerID, SearchCriteria searchCriteria);

        string MergeTaskDates(string customerID);

        string MergeProductPackageAndExtras(string customerID, Supplier supplier);

    }
}
