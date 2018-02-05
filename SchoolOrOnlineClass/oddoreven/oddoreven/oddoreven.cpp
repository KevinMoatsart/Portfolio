//Program name: simplecalc.cpp
//Author: Kevin Moats
//Date Last Updated: 2/5/16
//Purpose: Decide and display if a nubmer is even or odd

#include "stdafx.h"
#include <iostream>

using namespace std;
int num1 = 0;
int num2 = 0;


int main()
{
	cout << "Please enter a number" << endl;
	cin >> num1;

	if (num1 % 2 == 0)
	{
		cout << "Even" << endl;
	}
	else
	{
		cout << "Odd" << endl;
	}

	system("PAUSE");

}