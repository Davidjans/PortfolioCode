#include "SpriteRender.h"
#include "GameObject.h"
#include "GameManager.h"
void SpriteRender::Update()
{
	m_Drawable->setPosition(sf::Vector2f(m_ParentObject->m_XPos, m_ParentObject->m_YPos));
}

SpriteRender::SpriteRender(GameObject* parentObject, sf::Texture spriteTexture) : Component(parentObject)
{
	m_Drawable = new sf::Sprite();
	m_Drawable->setTexture(spriteTexture);
	m_ParentObject->m_GameManager->m_ThingsToDraw.push_back(m_Drawable);
}