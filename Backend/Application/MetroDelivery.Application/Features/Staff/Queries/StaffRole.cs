using MetroDelivery.Application.Features.Customers;
using MetroDelivery.Application.Features.Stations.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Staff.Queries
{
    public class StaffRole
    {
        public string StaffId { get; set; }
        public string RoleId { get; set; }

        public RoleData? RoleData { get; set; }
        public StaffData? StaffData { get; set; }
    }

    public class StaffData
    {
        public string Id { get; set; }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? Created { get; set; }
        public Guid? StoreId { get; set; }
        public StoreData? StoreData { get; set; }
    }

    public class RoleData
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class StaffResponse
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
