#pragma once
#include <iostream>
class GameObject;
#include "Enums.h"
#include <vector>
//template <class T>
class BaseStuff
{
public:
	static float CalculateDistance(float firstX, float firstY, float secondX, float secondY);
	// I really want generics so i can make this work :(
	static int GetIndexOf(std::vector<Enums::Layer> listToCheck, Enums::Layer thingToFind);
};
