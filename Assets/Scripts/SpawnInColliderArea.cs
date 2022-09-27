using System.Collections;
using UnityEngine;

public class SpawnInColliderArea : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Collider _collider;
    [SerializeField] private float _spawnDelayTime = 1;
    [SerializeField] private GameState _gameState;
    private Vector3 _spawnPosition;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (!_gameState.GameOver)
        {
            _spawnPosition = GetSpawnPosition();
            GameObject clone = Instantiate(_prefab, _spawnPosition, Quaternion.identity);
            clone.name = $"{clone.name} {clone.GetInstanceID()}";
            yield return new WaitForSeconds(_spawnDelayTime);
        }
    }

    Vector3 GetSpawnPosition()
    {
        return new Vector3(Random.Range(_collider.bounds.min.x, _collider.bounds.max.x),
            Random.Range(_collider.bounds.min.y, _collider.bounds.max.y), 
            Random.Range(_collider.bounds.min.z, _collider.bounds.max.z));
    }
}
