using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textField;
    [SerializeField] private float _moneyCount;

    public static MoneyHandler Instance
    {
        get;
        private set;
    }

    private void Start()
    {
        Instance = this;
        _textField.text = _moneyCount.ToString();
    }

    public bool TrySpendMoney(float v)
    {
        if (v > 0)
            if (_moneyCount >= v)
            {
                _moneyCount -= v;
                Mathf.Round(v);
                _textField.text = _moneyCount.ToString();
                return true;
            }

        return false;
    }

    public void AddMoney(int v)
    {
        if (v > 0)
        {
            _moneyCount += v;
            _textField.text = _moneyCount.ToString();
        }
    }
}
