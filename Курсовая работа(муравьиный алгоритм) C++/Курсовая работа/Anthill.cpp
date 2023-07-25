#include <random>

#include "Anthill.h"
#include "Ant.h"
#include "Graph.h"

AntHill::AntHill(size_t size) : 
distance(size),
pheromone(distance, pheromone0),
rand_dev(),
random_engine(rand_dev())
{}

void AntHill::createAnts(size_t start)
{
	Ant* ant = new Ant(random_engine, start, true);
	ants.push_back(ant);
}

void AntHill::pheromoneRenewal()
{
	int k;
	Path *path;
	vector<vector<double>> evolvedPher(pheromone.getSize(), vector<double>(pheromone.getSize()));
	vector<vector<size_t>> numOfVisits(pheromone.getSize(), vector<size_t>(pheromone.getSize()));
	for (size_t i = 0; i < pheromone.getSize(); i++)
	{
		k = ants[i]->getStart();
		path = ants[i]->getPath();
		for (size_t j = 0; j < path->stepCount(); j++)
		{
			evolvedPher[k][(*path)[j]] += pheromoneAnt / distance.getLengthOrPheromone(k, (*path)[j]);
			numOfVisits[k][(*path)[j]] += 1;
		}
	}
	for (size_t i = 0; i < evolvedPher.size(); i++)
	{
		for (size_t j = 0; j < evolvedPher.size(); j++)
		{
			pheromone.setData(i, j, (pheromone.getLengthOrPheromone(i, j) * (1 - pheromoneEva)) + numOfVisits[i][j] * evolvedPher[i][j]);
		}
	}
}

void AntHill::findBestWay()
{
	double bestLength = INFINITY;
	Path bestPath;

	for (size_t i = 0; i < ifFoundBetterWay; i++)
	{
		for (size_t j = 0; j < pheromone.getSize(); j++)
		{
			createAnts(j);
		}
		for (size_t j = 0; j < pheromone.getSize(); j++)
		{
			for (size_t k = 0; k < pheromone.getSize(); k++)
			{
				if (ants[j]->canCountinue())
				{
					ants[j]->nextStep(pheromone, distance, alpha, beta);
				}
				else
				{
					break;
				}
			}
		}
		for (size_t j = 0; j < ants.size(); j++)
		{
			if (ants[j]->getPath()->getDistance() < bestLength && ants[j]->getPath()->stepCount() == pheromone.getSize() + 1)
			{
				bestLength = ants[j]->getPath()->getDistance();
				bestPath.getCopy(*ants[j]->getPath());
				i = 0;
			}
		}
		pheromoneRenewal();
		for (size_t j = 0; j < ants.size(); j++)
		{
			delete ants[j];
		}
		ants.clear();
	}

	if (bestPath.getDistance() == 0)
	{
		cout << endl << "Путь не найден.";
	}
	else
	{
		distance.show();

		cout << "Лучший путь:	";
		for (size_t i = 0; i < bestPath.stepCount(); i++)
		{
			if ((i + 1) == bestPath.stepCount())
				cout << bestPath[i];
			else
				cout << bestPath[i] << " => ";
		}
		cout << endl << "Пройденная дистанция = " << bestLength;
	}
	
}

