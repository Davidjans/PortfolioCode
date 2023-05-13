#include "Button.h"
#include <iostream>
#include "GameManager.h"
#include "BaseStuff.h"
Button::Button(GameObject* parentObject, sf::Texture* normal, sf::Texture* clicked, std::string words, sf::Vector2f location) : Component(parentObject) {
	this->m_Normal.setTexture(*normal);
	this->m_ButtonDown.setTexture(*clicked);
	this->m_CurrentSpr = &this->m_Normal;
	m_Current = false;
	this->m_Normal.setPosition(location);
	this->m_ButtonDown.setPosition(location);
	m_ButtonText = new sf::Text();
	m_ButtonText->setString("cum");
	m_ButtonText->setPosition(location.x + 3, location.y + 3);
	m_ButtonText->setCharacterSize(14);

	m_TempShape = new sf::RectangleShape(sf::Vector2f(200, 100));
	m_TempShape->setFillColor(sf::Color(50, 50, 50, 255));
	m_ParentObject->m_GameManager->m_ThingsToDraw.push_back(m_CurrentSpr);
	//m_ParentObject->m_GameManager->m_ThingsToDraw->push_back(m_ButtonText);
	//m_ParentObject->m_GameManager->m_ThingsToDraw->push_back(m_TempShape);
}
bool Button::CheckOver(sf::Vector2i mousePos) {
	//std::cout << mousePos.x << std::endl << mousePos.y << std::endl;
	if (m_CurrentSpr/*m_TempShape*/->getGlobalBounds().contains(sf::Vector2f(mousePos.x, mousePos.y)))
	{
		return true;
	}
	return false;
}
void Button::setState(bool which) {
	m_Current = which;
	if (m_Current) {
		m_CurrentSpr = &m_ButtonDown;
		return;
	}
	m_CurrentSpr = &m_Normal;
}
void Button::setText(std::string words) {
	m_ButtonText->setString(words);
}
bool Button::getVar() {
	return m_Current;
}
sf::Sprite* Button::getSprite() {
	return m_CurrentSpr;
}

sf::String* Button::getText() {
	return new sf::String(m_ButtonText->getString());
}

void Button::Update()
{
	//m_CurrentSpr->setPosition(sf::Vector2f(*m_ParentObject->m_XPos, *m_ParentObject->m_YPos));
	m_ButtonText->setPosition(sf::Vector2f(m_ParentObject->m_XPos + 3, m_ParentObject->m_YPos + 3));
	m_TempShape->setPosition(sf::Vector2f(m_ParentObject->m_XPos, m_ParentObject->m_YPos));
	if (*m_ButtonState == up)
	{
		*m_ButtonState = normal;
		m_TempShape->setFillColor(sf::Color(50, 200, 50, 255));
	}
	bool buttonPressed = sf::Mouse::isButtonPressed(sf::Mouse::Left);
	if (CheckOver(m_ParentObject->m_GameManager->m_MousePos))
	{
		if (*m_ButtonState == normal && buttonPressed)
		{
			*m_ButtonState = down;
			m_CurrentSpr = &m_ButtonDown;
			m_TempShape->setFillColor(sf::Color(200, 50, 50, 255));
		}
		else if (*m_ButtonState == down && !buttonPressed) {
			*m_ButtonState = up;
			m_CurrentSpr = &m_Normal;
			m_TempShape->setFillColor(sf::Color(50, 200, 50, 255));
			OnButtonClick();
			return;
		}
	}
	else if (*m_ButtonState == down && !buttonPressed)
	{
		*m_ButtonState = normal;
		m_CurrentSpr = &m_Normal;
		m_TempShape->setFillColor(sf::Color(50, 200, 50, 255));
	}
}

void Button::OnButtonClick()
{
}

Button::~Button()
{
	delete m_TempShape;
	delete m_ButtonState;
	delete m_CurrentSpr;
	delete m_ButtonText;
}