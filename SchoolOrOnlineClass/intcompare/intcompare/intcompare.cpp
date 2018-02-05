//Program name: simplecalc.cpp
//Author: Kevin Moats
//Date Last Updated: 2/5/16
//Purpose: Decide which number is bigger or if they're equal

#include "stdafx.h"
#include <iostream>

using namespace std;
int num1 = 0;
int num2 = 0;


int main()
{
	cout << "Please enter a number" << endl;
	cin >> num1;
	cout << "Please enter a second number" << endl;
	cin >> num2;

	if (num1 == num2)
	{
		cout << "These numbers are equal" << endl;
	}
	else if (num1 > num2)
	{
		cout << num1 << " is larger." << endl;
	}
	else
	{
		cout << num2 << "is larger" << endl;
	}

	system("PAUSE");

}

