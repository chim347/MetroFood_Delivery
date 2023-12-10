using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Stations
{
    public class StationDto
    {
        public Guid Id { get; set; }

        [ForeignKey("Store")]
        public Guid StoreID { get; set; }

        public string StationName { get; set; }
    }
}
