using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private GameState gameState;
    [SerializeField] private Slider _playerHealth;
    [SerializeField] private Slider _planetHealth;
    [SerializeField] private GameObject _gameOverScreen;

    private void OnEnable()
    {
        gameState.OnIncreaseScore.AddListener(UpdateScoreUI);
        gameState.OnGameOver.AddListener(ShowGameOverScreen);
    }
    private void OnDisable()
    {
        gameState.OnIncreaseScore.RemoveListener(UpdateScoreUI);
        gameState.OnGameOver.RemoveListener(ShowGameOverScreen);
    }
    
    public void UpdateScoreUI(int newScore)
    {
        _scoreText.text = $"Score {newScore}";
    }

    public void UpdatePlayerHealthUI(int newHealth)
    {
        _playerHealth.value = newHealth;
    }
    
    public void UpdatePlanetHealthUI(int newHealth)
    {
        _planetHealth.value = newHealth;
    }
    
    public void ShowGameOverScreen()
    {
        _gameOverScreen.SetActive(true);
    }
}
