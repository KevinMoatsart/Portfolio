#pragma once

#include <iostream>
#include <string>

using namespace std;


class Data
{

	int day;
	int month;
	int year;

public:
	explicit Data(int setDay, int setMonth, int setYear)
	{
		day = setDay;
		year = setYear;

		if (setMonth > 0 && setMonth <= 12)
			month = setMonth;
		else
			month = 1;
	}

	int getDay()
	{
		return day;
	}

	void setDay(int toSet)
	{
		day = toSet;
	}

	int getMonth()
	{
		return month;
	}

	void setMonth(int toSet)
	{
		if (toSet > 0 && toSet <= 12)
			month = toSet;
	}

	int getYear()
	{
		return year;
	}

	void setYear(int toSet)
	{
		year = toSet;
	}

	void displayData()
	{
		string stringDay = to_string(day);
		string stringMonth = to_string(month);
		string stringYear = to_string(year);
		string seperation = "/";

		cout << stringMonth + seperation + stringDay + seperation + stringYear << endl;
		 
	}








};
