#include "Ant.h"
#include "Graph.h"
#include "Path.h"
#include <vector>
#include <cmath>
#include <random>

using namespace std;

Ant::Ant(default_random_engine& e, size_t location, bool selected)
: random_engine(e),canMove(true)
{
	if (selected)//муравей начинает или из конкретного города если "selected" == true
	{
		this->location = location;
	}
	else// или выбирает рандомный город 
	{
		uniform_int_distribution<size_t> dis(0, location);
		this->location = dis(random_engine);
	}
	start = this->location;
	path = new Path(this->location);
}

Ant::~Ant()
{
	delete path;
}

size_t Ant::nextStep(const mGraph& pheromone, const mGraph& distance, double alpha, double beta)
{
	uniform_real_distribution<double>rd(0, 1);
	vector<double>aCity;
	vector<double>comp;
	vector<double>probOfChoice;
	double dis,
		pher,
		sumProb = 0,
		randNum,
		chose = 0;

	for (size_t i = 0; i < distance.getSize(); i++)//находим доступные для перехода города
	{
		if (path->stepCount() == distance.getSize() && distance.getLengthOrPheromone(location, start) != 0)
		{
			aCity.push_back(start);
			break;
		}
		if (distance.getLengthOrPheromone(location, i) != 0 && path->aVisited(i) == false)
			aCity.push_back(i);
	}
	if (aCity.empty())
	{
		canMove = false;
		return -1;
	}
	for (size_t i = 0; i < aCity.size(); i++)//находим числитель и знаменатель для подсчета вероятности выбора города
	{
		dis = distance.getLengthOrPheromone(location, aCity[i]);
		pher = pheromone.getLengthOrPheromone(location, aCity[i]);
		comp.push_back(pow(dis, alpha) * pow(pher, beta));
		sumProb += pow(dis, alpha) * pow(pher, beta);
	}
	for (size_t i = 0; i < aCity.size(); i++)//высчитываем вероятность 
	{
		probOfChoice.push_back(comp[i] / sumProb);
	}
	randNum = rd(random_engine);// рандомное число от 0 до 1
	for (size_t i = 0; i < aCity.size(); i++)//выбираем следующий шаг на основе рандомного числа от 0 до 1
	{
		chose += probOfChoice[i];
		if (randNum <= chose)
		{
			path->addStep(aCity[i], distance.getLengthOrPheromone(location, aCity[i]));
			location = aCity[i];
		}
	}
	return location;
}

size_t Ant::getStart()
{
	return start;
}

Path* Ant::getPath() const
{
	return path;
}

bool Ant::canCountinue() const
{
	return canMove;
}
