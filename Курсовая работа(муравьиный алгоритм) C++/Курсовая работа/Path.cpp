#include <vector>

#include"Path.h"

Path::Path()
{
	distance = 0;
}

Path::Path(size_t start)
{
	path.push_back(start);
	distance = 0;
}

void Path::getCopy(Path path)
{
	this->path = path.path;
	this->distance = path.distance;
}

double Path::getDistance() const
{
	return distance;
}

size_t Path::stepCount() const
{
	return path.size();
}

size_t Path::operator[](size_t element) const
{
	return path[element];
}

void Path::addStep(size_t location, double distantion)
{
	path.push_back(location);
	distance += distantion;
}

bool Path::aVisited(size_t location)
{
	if (find(path.begin(), path.end(), location) == path.end())
		return false;
	else
		return true;
}

