using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperTower : ATower
{
    protected virtual void OnMouseDown()
    {
        TowerHandler._activeTower = transform;
        _towerUI.ShowUpgradePanel("����", _towerHandler.SniperUpgrades["damage"][_damageLevel + 1],
            "����������������", _towerHandler.SniperUpgrades["shootDelay"][_shootDelayLevel + 1],
            "�������� ����", _towerHandler.SniperUpgrades["bulletSpeed"][_bulletSpeedLevel + 1], this);
    }

    public override void TryBuyUpgrade(int v)
    {
        switch (v)
        {
            case 0:
                if (_towerHandler._money.TrySpendMoney(_towerHandler.SniperUpgrades["damage"][_damageLevel + 1].y))
                {
                    _damageLevel++;
                    base.TryBuyUpgrade(v);
                }
                break;
            case 1:
                if (_towerHandler._money.TrySpendMoney(_towerHandler.SniperUpgrades["shootDelay"][_shootDelayLevel + 1].y))
                {
                    _shootDelayLevel++;
                    base.TryBuyUpgrade(v);
                }
                break;
            case 2:
                if (_towerHandler._money.TrySpendMoney(_towerHandler.SniperUpgrades["bulletSpeed"][_bulletSpeedLevel + 1].y))
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
        bullet.Construct(_towerHandler.SniperUpgrades["damage"][_damageLevel].x,
            _towerHandler.SniperUpgrades["bulletSize"][_bulletSizeLevel].x,
            _towerHandler.SniperUpgrades["bulletSpeed"][_bulletSpeedLevel].x,
            transform.position, transform.rotation);
    }
}
