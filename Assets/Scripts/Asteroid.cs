using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] Transform _sessionOrigin;
    [SerializeField] private Vector3 _initialPosition;
    [SerializeField] private float _distanceFromStartPoint;
    private void Start()
    {
        _initialPosition = transform.position;
    }
    void Update()
    {
        // transform.LookAt(_sessionOrigin);
        _distanceFromStartPoint = Vector3.Distance(_initialPosition, transform.position);
    }
}
