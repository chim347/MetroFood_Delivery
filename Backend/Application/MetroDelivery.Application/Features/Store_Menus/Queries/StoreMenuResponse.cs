using MetroDelivery.Application.Features.Stations.Queries;
using MetroDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Store_Menus.Queries
{
    public class StoreMenuResponse
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public Guid MenuId { get; set; }
        public string? ApplyDate { get; set; }
        public bool Priority { get; set; }

        public DateTime Create { get; set; }

        public StoreData? StoreData { get; set; }
        public MenuData? MenuData { get; set; }
    }

    /*public class StoreData
    {
        public Guid Id { get; set; }
        public string StoreName { get; set; }
        public string StoreLocation { get; set; }
        public TimeSpan? StoreOpenTime { get; set; }
        public TimeSpan? StoreCloseTime { get; set; }
        public DateTime Create { get; set; }
    }*/

    public class MenuData
    {
        public Guid Id { get; set; }
        public string MenuName { get; set; }
        public TimeSpan StartTimeService { get; set; }
        public TimeSpan EndTimeService { get; set; }
        public DateTime Create { get; set; }
    }

}
