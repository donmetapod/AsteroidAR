using UnityEngine;
using UnityEngine.Events;

public class HealthItemsController : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private int _scoreThreshold = 1000;
    [SerializeField] private UnityEvent OnScoreThresholdReached;
    private int _spawnedItems;
    private int _originalScoreThreshold;
    
    private void OnEnable()
    {
        _gameState.OnIncreaseScore.AddListener(ScoreWasIncreased);
        _originalScoreThreshold = _scoreThreshold;
    }

    private void OnDisable()
    {
        _gameState.OnIncreaseScore.RemoveListener(ScoreWasIncreased);
    }

    public void ScoreWasIncreased(int newScore)
    {
        if (newScore > _scoreThreshold)
        {
            OnScoreThresholdReached?.Invoke();
            // _spawnedItems++;
            // _scoreThreshold /= _spawnedItems;
            _scoreThreshold += _originalScoreThreshold;
            Messenger.Instance.EnqueueMessage("Health item created", 5);
        }
    }
}
