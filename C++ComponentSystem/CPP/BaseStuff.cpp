#include "BaseStuff.h"
#include "MathStuff.h"
float BaseStuff::CalculateDistance(float firstX, float firstY, float secondX, float secondY)
{
	float distance;
	float xSquared = MathStuff::Square(secondX - firstX);
	float ySquared = MathStuff::Square(secondY - firstY);
	//distance = sqrt( MathStuff::Square(firstX - secondX) * MathStuff::Square (firstY-secondY));
	distance = MathStuff::SquareRoot(xSquared + ySquared, 0.5f);

	return distance;
}

int BaseStuff::GetIndexOf(std::vector<Enums::Layer> listToCheck, Enums::Layer thingToFind)
{
	for (size_t i = 0; i < listToCheck.size(); i++)
	{
		if (listToCheck.at(i) == thingToFind)
		{
			return i;
		}
	}
	return -1;
}