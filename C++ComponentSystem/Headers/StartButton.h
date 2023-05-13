#pragma once
#include "Button.h"
class StartButton :
	public Button
{
public:
	StartButton(GameObject* parentObject, sf::Texture* normal, sf::Texture* clicked, std::string, sf::Vector2f location);
	void OnButtonClick() override;
};
