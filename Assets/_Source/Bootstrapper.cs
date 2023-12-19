using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;

    void Start()
    {
        _spawner.StartSpawning();
    }
}
