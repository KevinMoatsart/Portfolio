//program name: Account.h
//Author: Kevin Moats
//date last updated: 2/20/16
//purpose: to create a bank account that adds and subtracts balances

#pragma once

//#include "targetver.h"

//#include <stdio.h>
//#include <tchar.h>
#include <string>
#include <iostream>

using namespace std;

class Account
{
	int balance;

public:
	explicit Account(int startingBalance)
	{
		if (startingBalance > 0)
			balance = startingBalance;
		else
		{
			balance = 0;
			displayMessage("Starting balance is invalid, setting balance to zero.");
		}
	}

	void credit(int toCredit)
	{
		balance += toCredit;
	}

	void debit(int toDebit)
	{
		if (toDebit <= balance)
		{
			balance -= toDebit;
		}
		else
		{
			displayMessage("Debit amount exceeded account balance.");
		}
	}

	int getBalance()
	{
		return balance;
	}

public: void displayMessage(string toDisplay)
	{
		cout << toDisplay << endl;
	}







};





// TODO: reference additional headers your program requires here
