//Program name: simplecalc.cpp
//Author: Kevin Moats
//Date Last Updated: 2/5/16
//Purpose: Print table of integar, its sqaure and cube

#include "stdafx.h"
#include <iostream>

using namespace std;
int num1 = 0;
int num2 = 0;


int main()
{
	for (int x = 0; x < 11; x++)
	{
		cout << x << "	" << x * x << "	" << x * x * x << endl;
	}

	system("PAUSE");

}