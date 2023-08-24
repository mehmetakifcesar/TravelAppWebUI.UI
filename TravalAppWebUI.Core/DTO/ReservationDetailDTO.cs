using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravalAppWebUI.Core.DTO
{
    public class ReservationDetailDTO
    {
        public DateTime DateTime { get; set; }
        public int ReservationID { get; set; }
        public double TotalPrice { get; set; }
        public Guid Guid { get; set; }

    }
}
