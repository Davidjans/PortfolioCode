#include "EnemyManager.h"

#include "Enemy.h"
#include "GameManager.h"
EnemyManager* EnemyManager::m_ManagerInstance = new EnemyManager();

EnemyManager* EnemyManager::GetInstance()
{
	if (m_ManagerInstance == nullptr)
		m_ManagerInstance = new EnemyManager();
	return m_ManagerInstance;
}

void EnemyManager::SpawnEnemy()
{
	Enemy* enemy = new Enemy();
	m_Enemies.push_back(enemy);
}