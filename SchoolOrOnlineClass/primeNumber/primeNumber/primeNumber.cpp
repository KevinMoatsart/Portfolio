// Author: Kevin Moats
// Program name: primeNumber.cpp
// Date last updated: 4/29/2016
// Purpose: To print all prime numbers between given values

#include "stdafx.h"
#include <iostream>

using namespace std;

int start = 0;
int endNum = 0;


int main()
{
	cout << "Please enter the beginning number" << endl;
	cin >> start;
	cout << "Please enter the ending number" << endl;
	cin >> endNum;

	//loops through all numbers
	for (int x = 0; x < endNum; x++)
	{
		int count = 0;

		//checks each number for primage
		for (int y = 2; y < x; y++)
		{
			if (x % y == 0)
			{
				count++;
			}

		}
		//if not divisable by any number, spits it out
		if (count == 0)
		{
			cout << x << endl;
		}
	}
		//pause program
	system("PAUSE");
}

