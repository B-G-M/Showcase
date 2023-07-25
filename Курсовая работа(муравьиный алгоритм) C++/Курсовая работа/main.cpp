#include <iostream>
#include <ctime>

#include "Anthill.h"

using namespace std;

int main()
{
	setlocale(LC_ALL, "ru");
	srand(time(NULL));
	int mSize,
		num;
	while (true)
	{
		cout << "1. ������� ��������� ������� ���������� ����� �������� � �����." << endl
			<< "2. ������ ������� �������." << endl
			<< "3. ������������ ������� ��������." << endl
			<< "4. ��������� ������ ���������." << endl;
		cin >> num;
		if (num == 1)
		{
			system("cls");
			cout << "������� ���-�� �������� � ����� :";
			cin >> mSize;
			if (mSize < 0)
			{
				cout << endl << "������ ������� �� ����� ���� �������������" << endl << endl;
				continue;
			}
			else
			{
				AntHill AntHill(mSize);
				AntHill.findBestWay();
				cout << endl << endl << endl;
			}
		}
		else if (num == 2)
		{
			system("cls");
			AntHill AntHill(-2);
			AntHill.findBestWay();
			cout << endl << endl << endl;
		}
		else if (num == 3)
		{
			system("cls");
			AntHill AntHill(-1);
			AntHill.findBestWay();
			cout << endl << endl << endl;
		}
		else if (num == 4)
			break;
	}
	return 0;
}