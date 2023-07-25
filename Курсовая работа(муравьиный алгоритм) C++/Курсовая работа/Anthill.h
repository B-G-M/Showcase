#pragma once
#include <vector>
#include <random>

#include "Ant.h"
#include "Graph.h"

using namespace std;

class AntHill
{
	const double alpha = 1;//��� ���� ��������� ��� ������� ������� ������ �� ����� ���� 
	const double beta = 4;//��� ���� ��������� ��� ������� ��������� ������ �� ����� ���� 
	const double pheromone0 = 1.0;//����������� ������� 
	const double pheromoneEva = 0.2;//����������� ��������� ��������
	const double pheromoneAnt = 5;//���-�� �������� � 1 ������� 

	const int ifFoundBetterWay = 100;//���������� ����������� ��� ���������� ������� ����

	mGraph distance;
	mGraph pheromone;

	random_device rand_dev;
	default_random_engine random_engine;
	vector<Ant*>ants;

	void createAnts(size_t start);
	void pheromoneRenewal();//���������� ��������
public:
	AntHill(size_t size);
	void findBestWay();
	
}; 