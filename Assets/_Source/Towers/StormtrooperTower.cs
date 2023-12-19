using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormtrooperTower : ATower
{
    protected virtual void OnMouseDown()
    {
        TowerHandler._activeTower = transform;
        _towerUI.ShowUpgradePanel("Урон", _towerHandler.StormtrooperUpgrades["damage"][_damageLevel + 1],
            "Скорострельность", _towerHandler.StormtrooperUpgrades["shootDelay"][_shootDelayLevel + 1],
            "Скорость пуль", _towerHandler.StormtrooperUpgrades["bulletSpeed"][_bulletSpeedLevel + 1], this);
    }

    public override void TryBuyUpgrade(int v)
    {
        switch (v)
        {
            case 0:
                if (_towerHandler._money.TrySpendMoney(_towerHandler.StormtrooperUpgrades["damage"][_damageLevel + 1].y))
                    _damageLevel++;
                break;
            case 1:
                if (_towerHandler._money.TrySpendMoney(_towerHandler.StormtrooperUpgrades["shootDelay"][_shootDelayLevel + 1].y))
                    _shootDelayLevel++;
                break;
            case 2:
                if (_towerHandler._money.TrySpendMoney(_towerHandler.StormtrooperUpgrades["bulletSpeed"][_bulletSpeedLevel + 1].y))
                    _bulletSpeedLevel++;
                break;
        }
    }
}
