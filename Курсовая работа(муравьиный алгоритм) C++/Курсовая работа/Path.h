#pragma once
#include <vector>
#include <iostream>

using namespace std;

class Path
{
	double distance;
	vector<size_t> path;
public:
	Path();
	Path(size_t start);
	void getCopy(Path path);
	double getDistance() const;
	size_t stepCount() const;
	size_t operator[](size_t element) const;
	void addStep(size_t location, double distantion);
	bool aVisited(size_t location);//проверяет посещали ли мы переданный город

};