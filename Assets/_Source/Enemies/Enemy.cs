using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _speed;
    [SerializeField] private int _costHP;
    [SerializeField] private int _costGold;

    [SerializeField] private EnemyRoad _enemyRoad;
    private static EnemyRoad _road;

    public int CostHP => _costHP;

    private void Start()
    {
        if (_road == null) _road = _enemyRoad;
    }

    public void StartMoving()
    {
        transform.position = _road.Points[0];
        MoveToNextPoint(1);
    }

    private void MoveToNextPoint(int pointNumber)
    {
        if (pointNumber < _road.Points.Count)
        {
            float duration = Vector2.Distance(_road.Points[pointNumber - 1], _road.Points[pointNumber]) / _speed;
            transform.DOMove(_road.Points[pointNumber], duration).SetEase(Ease.Flash).OnComplete(() => MoveToNextPoint(pointNumber + 1));
        }
        else
        {
            FinishWay();
        }
    }

    public void Damage(float dmg)
    {
        _health -= dmg;
        if (_health <= 0)
            Dye();
    }

    private void Dye()
    {
        MoneyHandler.Instance.AddMoney(_costGold);
        Destroy(gameObject);

        EnemySpawner._numberOfEnemies--;
        EnemySpawner._OnKilledEnemy(EnemySpawner._numberOfEnemies);
    }

    private void FinishWay()
    {

    }
}
