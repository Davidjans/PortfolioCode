#include "GameScene.h"
#include "GameObject.h"
#include "PlayerMovement.h"
#include "CircleCollider.h"
#include "ShapeRenderer.h"
#include "Enemy.h"
#include "Player.h"
#include "ScoreManager.h"
#include "GameManager.h"
#include "EnemyManager.h"
void GameScene::LoadScene()
{
	auto player = new Player();
	EnemyManager::GetInstance()->SpawnEnemy();
	ScoreManager::GetInstance()->SetScore(0);
	ScoreManager::GetInstance()->EnableScoreDisplay();
}

void GameScene::UnloadScene()
{
	ScoreManager::GetInstance()->DisableScoreDisplay();
}

void GameScene::Update()
{
	BaseScene::Update();
}
