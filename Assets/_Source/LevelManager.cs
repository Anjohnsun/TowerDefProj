using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int _hp;

    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;

    [SerializeField] private AudioSource _winSound;
    [SerializeField] private AudioSource _loseSound;

    private void Start()
    {
        EnemySpawner._OnKilledEnemy += CheckWin;
    }
    public void Win()
    {
        _winPanel.SetActive(true);
        _winSound.Play();
    }

    public void CheckWin(int enemyNumber)
    {
        if (enemyNumber <= 0 && _hp > 0)
            Win();
    }

    public void Lose()
    {
        _losePanel.SetActive(true);
        _loseSound.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            _hp -= collision.gameObject.GetComponent<Enemy>().CostHP;
            if(_hp <= 0)
            {
                Lose();
            }
        }
    }
}
