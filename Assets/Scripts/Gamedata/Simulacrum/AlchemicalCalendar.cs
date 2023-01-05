using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class AlchemicalCalendar : Calendar
{
    public override int[] Eras => throw new NotImplementedException();

    public override DateTime AddDays(DateTime time, int days)
    {
        time.AddDays(days);
        //if (time.Month % 3 == 0 && time.Day > 1)
        //{
        //    time.AddDays(-1);
        //    AddMonths(time, 1);
        //}
        return time;
    }

    public override DateTime AddMonths(DateTime time, int months)
    {
        time.AddMonths(months);
        while (time.Month > 18)
        {
            time.AddYears(1);
            time.AddMonths(-18);
        }
        return time;
    }

    public override DateTime AddYears(DateTime time, int years)
    {
        time.AddYears(years);
        return time;
    }

    public override int GetDayOfMonth(DateTime time)
    {
        throw new NotImplementedException();
    }

    public override DayOfWeek GetDayOfWeek(DateTime time)
    {
        throw new NotImplementedException();
    }

    public override int GetDayOfYear(DateTime time)
    {
        int i = 0;
        for (int j = 1; j < time.Month; j++)
        {
            if (j % 3 == 0 && !(j == 9 && !(time.Year % 4 == 0)))
            { i += 1; }
            else
            { i += 30; }
        }

        i += time.Day;
        return i;
    }

    public override int GetDaysInMonth(int year, int month, int era)
    {
        if (month % 3 == 0)
        {
            if (month == 9 && !(year % 4 == 0))
            { return 0; }
            return 1; 
        }
        return 30;
    }

    public override int GetDaysInYear(int year, int era)
    {
        if (year % 4 == 0)
        { return 366; }
        return 365;
    }

    public override int GetEra(DateTime time)
    {
        return 0;
    }

    public override int GetMonth(DateTime time)
    {
        return time.Month;
    }

    public string GetMonthName(DateTime time)
    {
        if (time.Month == 1)
        { return "Fer"; }
        else if (time.Month == 2)
        { return "Mul"; }
        return "";
    }

    public string GetAbbreviatedMonthName(DateTime time)
    {
        if (time.Month == 1)
        { return "♑︎🝱"; }
        else if (time.Month == 2)
        { return "♒︎🝱"; }
        return "";
    }

    public override int GetMonthsInYear(int year, int era)
    {
        if (year % 4 == 0)
        { return 18; }
        return 17;
    }

    public override int GetYear(DateTime time)
    {
        return time.Year;
    }

    public override bool IsLeapDay(int year, int month, int day, int era)
    {
        if (year % 4 == 0 && month == 9 && day == 1)
        { return true; }
        return false;
    }

    public override bool IsLeapMonth(int year, int month, int era)
    {
        if (year % 4 == 0 && month == 9)
        { return true; }
        return false;
    }

    public override bool IsLeapYear(int year, int era)
    {
        if (year % 4 == 0)
        { return true; }
        return false;
    }

    public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era)
    {
        throw new NotImplementedException();
    }
}
