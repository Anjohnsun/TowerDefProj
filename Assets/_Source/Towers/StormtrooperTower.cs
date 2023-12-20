using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormtrooperTower : ATower
{
    protected virtual void OnMouseDown()
    {
        TowerHandler._activeTower = transform;
    }

    public override void TryBuyUpgrade(int v)
    {
        switch (v)
        {
            case 0:
                if (_towerHandler._money.TrySpendMoney(_towerHandler.StormtrooperUpgrades["damage"][_damageLevel + 1].y))
                {
                    _damageLevel++;
                    base.TryBuyUpgrade(v);
                }
                break;
            case 1:
                if (_towerHandler._money.TrySpendMoney(_towerHandler.StormtrooperUpgrades["shootDelay"][_shootDelayLevel + 1].y))
                {
                    _shootDelayLevel++;
                    base.TryBuyUpgrade(v);
                }
                break;
            case 2:
                if (_towerHandler._money.TrySpendMoney(_towerHandler.StormtrooperUpgrades["bulletSpeed"][_bulletSpeedLevel + 1].y))
                {
                    _bulletSpeedLevel++;
                    base.TryBuyUpgrade(v);
                }
                break;
        }
    }

    protected override void Shoot()
    {
        base.Shoot();

        var bullet = _bulletPool.GetBullet();
        bullet.gameObject.SetActive(true);
        bullet.Construct(_towerHandler.StormtrooperUpgrades["damage"][_damageLevel].x,
            _towerHandler.StormtrooperUpgrades["bulletSize"][_bulletSizeLevel].x,
            _towerHandler.StormtrooperUpgrades["bulletSpeed"][_bulletSpeedLevel].x,
            transform.position, transform.rotation);
    }

}
