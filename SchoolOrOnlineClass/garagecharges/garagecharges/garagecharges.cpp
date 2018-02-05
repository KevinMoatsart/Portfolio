// garagecharges.cpp
// Author: Kevin Moats
// Date Last Updated: 4/16/16
// Purpose: To calculate and display parking charges

#include "stdafx.h"
#include <iostream>

using namespace std;
//prototyping
float calculateCharges(float _hours);
void displayInformation(int _maxCars, float _hours[], float _cost[], float _acchours, float _accCost);

//handling user input
int main()
{
	cout << "Enter how many cars you would like to add." << endl;
	//data values//
	int maxCars = 0;
	int count = 0;
	float totalCost[100] = {};
	float totalHours[100] = {};
	float accCost = 0;
	float accHours = 0;

	cin >> maxCars;

	while (count < maxCars)
	{
		cout << "Please enter time spent at the parking garage for vehicles: " << count + 1 << endl;
		cin >> totalHours[count];
		accHours += totalHours[count];
		totalCost[count] = calculateCharges(totalHours[count]);
		accCost += totalCost[count];
		count++;
	}


	displayInformation(maxCars, totalHours, totalCost, accHours, accCost);

	//pauses to see information
	system("Pause");
}

//calculates charges per hour
float calculateCharges(float _hours)
{
	
	float totalCharge = 0;
	if (_hours > 0)
		totalCharge += 2;
	if (_hours >= 24)
	{
		totalCharge = 10;
	}
	else if (_hours > 3)
	{
		float temp = _hours - 3;
		temp /= 2;
		totalCharge += temp;
	}
	return totalCharge;
}

//displays the final information
void displayInformation(int _maxCars, float _hours[], float _cost[], float _acchours, float _accCost)
{
	int count = 0;
	cout << "cars" << "       " << "Hours" << "       " << "Charge" << endl;
	while (count < _maxCars)
	{
		cout << count + 1 << "          " << _hours[count] << "           " << _cost[count] << endl;
		count++;
	}
	cout << "TOTAL" << "          " << _acchours << "           " << _accCost << endl;
}










