#pragma once
#include "Component.h"
#include <SFML/Graphics.hpp>
class SpriteRender :
	public Component
{
public:
	void Update() override;
	sf::Sprite* m_Drawable;
	SpriteRender(GameObject* parentObject, sf::Texture spriteTexture);
};
