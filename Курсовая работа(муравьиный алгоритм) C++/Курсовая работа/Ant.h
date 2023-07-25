#pragma once
#include <vector>
#include "Graph.h"
#include "Path.h"
#include <random>

using namespace std;

class Ant
{
	default_random_engine& random_engine;
	size_t start;
	size_t location;
	Path* path;
	bool canMove;
public:
	Ant(default_random_engine& e, size_t location, bool selected);
	~Ant();
	size_t nextStep(const mGraph& pheromone, const mGraph& distance, double alpha, double beta);
	size_t getStart();
	Path* getPath() const;
	bool canCountinue() const;
};
