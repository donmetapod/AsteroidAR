using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class UFOSaucer : MonoBehaviour
{
    public enum UFOStates
    {
        Idle, 
        Attacking
    }

    [SerializeField] private UFOStates _currentState;
    [SerializeField] private Transform _player;
    [SerializeField] private float _spawnDistanceFromPlayer = 20;
    [SerializeField] private List<Vector3> _trajectoryVectors = new List<Vector3>();
    [SerializeField] private float _xyOffset = 10;
    [SerializeField] private int _trajectoriesPerSpawn = 2;
    [SerializeField] private float _movementSpeed = 5;
    [SerializeField] private AudioSfx _ufoOnScene;
    [SerializeField] private int _cooldownMinTime = 5;
    [SerializeField] private int _cooldownMaxTime = 15;
    [SerializeField] private bool _spawnMysteryBoxOnDeath;
    [SerializeField] private GameObject _mysteryBox;
    [SerializeField] private GameState _gameState;
    [SerializeField] private UnityEvent OnStartAttacking;
    [SerializeField] private UnityEvent OnStopAttacking;
    [SerializeField] private UnityEvent OnDie;
    
    
    public UFOStates CurrentState
    {
        get => _currentState;
        set
        {
            _currentState = value;
            if (_currentState == UFOStates.Attacking)
            {
                OnStartAttacking?.Invoke();    
            }
            else
            {
                OnStopAttacking?.Invoke();
            }
        }
    }
    
    private void Start()
    {
        GameObject playerObject = GameObject.Find("Player");
        if (playerObject)
        {
            _player = playerObject.transform;
        }
        CurrentState = UFOStates.Idle;
    }
    
    public void StartAttacking()
    {
        if (_player == null)
            return;
        
        // Define spawn position
        Vector3 spawnPosition = GetNewPositionVector();
        transform.position = spawnPosition;
        
        // Define random trajectory vectors
        for (int i = 0; i < _trajectoriesPerSpawn; i++)
        {
            _trajectoryVectors.Add(GetNewPositionVector());
        }

        // Play UFO sfx
        _ufoOnScene.PlayAudio(gameObject);
        
        StartCoroutine(AttackMovement());
    }

    // Returns a new random position for spawning and trajectory vectors using _xyOffset
    Vector3 GetNewPositionVector()
    {
        return new Vector3(Random.Range(-_xyOffset, _xyOffset),
            Random.Range(-_xyOffset, _xyOffset),
            _player.position.z + _spawnDistanceFromPlayer);
    }

    IEnumerator AttackMovement()
    {
        for (int i = 0; i < _trajectoryVectors.Count; i++)
        {
            float distance = Vector3.Distance(transform.position, _trajectoryVectors[i]);
            while (distance > 0.5f && !_gameState.GameOver)
            {
                yield return null;
                transform.position = Vector3.MoveTowards(transform.position, _trajectoryVectors[i], Time.deltaTime * _movementSpeed);
                distance = Vector3.Distance(transform.position, _trajectoryVectors[i]);
            }
        }
        CurrentState = UFOStates.Idle;
    }

    public void StartCooldown()
    {
        StartCoroutine(IdleRoutine());
    }

    private IEnumerator IdleRoutine()
    {
        transform.position = new Vector3(1000, 1000, 1000);
        _trajectoryVectors.Clear();
        yield return new WaitForSeconds(Random.Range(_cooldownMinTime, _cooldownMaxTime));
        CurrentState = UFOStates.Attacking;
    }
    
    public void Die()
    {
        StopAllCoroutines();
        Health health = GetComponent<Health>();
        health.CurrentHealth = health.MaxHealth;
        StartCooldown();
        if (_spawnMysteryBoxOnDeath)
        {
            Instantiate(_mysteryBox, transform.position, Quaternion.identity);
        }
        _ufoOnScene.StopAudio();
        OnDie?.Invoke();
    }
}
