#pragma once
#include <vector>
#include <random>

#include "Ant.h"
#include "Graph.h"

using namespace std;

class AntHill
{
	const double alpha = 1;//чем выше константа тем сильнее феромон влияет на выбор пути 
	const double beta = 4;//чем выше константа тем сильнее дистанция влияет на выбор пути 
	const double pheromone0 = 1.0;//изначальный феромон 
	const double pheromoneEva = 0.2;//коэффициент испарения феромона
	const double pheromoneAnt = 5;//кол-во феромона в 1 муравье 

	const int ifFoundBetterWay = 100;//количество повторейний без нахождения лучшего пути

	mGraph distance;
	mGraph pheromone;

	random_device rand_dev;
	default_random_engine random_engine;
	vector<Ant*>ants;

	void createAnts(size_t start);
	void pheromoneRenewal();//обновление феромона
public:
	AntHill(size_t size);
	void findBestWay();
	
}; 