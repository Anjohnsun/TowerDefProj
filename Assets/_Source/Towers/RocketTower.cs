using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTower : ATower
{
    protected virtual void OnMouseDown()
    {
        TowerHandler._activeTower = transform;
        _towerUI.ShowUpgradePanel("Урон", _towerHandler.RocketUpgrades["bulletSize"][_bulletSizeLevel + 1],
            "Скорострельность", _towerHandler.RocketUpgrades["shootDelay"][_shootDelayLevel + 1],
            "Скорость пуль", _towerHandler.RocketUpgrades["bulletSpeed"][_bulletSpeedLevel + 1], this);
    }

    public override void TryBuyUpgrade(int v)
    {
        switch (v)
        {
            case 0:
                if (_towerHandler._money.TrySpendMoney(_towerHandler.RocketUpgrades["bulletSize"][_bulletSizeLevel + 1].y))
                {
                    _damageLevel++;
                    base.TryBuyUpgrade(v);
                }
                break;
            case 1:
                if (_towerHandler._money.TrySpendMoney(_towerHandler.RocketUpgrades["shootDelay"][_shootDelayLevel + 1].y))
                {
                    _shootDelayLevel++;
                    base.TryBuyUpgrade(v);
                }
                break;
            case 2:
                if (_towerHandler._money.TrySpendMoney(_towerHandler.RocketUpgrades["bulletSpeed"][_bulletSpeedLevel + 1].y))
                {
                    _bulletSpeedLevel++;
                    base.TryBuyUpgrade(v);
                }
                break;
        }
    }

    protected virtual void Shoot()
    {
        base.Shoot();

        var bullet = _bulletPool.GetBullet();
        bullet.gameObject.SetActive(true);
        bullet.Construct(_towerHandler.RocketUpgrades["damage"][_damageLevel].x,
            _towerHandler.RocketUpgrades["bulletSize"][_bulletSizeLevel].x,
            _towerHandler.RocketUpgrades["bulletSpeed"][_bulletSpeedLevel].x,
            transform.position, transform.rotation);
    }
}
