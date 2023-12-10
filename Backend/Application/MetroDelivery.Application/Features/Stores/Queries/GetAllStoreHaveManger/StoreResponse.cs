using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Stores.Queries.GetAllStoreHaveManger
{
    public class StoreResponse
    {
        public Guid StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreLocation { get; set; }
        public TimeSpan? StoreOpenTime { get; set; }
        public TimeSpan? StoreCloseTime { get; set; }
        
        public List<ManagerInformation> ManagerInformation { get; set; }
    }

    public class ManagerInformation
    {
        public string Id { get; set; }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? Created { get; set; }

        public Guid StoreId { get; set; }
    }
}
