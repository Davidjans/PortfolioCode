#pragma once
#include "Enemy.h"

class EnemyManager
{
public:
	static EnemyManager* GetInstance();
	static EnemyManager* m_ManagerInstance;
	void SpawnEnemy();
	std::vector<Enemy*> m_Enemies;

};

