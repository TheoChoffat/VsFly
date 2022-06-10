using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSFlyWebApi.Models
{
    public class PilotModel
    {
        public int PilotId { get; set; }
        public string FullName { get; set; }
        public DateTime LicenseDate { get; set; }
        
    }
}
