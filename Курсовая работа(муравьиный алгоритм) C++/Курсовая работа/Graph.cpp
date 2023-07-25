#include <ctime>
#include<iostream>

#include "Graph.h"

using namespace std;


mGraph::mGraph(size_t mSize)
{
	srand(time(NULL));
	 
	if (mSize == -1)
	{
		this->size = 8;
		vector<vector<double>> arr
		{
			{0,5,8,10,0,0,3,6},
			{5,0,2,0,0,0,0,1},
			{8,2,0,4,5,6,0,7},
			{10,0,4,0,12,9,7,0},
			{0,0,5,12,0,9,0,12},
			{0,0,6,9,9,0,8,0},
			{3,0,0,7,0,8,0,2},
			{6,1,7,0,12,0,2,0}
		};
		this->matrix = arr;
	}
	else if (mSize == -2)
	{
		cout << "¬ведите кол-во столбцов и строк :";
		cin >> size;
		int n = size;
		vector<vector<double>> arr(size, vector<double>(size));

		for (int i = 0; i < size; i++)
		{
			if (n - 1 != 0)
				cout << "¬ведите строку длины " << n - 1 << endl;
			n--;
			for (int j = i; j < size; j++)
			{
				if (i == j)
				{
					arr[i][j] = 0;
				}
				else
				{
					cin >> arr[i][j];
					arr[j][i] = arr[i][j];
				}
			}
		}
		this->matrix = arr;
	}
	else
	{
		this->size = mSize;

		vector<vector<double>> arr(mSize, vector<double>(mSize));

		for (int i = 0; i < mSize; i++)
		{
			for (int j = i; j < mSize; j++)
			{
				if (i == j)
				{
					arr[i][j] = 0;
				}
				else
				{
					arr[i][j] = rand() % 30;
					arr[j][i] = arr[i][j];
				}
			}
		}
		this->matrix = arr;
	}
}

mGraph::mGraph(mGraph graph, double pheromone0)
{
	size = graph.getSize();
	matrix = graph.matrix;

	for (int i = 0; i < size; i++)
	{
		for (int j = i; j < size; j++)
		{
			if (graph.matrix[i][j] != 0)
			{
				this->matrix[i][j] = pheromone0;
				this->matrix[j][i] = this->matrix[i][j];
			}

		}
	}
}

void mGraph::show()
{
	for (size_t i = 0; i < matrix.size(); i++)
	{
		for (size_t j = 0; j < matrix.size(); j++)
		{
			cout << matrix[i][j] << '\t';
		}
		cout << endl;
	}
}

void mGraph::setData(size_t i, size_t j, double data)
{
	matrix[i][j] = data;
}

size_t mGraph::getSize() const
{
	return size;
}

double mGraph::getLengthOrPheromone(size_t from, size_t to) const
{
	return matrix[from][to];
}
