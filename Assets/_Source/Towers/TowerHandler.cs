using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using AYellowpaper.SerializedCollections;

public class TowerHandler : MonoBehaviour
{
    [SerializeField] private Transform _pointer;
    [SerializeField] private TowerUI _towerUI;

    [SerializeField] private GameObject _stormtrooperPrefab;
    [SerializeField] private GameObject _rocketPrefab;
    [SerializeField] private GameObject _sniperPrefab;

    [SerializeField] private BulletPool _stormTrpperBulletPool;
    [SerializeField] private BulletPool _rocketBulletPool;
    [SerializeField] private BulletPool _sniperBulletPool;

    [SerializeField] public MoneyHandler _money;

    public static Transform _activeTower;

    [Header("Настройки уровней башей: х - значение, у - цена")]
    [SerializeField] private SerializedDictionary<string, List<Vector2>> _stormtrooperUpgrades;
    [SerializeField] private SerializedDictionary<string, List<Vector2>> _rocketUpgrades;
    [SerializeField] private SerializedDictionary<string, List<Vector2>> _sniperUpgrades;

    public SerializedDictionary<string, List<Vector2>> StormtrooperUpgrades => _stormtrooperUpgrades;
    public SerializedDictionary<string, List<Vector2>> RocketUpgrades => _rocketUpgrades;
    public SerializedDictionary<string, List<Vector2>> SniperUpgrades => _sniperUpgrades;


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (!Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.1f))
                _towerUI.HidePanels();

            if (_activeTower != null)
            {
                _pointer.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _pointer.position = new Vector2(_pointer.position.x, _pointer.position.y);

                _activeTower.right = _pointer.position - _activeTower.position;

                DOTween.To(() => _activeTower.right, x => _activeTower.right = x, _pointer.position - _activeTower.position, 0.3f);
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            _towerUI.HidePanels();

            _pointer.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _pointer.position = new Vector2(_pointer.position.x, _pointer.position.y);

            if (!Physics2D.OverlapCircle(_pointer.position, 0.2f))
            {
                _activeTower = null;
                _towerUI.ShowBuildTowerPanel();
            }
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (_activeTower != null)
                _activeTower.GetComponent<ATower>().ShowPanelWithParams();
        }
    }

    public void BuildTower(Type _towerType)
    {
        GameObject tower = gameObject;
        if (_towerType == typeof(StormtrooperTower))
        {
            if (_money.TrySpendMoney(_stormtrooperPrefab.GetComponent<StormtrooperTower>().Cost))
            {
                tower = Instantiate(_stormtrooperPrefab, _pointer.position, Quaternion.identity);
                tower.GetComponent<ATower>().Construct(_stormTrpperBulletPool, this, _towerUI);
            }
        }
        else if (_towerType == typeof(RocketTower))
        {
            if (_money.TrySpendMoney(_rocketPrefab.GetComponent<RocketTower>().Cost))
            {
                tower = Instantiate(_rocketPrefab, _pointer.position, Quaternion.identity);
                tower.GetComponent<ATower>().Construct(_rocketBulletPool, this, _towerUI);
            }
        }
        else if (_towerType == typeof(SniperTower))
        {
            if (_money.TrySpendMoney(_sniperPrefab.GetComponent<SniperTower>().Cost))
            {
                tower = Instantiate(_sniperPrefab, _pointer.position, Quaternion.identity);
                tower.GetComponent<ATower>().Construct(_sniperBulletPool, this, _towerUI);
            }
        }
        else
        {
            Debug.Log("Wrong type of tower");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_pointer.position, 0.1f);
    }
}