using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyWave", menuName = "SO/NewWave")]
public class EnemyWaveSO : ScriptableObject
{
    [SerializeField] public float DelayBeforeWave;
    [SerializeField] public int Enemy1Number;
    [SerializeField] public int Enemy2Number;
    [SerializeField] public int Enemy3Number;
}
