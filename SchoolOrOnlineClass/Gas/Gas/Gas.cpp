// Program Name: GasMilage
// Author: Kevin Moats
// Date Last Updated: 3/12/16
// Purpose: To receive input and display gas milage and total gas milage

#include "stdafx.h"
#include "Driver.h"
#include <iostream>

using namespace std;


int main()
{
	int count = 1;
	float totalMiles = 0;
	float totalGallons = 0;

	while (count != -1)
	{
		cout << "Enter miles driven (-1 to quit): " << endl;
		int tempM;
		cin >> tempM;
		if (tempM == -1)
			break;
		totalMiles += tempM;
		cout << "Enter gallons used: " << endl;
		int tempG;
		cin >> tempG;
		totalGallons += tempG;

		float mpg = tempM / tempG;
		cout << "Miles per gallon used this trip: " << mpg << endl;

		cout << "Total MPG: " << totalMiles / totalGallons << endl;

		count++;
	}

	cout << "You have exited the program." << endl;
	system("Pause");

}

