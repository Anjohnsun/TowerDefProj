using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour
{
    [SerializeField] private TowerHandler _towerHandler;

    [SerializeField] private RectTransform _buildTowerPanel;
    [SerializeField] private RectTransform _upgradePanel;

    [SerializeField] private List<TextMeshProUGUI> _buttons;

    [SerializeField] private float _animDuration;
    private ATower _tower;
    public void ShowBuildTowerPanel()
    {
        HidePanels();
        _buildTowerPanel.gameObject.SetActive(true);
    }

    public void HidePanels()
    {
        _buildTowerPanel.gameObject.SetActive(false);
        _upgradePanel.gameObject.SetActive(false);
    }

    public void BuildTower(int v)
    {
        switch (v)
        {
            case 0:
                _towerHandler.BuildTower(typeof(StormtrooperTower));
                break;
            case 1:
                _towerHandler.BuildTower(typeof(RocketTower));
                break;
            case 2:
                _towerHandler.BuildTower(typeof(SniperTower));
                break;
        }
        HidePanels();
    }

    public void ShowUpgradePanel(string tag1, Vector2 values1, string tag2, Vector2 values2, string tag3, Vector2 values3, ATower tower)
    {
        _upgradePanel.gameObject.SetActive(true);
        _buttons[0].text = $"{tag1} за {values1.y}";
        _buttons[1].text = $"{tag2} за {values2.y}";
        _buttons[2].text = $"{tag3} за {values3.y}";

        _tower = tower;
    }

    public void TryBuyUpgrade(int v)
    {
        _tower.TryBuyUpgrade(v);
    }

    public void LoadScene(int v)
    {
        if (v == 0)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(1);
    }
}
