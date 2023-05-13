#include "MoveGameObject.h"
#include "GameObject.h"
void MoveGameObject::Update()
{
	m_ParentObject->m_XPos = m_ParentObject->m_XPos + *m_XSpeed;
	m_ParentObject->m_YPos = m_ParentObject->m_YPos + *m_YSpeed;
}

MoveGameObject::MoveGameObject(GameObject* parentObject, float xSpeed, float ySpeed) : Component(parentObject)
{
	*m_XSpeed = xSpeed;
	*m_YSpeed = ySpeed;
}

MoveGameObject::~MoveGameObject()
{
	delete m_XSpeed;
	delete m_YSpeed;
}