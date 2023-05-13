#include "ShapeRenderer.h"
#include "GameObject.h"
#include "GameManager.h"
void ShapeRenderer::Update()
{
	m_Drawable->setPosition(sf::Vector2f(m_ParentObject->m_XPos, m_ParentObject->m_YPos));
}

ShapeRenderer::ShapeRenderer(GameObject* parentObject) : Component(parentObject)
{
	m_Drawable = new sf::CircleShape();
	m_ParentObject->m_GameManager->m_ThingsToDraw.push_back(m_Drawable);
	sf::CircleShape shape(10.f);
	shape.setFillColor(sf::Color::Green);
	*m_Drawable = shape;
}