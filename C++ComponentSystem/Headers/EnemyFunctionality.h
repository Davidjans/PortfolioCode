#pragma once
#include "Component.h"
class EnemyFunctionality
	:public Component
{
public:
	int m_ScoreWorth = 1;
	EnemyFunctionality(GameObject* parentObject);
	void OnCollisionEnter(Collider* col) override;
	void CheckPastDeathZone();
};
