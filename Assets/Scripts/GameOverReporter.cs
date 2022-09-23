
using UnityEngine;
using UnityEngine.Events;

public class GameOverReporter : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private UnityEvent OnGameOver;
    private void OnEnable()
    {
        _gameState.OnGameOver.AddListener(GameOver);
    }
    private void OnDisable()
    {
        _gameState.OnGameOver.RemoveListener(GameOver);
    }

    void GameOver()
    {
        OnGameOver?.Invoke();
    }
}
