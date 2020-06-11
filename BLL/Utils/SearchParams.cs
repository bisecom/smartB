using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Utils
{
    public class SearchParams
    {
        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = 10;

        //daily = 1; weekly = 2; monthly = 3
        //public int CalendarView { get; set; } = 2;
        public DateTime firstDateToShowSlots { get; set; }
        public DateTime lastDateToShowSlots { get; set; }
        public int[] employeesIdsArray { get; set; }
        public int BusinessId { get; set; }
        public int WorkingHourId { get; set; }
    }
}
