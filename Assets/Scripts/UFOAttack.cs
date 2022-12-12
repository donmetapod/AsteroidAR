using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UFOAttack : MonoBehaviour
{
    // [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _fireCooldownTime = 0.3f;
    [SerializeField] private UnityEvent OnShoot;

    private void OnEnable()
    {
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        while (enabled)
        {
            // Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            OnShoot?.Invoke();
            yield return new WaitForSeconds(_fireCooldownTime);
        }
    }
    
}
