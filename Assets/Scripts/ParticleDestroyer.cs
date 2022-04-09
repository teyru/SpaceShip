using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy = 1f;

    private void Awake()
    {
        if (_timeToDestroy < 1f) _timeToDestroy = 1f;
    }

    void Start()
    {
        Destroy(gameObject, _timeToDestroy);    
    }
}
