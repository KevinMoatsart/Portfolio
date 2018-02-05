//program name: Account1.cpp
//Author: Kevin Moats
//date last updated: 2/20/16
//purpose: to create a bank account that adds and subtracts balances

#include "Account.h"


int main()
{
	Account account1(26648);
	Account account2(06);

	account1.debit(250);
	account1.credit(500);

	account2.debit(500);
	account2.credit(600);

	cout << account1.getBalance();
	cout << endl;
	cout << account2.getBalance();
	cout << endl;
	
	system("PAUSE");
}

