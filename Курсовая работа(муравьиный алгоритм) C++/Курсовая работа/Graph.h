#pragma once
#include <vector>
#include <string>

using namespace std;


class mGraph
{
	size_t size;
	vector<vector<double>> matrix;
public:
	mGraph() = delete;
	mGraph(size_t mSize);//����������� ��� ������ ����� �����
	mGraph(mGraph graph, double pheromone0);//����������� ��� ������ ������������ �������� �� �����
	void show();
	void setData(size_t i, size_t j, double data);
	double getLengthOrPheromone(size_t from, size_t to) const;//���������� ����� ��� ���������� �������� �� ����� a �� b � ������������ �� ����������� ����� 
	size_t getSize() const;
	
};