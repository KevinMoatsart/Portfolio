// Program Name: largest
// Author: Kevin Moats
// Last Updated: 3/12/16
// Purpose: To find the largest number in a series of input

#include "stdafx.h"
#include <iostream>

using namespace std;


int main()
{
	int count = 0;
	int largest = 0;

	while (count < 10)
	{
		cout << "Please enter a number: " << endl;
		int number;
		cin >> number;

		if (number > largest)
			largest = number;

		count++;
	}

	cout << "The largest number found was: " << largest << endl;
	system("Pause");
}
