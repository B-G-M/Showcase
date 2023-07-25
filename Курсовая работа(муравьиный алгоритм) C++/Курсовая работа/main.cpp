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
		cout << "1. Создать рандомную матрицу установвив колво столбцов и строк." << endl
			<< "2. Ввести матрицу вручную." << endl
			<< "3. Использовать готовую маттрицу." << endl
			<< "4. Завершить работу программы." << endl;
		cin >> num;
		if (num == 1)
		{
			system("cls");
			cout << "Введите кол-во столбцов и строк :";
			cin >> mSize;
			if (mSize < 0)
			{
				cout << endl << "Размер матрицы не может быть отрицательным" << endl << endl;
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