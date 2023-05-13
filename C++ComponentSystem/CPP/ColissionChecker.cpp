#include "ColissionChecker.h"
#include "CircleCollider.h"
#include "BaseStuff.h"
#include <iostream>
#include "GameObject.h"
#include "Collider.h"
#include <iterator>
#include "Enums.h"
#include "Collider.h"
CollisionChecker* CollisionChecker::m_ManagerInstance = new CollisionChecker();

CollisionChecker* CollisionChecker::GetInstance()
{
	if (m_ManagerInstance == nullptr)
		m_ManagerInstance = new CollisionChecker();
	return m_ManagerInstance;
}

void CollisionChecker::CheckWhatCollided()
{
	for (size_t one = 0; one < m_GameObjects.size(); one++)
	{
		for (size_t two = 0; two < m_CollidersPerGameObject.at(one).size(); two++)
		{
			for (size_t loopThree = 0; loopThree < m_GameObjects.size(); loopThree++)
			{
				if (loopThree == one)
					continue;
				bool canHitLayer = false;
				int index = BaseStuff::GetIndexOf(m_Layers, m_GameObjects.at(one)->m_ObjectLayer);
				if (index == -1) {
					break;
				}

				int secondIndex = BaseStuff::GetIndexOf(m_LayersItCanCollideWith.at(index), m_GameObjects.at(loopThree)->m_ObjectLayer);

				if (secondIndex != -1) {
					canHitLayer = true;
					//std::cout << "can hit this layer" << std::endl;
				}
				else
				{
					//std::cout << "could not hit this layer" << std::endl;
					break;
				}

				for (size_t Four = 0; Four < m_CollidersPerGameObject.at(loopThree).size(); Four++)
				{
					// for now i'm only gonna do this with circle colliders so that's the only check i will have here.
					Collider* tempColOne = m_CollidersPerGameObject.at(one).at(two);
					Collider* tempColTwo = m_CollidersPerGameObject.at(loopThree).at(Four);
					CircleCollider colOne = *dynamic_cast<CircleCollider*>(tempColOne);
					CircleCollider colTwo = *dynamic_cast<CircleCollider*>(tempColTwo);
					float distance = BaseStuff::CalculateDistance(colOne.m_ParentObject->m_XPos, colOne.m_ParentObject->m_YPos,
						colTwo.m_ParentObject->m_XPos, colTwo.m_ParentObject->m_YPos);

					if (distance - (*colOne.m_Radius + *colTwo.m_Radius) < 0) {
						colOne.Collide(m_CollidersPerGameObject.at(loopThree).at(Four));
						//std::cout << *colOne->m_ParentObject->m_ObjectName << " HIT " << *colTwo->m_ParentObject->m_ObjectName << std::endl;
					}
					else {
						colOne.CheckNoCollide(m_CollidersPerGameObject.at(loopThree).at(Four));
						//std::cout << *colOne->m_ParentObject->m_ObjectName << " MISSED " << *colTwo->m_ParentObject->m_ObjectName << std::endl;
					}
					//if()
				}
			}
		}
	}
}

CollisionChecker::CollisionChecker()
{
	m_Layers.push_back(Enums::Default);
	m_Layers.push_back(Enums::Player);
	m_Layers.push_back(Enums::Enemy);
	m_Layers.push_back(Enums::Enviroment);
	for (size_t i = 0; i < m_Layers.size(); i++)
	{
		m_LayersItCanCollideWith.push_back(std::vector<Enums::Layer>());
		m_LayersItCanCollideWith.at(i).push_back(Enums::Default);
		m_LayersItCanCollideWith.at(i).push_back(Enums::Player);
		m_LayersItCanCollideWith.at(i).push_back(Enums::Enemy);
		m_LayersItCanCollideWith.at(i).push_back(Enums::Enviroment);
	}

	for (auto& objectColliderPair : m_CollidersPerObjectMap)
	{
		//objectColliderPair
	}
}

CollisionChecker::~CollisionChecker()
{
}