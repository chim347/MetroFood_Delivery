using MetroDelivery.Application.Features.Menus.Queries;
using MetroDelivery.Application.Features.OrderDetails.Queries;
using MetroDelivery.Application.Features.Stations.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Menu_Products
{
    public class MenuProductResponse
    {
        public Guid Id { get; set; }
        public Guid MenuID { get; set; }
        public Guid ProductID { get; set; }
        public double? PriceOfProductBelongToTimeService { get; set; }
        public DateTime? Created { get; set; }

        public MenuResponse? MenuData { get; set; }
        public ProductData? ProductData { get; set; }
        public StoreData? StoreData { get; set; }
    }

    public class MenuProductResponseData
    {
        public MenuResponse? MenuData { get; set; }

        public List<MenuProductResponse> MenuProductData { get; set; }
    }
}
