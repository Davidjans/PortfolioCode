#include "EnemyFunctionality.h"

#include "GameManager.h"
#include "ScoreManager.h"
EnemyFunctionality::EnemyFunctionality(GameObject* parentObject) : Component(parentObject)
{
}

void EnemyFunctionality::OnCollisionEnter(Collider* col)
{
	m_ParentObject->m_Delete = true;
	ScoreManager::GetInstance()->AddScore(m_ScoreWorth);
}

void EnemyFunctionality::CheckPastDeathZone()
{
	if (m_ParentObject->m_YPos > GameManager::GetInstance()->m_RenderWindow->getSize().y)
	{
		m_ParentObject->m_Delete = true;
		ScoreManager::GetInstance()->AddScore(-m_ScoreWorth);
	}
}
