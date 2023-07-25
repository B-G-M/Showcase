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
	mGraph(size_t mSize);//конструктор для граффа длины путей
	mGraph(mGraph graph, double pheromone0);//конструктор для граффа изначального феромона на путях
	void show();
	void setData(size_t i, size_t j, double data);
	double getLengthOrPheromone(size_t from, size_t to) const;//возвращает длину или количество феромона от точки a до b в зафвисимости от переданного графа 
	size_t getSize() const;
	
};