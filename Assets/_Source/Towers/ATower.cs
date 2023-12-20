using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATower : MonoBehaviour
{
    [SerializeField] public int Cost;

    protected BulletPool _bulletPool;

    [SerializeField] protected int _damageLevel;
    [SerializeField] protected int _bulletSpeedLevel;
    [SerializeField] protected int _bulletSizeLevel;
    [SerializeField] protected int _shootDelayLevel;

    protected float _timeToShoot;
    protected TowerHandler _towerHandler;
    protected TowerUI _towerUI;

    [SerializeField] private AudioSource _shootSound;
    [SerializeField] private AudioSource _upgradeSound;

    private void Start()
    {
        _timeToShoot = _towerHandler.StormtrooperUpgrades["shootDelay"][_shootDelayLevel].x;
    }

    internal void Construct(BulletPool pool, TowerHandler towerHandler, TowerUI towerUI)
    {
        _bulletPool = pool;
        _towerHandler = towerHandler;
        _towerUI = towerUI;
    }

    public virtual void ChangeDrection(Transform target)
    {
        transform.LookAt(target);
    }

    protected virtual void OnMouseDown()
    {
        TowerHandler._activeTower = transform;
    }

    protected void Update()
    {
        _timeToShoot -= Time.deltaTime;
        if (_timeToShoot < 0)
        {
            Shoot();
            _timeToShoot = _towerHandler.StormtrooperUpgrades["shootDelay"][_shootDelayLevel].x;
        }
    }

    protected virtual void Shoot()
    {
        var bullet = _bulletPool.GetBullet();
        bullet.gameObject.SetActive(true);
        bullet.Construct(_towerHandler.StormtrooperUpgrades["damage"][_damageLevel].x,
            _towerHandler.StormtrooperUpgrades["bulletSize"][_bulletSizeLevel].x, 
            _towerHandler.StormtrooperUpgrades["bulletSpeed"][_bulletSpeedLevel].x, 
            transform.position, transform.rotation);

        _shootSound.Play();
    }

    public virtual void TryBuyUpgrade(int v)
    {
        _upgradeSound.Play();
    }

    public virtual void ShowPanelWithParams()
    {
        Debug.Log("show panel");

        _towerUI.ShowUpgradePanel("Урон", _towerHandler.StormtrooperUpgrades["damage"][_damageLevel + 1],
            "Скорострельность", _towerHandler.StormtrooperUpgrades["shootDelay"][_shootDelayLevel + 1],
            "Скорость пуль", _towerHandler.StormtrooperUpgrades["bulletSpeed"][_bulletSpeedLevel + 1], this);
    }
}
