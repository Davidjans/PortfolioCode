#include "PlayerMovement.h"
#include "GameObject.h"
#include <Windows.h>
void PlayerMovement::Update()
{
	if (GetKeyState('A') & 0x8000)
	{
		m_ParentObject->m_XPos = m_ParentObject->m_XPos - *m_XSpeed;
	}
	if (GetKeyState('D') & 0x8000)
	{
		m_ParentObject->m_XPos = m_ParentObject->m_XPos + *m_XSpeed;
	}
	if (GetKeyState('S') & 0x8000)
	{
		m_ParentObject->m_YPos = m_ParentObject->m_YPos + *m_YSpeed;
	}
	if (GetKeyState('W') & 0x8000)
	{
		m_ParentObject->m_YPos = m_ParentObject->m_YPos - *m_YSpeed;
	}
}
PlayerMovement::PlayerMovement(GameObject* parentObject, float xSpeed, float ySpeed) : Component(parentObject)
{
	*m_YSpeed = ySpeed;
	*m_XSpeed = xSpeed;
}