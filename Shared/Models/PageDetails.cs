using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsTrack.Shared.Models
{
    public class PageDetails
    {
        public int PageNumber { get; set; } 
        public int PageSize { get; set; } = 5;
        public string SortBy { get; set; }
        public int SortingDirection{ get; set; }
        public string Search { get; set; }
    }
}
