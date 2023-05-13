#include <SFML/Graphics.hpp>
#include "GameManager.h"
#include "BaseStuff.h"
#include "CircleCollider.h"
#include "MoveGameObject.h"
#include "SpriteRender.h"
#include "PlayerMovement.h"
#include "StartMenu.h"
#include "GameScene.h"

static GameManager* m_GameManager;
static sf::RenderWindow* m_RenderWindow;
int main()
{
	m_GameManager = GameManager::GetInstance();

	m_RenderWindow = new sf::RenderWindow(sf::VideoMode(1920, 900), "SFML works!");

	m_GameManager->m_RenderWindow = m_RenderWindow;

	m_GameManager->LoadScene(new StartMenu());

	while (m_RenderWindow->isOpen())
	{
		m_RenderWindow->clear();
		m_GameManager->Update();
		sf::Event event;
		while (m_RenderWindow->pollEvent(event))
		{
			if (event.type == sf::Event::Closed)
				m_RenderWindow->close();
		}
		for (size_t i = 0; i < m_GameManager->m_ThingsToDraw.size(); i++)
		{
			m_RenderWindow->draw(*m_GameManager->m_ThingsToDraw.at(i));
		}

		m_RenderWindow->display();
	}

	return 0;
}