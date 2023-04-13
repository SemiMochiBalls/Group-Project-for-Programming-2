using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_for_Programming_2
{


    public struct DayTime
    {
        private long minutes;

        public DayTime(long minutes)
        {
            this.minutes = minutes;
        }

        public static DayTime operator +(DayTime lhs, int minutes)
        {
            long totalMinutes = lhs.minutes + minutes;
            return new DayTime(totalMinutes);
        }

        public override string ToString()
        {
            long remainingMinutes = minutes % 1440;
            long hours = minutes / 60 % 24;
            long days = minutes / 1440 % 30;
            long months = minutes / 43200 % 12;
            long years = minutes / 518400;

            return $"{years:D4}-{months + 1:D2}-{days + 1:D2} {hours:D2}:{remainingMinutes:D2}";
        }
    }

}
