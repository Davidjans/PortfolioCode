#pragma once
#include <SFML/Graphics.hpp>
#include "Component.h"
//#include <SFML/Graphics/Sprite.hpp>
// found this code on the interwebs
class Button :
	public Component {
public:
	enum ButtonStates {
		normal,
		down,
		up
	};
	Button(GameObject* parentObject, sf::Texture* normal, sf::Texture* clicked, std::string, sf::Vector2f location);
	bool CheckOver(sf::Vector2i);
	void setState(bool);
	void setText(std::string);
	bool getVar();
	sf::Shape* m_TempShape;
	sf::Sprite* getSprite();
	sf::String* getText();
	void Update() override;
	ButtonStates* m_ButtonState = new ButtonStates(normal);
	virtual void OnButtonClick();
	~Button();
private:
	sf::Sprite m_Normal;
	sf::Sprite m_ButtonDown;
	sf::Sprite* m_CurrentSpr;
	sf::Text* m_ButtonText;
	bool m_Current;
};
