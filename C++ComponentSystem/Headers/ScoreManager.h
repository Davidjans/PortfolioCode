#pragma once
#include <SFML/Graphics.hpp>
class ScoreManager
{
private:
	int m_Score = 0;
	sf::Text* m_ScoreText;
	void SetScoreText();
	sf::Font* m_Font = new sf::Font();
public:

	void SetScore(int ammountToSet);
	int GetScore();
	void AddScore(int ammountToAdd);
	void EnableScoreDisplay();
	void DisableScoreDisplay();

	ScoreManager();
	~ScoreManager();

	static ScoreManager* GetInstance();
	static ScoreManager* m_ManagerInstance;
};
