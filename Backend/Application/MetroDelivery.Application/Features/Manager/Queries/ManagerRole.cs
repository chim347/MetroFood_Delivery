using MetroDelivery.Application.Features.Customers;
using MetroDelivery.Application.Features.Staff.Queries;
using MetroDelivery.Application.Features.Stations.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Manager.Queries
{
    public class ManagerRole
    {
        public string ManagerId { get; set; }
        public string RoleId { get; set; }

        public RoleData? RoleData { get; set; }
        public MangerData? MangerData { get; set; }
    }

    public class MangerData
    {
        public string Id { get; set; }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime? Birthday { get; set; }
        public Guid? StoreId { get; set; }
        public DateTime? Created { get; set; }
        public StoreData? StoreData { get; set; }
    }

    public class ManagerResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime? Birthday { get; set; }

        public DateTime? Created { get; set; }
    }
}
