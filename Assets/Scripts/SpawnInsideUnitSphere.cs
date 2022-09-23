using System.Collections;
using UnityEngine;

public class SpawnInsideUnitSphere : MonoBehaviour
{
    [SerializeField] private float _spawnRange = 20;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _centerReference;
    [SerializeField] private float _minSpawnDistance = 10;
    [SerializeField] private float _spawnDelayTime = 3;
    [SerializeField] private float _minYPos = -10;
    [SerializeField] private float _maxYPos = 10;
    [SerializeField] private bool _onlySpawnInPositiveX;
    
    private float distanceToReferenceCenter;
    private Vector3 _rotationDirection;
    private Vector3 _spawnPosition;
    
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            _spawnPosition = GetSpawnPosition();
            yield return new WaitForSeconds(_spawnDelayTime);
            Vector3 direction = _rotationDirection - _spawnPosition;
            Quaternion rotationDirection = Quaternion.LookRotation(direction, Vector3.up);
            Instantiate(_prefab, _spawnPosition, rotationDirection);
        }
    }

    Vector3 GetSpawnPosition()
    {
        Vector3 newSpawnPosition = Random.insideUnitSphere * _spawnRange;
        
        if (newSpawnPosition.y < _minYPos || newSpawnPosition.y > _maxYPos)
        {
            // Debug.Log($"Y pos {newSpawnPosition.y} is out of range");
            newSpawnPosition.y = Mathf.Clamp(newSpawnPosition.y, _minYPos, _maxYPos);
            // Debug.Log($"Modified Y pos is {newSpawnPosition.y}");    
        }

        if (_onlySpawnInPositiveX)
        {
            newSpawnPosition.x = Mathf.Abs(newSpawnPosition.x);
        }
        
        distanceToReferenceCenter = Vector3.Distance(_centerReference.position, newSpawnPosition);
        if (distanceToReferenceCenter > _minSpawnDistance)
        {
            return newSpawnPosition;
        }
        return GetSpawnPosition();
    }
}
