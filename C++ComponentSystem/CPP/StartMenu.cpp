#include "StartMenu.h"
#include <direct.h>
#include <iostream>
#include "StartButton.h"
#include "GameManager.h"

void StartMenu::LoadScene()
{
	GameObject* object = new GameObject();

	sf::Texture* normalButtonTexture = new sf::Texture();
	sf::Texture* downButtonTexture = new sf::Texture();

	normalButtonTexture->loadFromFile("normalButtonTexture.png");
	downButtonTexture->loadFromFile("downButtonTexture.png");

	object->AddComponent(new StartButton(object, normalButtonTexture, downButtonTexture, std::string("start"), sf::Vector2f(20, 20)));
}

void StartMenu::UnloadScene()
{
}