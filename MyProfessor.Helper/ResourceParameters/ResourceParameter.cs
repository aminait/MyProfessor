using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProfessor.Helpers
{
    public class ResourceParameter
    {
        //Standard Resource Parameters

        const int maxPageSize = 200;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
        public string NameFilter { get; set; }
        public string Fields { get; set; }
        public string Status { get; set; } = "Available";
        public string OrderBy { get; set; } = "Id";
        public string SortingStatus { get; set; }
        public string SearchQuery { get; set; }

        //Users
        public string Roles { get; set; }
        public string CreditType { get; set; }

    }
}
