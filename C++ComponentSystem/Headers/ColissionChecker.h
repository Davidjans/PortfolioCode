#pragma once
#include <map>
class GameObject;
class Collider;
#include <vector>
#include <iostream>
#include "Enums.h"
class CollisionChecker
{
public:
	// I want to do this with a dictionary/map but i can't quite figure out how to map through it so i'm replacing it with 2 vectors
	std::map<GameObject, Collider> m_CollidersPerObjectMap;
	std::vector<GameObject*> m_GameObjects;
	std::vector<std::vector<Collider*>> m_CollidersPerGameObject;
	std::vector<Enums::Layer> m_Layers;
	std::vector<std::vector<Enums::Layer>> m_LayersItCanCollideWith;
	void CheckWhatCollided();
	CollisionChecker();
	~CollisionChecker();

	static CollisionChecker* GetInstance();
	static CollisionChecker* m_ManagerInstance;
};
