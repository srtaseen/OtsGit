using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WorkingDay
/// </summary>
public class WorkingDay
{
    public WorkingDay()
    {
        //Holiday hd;
        //hd.EidHDayStart = new DateTime(2019, 6, 3);
        //hd.EidHDayEnd = new DateTime(2019, 6, 9);
    }

    private struct Holiday
    {
        public DateTime EidHDayStart;
        public DateTime EidHDayEnd;
    }
    public DateTime GetEndDate(DateTime StartDate, DateTime EndDate)
    {
        DateTime eDate;
        int wDay = 0;
        Holiday hd;
        hd.EidHDayStart = new DateTime(2019, 6, 3);
        hd.EidHDayEnd = new DateTime(2019, 6, 10);

        for (DateTime d = StartDate; d <= EndDate; d = d.AddDays(1))
        {
            if (d >= hd.EidHDayStart && d <= hd.EidHDayEnd)
            {
                wDay++;
                continue;
            }

            if (d.DayOfWeek == DayOfWeek.Friday)               //(d.DayOfWeek != DayOfWeek.Saturday && d.DayOfWeek != DayOfWeek.Sunday)
                wDay++;
        }

        if (wDay == 0)
            eDate = EndDate;
        else
            eDate = GetEndDate(EndDate.AddDays(1), EndDate.AddDays(wDay));

        return eDate;
    }

    public int GetNoDay(DateTime StartDate, DateTime EndDate)
    {
        int wDay = 0;

        for (DateTime d = StartDate; d <= EndDate; d = d.AddDays(1))
        {
            if (d.DayOfWeek == DayOfWeek.Friday)               //(d.DayOfWeek != DayOfWeek.Saturday && d.DayOfWeek != DayOfWeek.Sunday)
                wDay++;
        }

        double totDays = (EndDate - StartDate).TotalDays + 1;
        wDay = (int)totDays - wDay;

        return wDay;
    }
}