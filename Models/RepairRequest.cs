using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace WebApplication8.Models
{
    public class RepairRequest
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string Device { get; set; }
        public string Problem { get; set; }
        public DateTime CreatedAt { get; set; }
        public RequestStatus Status { get; set; }
    }
}