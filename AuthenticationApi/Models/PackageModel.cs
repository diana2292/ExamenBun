using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.Models
{
    public class PackageModel
    {
        [Required]
        public string OriginCountry { get; set; }
        [Required]
        public string DestinationCountry { get; set; }
        [Required]
        public string ContactPerson { get; set; }
        [Required]
        public string ContactAddress { get; set; }
        [Required]
        public string Shipper { get; set; }
        [Required]
        public double Cost { get; set; }
        public string TrackingNumber { get; set; }
    }
}
