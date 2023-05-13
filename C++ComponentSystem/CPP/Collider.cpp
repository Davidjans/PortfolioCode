#include "Collider.h"
#include "GameObject.h"
#include "GameManager.h"
#include <algorithm>
#include "Component.h"
#include <concepts>
void Collider::OnCollisionEnter(Collider* col)
{
	for (size_t i = 0; i < m_ParentObject->m_Components.size(); i++)
	{
		if (CheckIfNotCollider(m_ParentObject->m_Components.at(i))) {
			m_ParentObject->m_Components.at(i)->OnCollisionEnter(col);
		}
	}
}

void Collider::OnCollisionStay(Collider* col)
{
	for (size_t i = 0; i < m_ParentObject->m_Components.size(); i++)
	{
		if (CheckIfNotCollider(m_ParentObject->m_Components.at(i))) {
			m_ParentObject->m_Components.at(i)->OnCollisionStay(col);
		}
	}
}

void Collider::OnCollisionExit(Collider* col)
{
	for (size_t i = 0; i < m_ParentObject->m_Components.size(); i++)
	{
		if (CheckIfNotCollider(m_ParentObject->m_Components.at(i))) {
			m_ParentObject->m_Components.at(i)->OnCollisionExit(col);
		}
	}
}

void Collider::OnTriggerEnter(Collider* col)
{
	for (size_t i = 0; i < m_ParentObject->m_Components.size(); i++)
	{
		if (CheckIfNotCollider(m_ParentObject->m_Components.at(i))) {
			m_ParentObject->m_Components.at(i)->OnTriggerEnter(col);
		}
	}
}

void Collider::OnTriggerStay(Collider* col)
{
	for (size_t i = 0; i < m_ParentObject->m_Components.size(); i++)
	{
		if (CheckIfNotCollider(m_ParentObject->m_Components.at(i))) {
			m_ParentObject->m_Components.at(i)->OnTriggerStay(col);
		}
	}
}

void Collider::OnTriggerExit(Collider* col)
{
	for (size_t i = 0; i < m_ParentObject->m_Components.size(); i++)
	{
		if (CheckIfNotCollider(m_ParentObject->m_Components.at(i))) {
			m_ParentObject->m_Components.at(i)->OnTriggerExit(col);
		}
	}
}

void Collider::Collide(Collider* col)
{
	if (!CheckAlreadyCollidingWithObject(col)) {
		if (m_IsTrigger) {
			OnTriggerEnter(col);
		}
		else {
			OnCollisionEnter(col);
		}
		m_InCollisionWith->push_back(col);
	}
	if (m_IsTrigger) {
		OnTriggerStay(col);
	}
	else {
		OnCollisionStay(col);
	}
}

bool Collider::CheckAlreadyCollidingWithObject(Collider* col)
{
	for (size_t i = 0; i < m_InCollisionWith->size(); i++)
	{
		if (m_InCollisionWith->at(i) == col) {
			return true;
		}
	}
	return false;
}

void Collider::CheckNoCollide(Collider* col)
{
	if (CheckAlreadyCollidingWithObject(col)) {
		if (m_IsTrigger) {
			OnTriggerExit(col);
		}
		else {
			OnCollisionExit(col);
		}
		for (size_t i = 0; i < m_InCollisionWith->size(); i++)
		{
			if (m_InCollisionWith->at(i) == col)
			{
				m_InCollisionWith->erase(m_InCollisionWith->begin() + i);
				return;
			}
		}
	}
}

Collider::Collider(GameObject* parentObject) : Component(parentObject)
{
	CollisionChecker* collisionChecker = CollisionChecker::GetInstance();
	// why the fuck is there not a way to just find or make an extension to do so.
	std::vector<GameObject*>::iterator itr = std::find(collisionChecker->m_GameObjects.begin(),
		collisionChecker->m_GameObjects.end(),
		m_ParentObject);
	if (itr != collisionChecker->m_GameObjects.cend()) {
		//std::cout << "Element present at index " << std::distance(m_ParentObject->m_GameManager->m_CollisionChecker->m_GameObjects->begin(), itr);
		collisionChecker->m_CollidersPerGameObject.at(std::distance(collisionChecker->m_GameObjects.begin(), itr)).
			push_back(this);
	}
	else {
		collisionChecker->m_GameObjects.push_back(m_ParentObject);
		collisionChecker->m_CollidersPerGameObject.push_back(std::vector<Collider*>());
		int indexOfOfColliders = collisionChecker->m_GameObjects.size() - 1;
		collisionChecker->m_CollidersPerGameObject.at(indexOfOfColliders).push_back(this);
	}
}

Collider::~Collider()
{
}

bool Collider::CheckIfNotCollider(Component* thingToCheck)
{
	//bool isCollider = std::is_base_of(typeid(thingToCheck), typeid(Collider)) == true;
	bool isCollider = dynamic_cast<Collider*>(thingToCheck) != nullptr;
	if (!isCollider)
	{
		return true;
	}
	else
		return false;
}