using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOAttack : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _fireCooldownTime = 0.3f;

    private void OnEnable()
    {
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        while (enabled)
        {
            Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_fireCooldownTime);
        }
    }
    
}
