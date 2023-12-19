using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnFrequancy;

    [SerializeField] private GameObject _enemy1;
    [SerializeField] private GameObject _enemy2;
    [SerializeField] private GameObject _enemy3;

    [SerializeField] private List<EnemyWaveSO> _waves;

    private int _currentWave = 0;
    public static int _numberOfEnemies;
    public static Action<int> _OnKilledEnemy;

    private void Start()
    {
        _numberOfEnemies = 0;
        foreach(var wave in _waves)
        {
            _numberOfEnemies += wave.Enemy1Number;
            _numberOfEnemies += wave.Enemy2Number;
            _numberOfEnemies += wave.Enemy3Number;
        }

        Debug.Log("There are " + _numberOfEnemies + " enemies");
    }

    public void StartSpawning()
    {
        StartCoroutine(RunWave(_currentWave));
    }

    private IEnumerator RunWave(int waveNumber)
    {
        yield return new WaitForSeconds(_waves[waveNumber].DelayBeforeWave);

        var ennum1 = _waves[waveNumber].Enemy1Number;
        var ennum2 = _waves[waveNumber].Enemy2Number;
        var ennum3 = _waves[waveNumber].Enemy3Number;

        while (ennum1 + ennum2 + ennum3 > 0)
        {
            var val = UnityEngine.Random.Range(0, 3);
            switch (val)
            {
                case 0:
                    if (ennum1 > 0)
                    {
                        var enemy = Instantiate(_enemy1).GetComponent<Enemy>();
                        enemy.StartMoving();
                        ennum1--;
                        yield return new WaitForSeconds(_spawnFrequancy);
                    }
                    break;
                case 1:
                    if (ennum2 > 0)
                    {
                        var enemy = Instantiate(_enemy2).GetComponent<Enemy>();
                        enemy.StartMoving();
                        ennum2--;
                        yield return new WaitForSeconds(_spawnFrequancy);
                    }
                    break;
                case 2:
                    if (ennum3 > 0)
                    {
                        var enemy = Instantiate(_enemy3).GetComponent<Enemy>();
                        enemy.StartMoving();
                        ennum3--;
                        yield return new WaitForSeconds(_spawnFrequancy);
                    }
                    break;
            }
        }

        _currentWave++;
        if (_currentWave < _waves.Count)
            yield return StartCoroutine(RunWave(_currentWave));
    }
}
