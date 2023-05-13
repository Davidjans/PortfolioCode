#include "Enemy.h"
#include "GameManager.h"
#include "CircleCollider.h"
#include "ShapeRenderer.h"
#include "Enums.h"
#include "MoveGameObject.h"
#include "EnemyFunctionality.h"
Enemy::Enemy() : GameObject()
{
	AddComponent(new CircleCollider(this, 10));
	AddComponent(new ShapeRenderer(this));
	AddComponent(new MoveGameObject(this, 0, 0.1f));
	AddComponent(new EnemyFunctionality(this));
	m_ObjectName = "Enemy";
	m_ObjectLayer = Enums::Enemy;
	srand((unsigned int)time(NULL));
	m_XPos = rand() % (GameManager::GetInstance()->m_RenderWindow->getSize().x - 10) + 10;
	m_YPos = 10;
}