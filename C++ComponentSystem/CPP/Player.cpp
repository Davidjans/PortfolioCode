#include "Player.h"
#include "GameManager.h"
#include "CircleCollider.h"
#include "ShapeRenderer.h"
#include "Enums.h"
#include "PlayerMovement.h"
Player::Player()
{
	AddComponent(new CircleCollider(this, 10));
	AddComponent(new ShapeRenderer(this));
	AddComponent(new PlayerMovement(this, 1, 0));
	m_ObjectName = "Player";
	m_ObjectLayer = Enums::Player;
	m_XPos = GameManager::GetInstance()->m_RenderWindow->getSize().x / 2;
	m_YPos = GameManager::GetInstance()->m_RenderWindow->getSize().y - 20;
}