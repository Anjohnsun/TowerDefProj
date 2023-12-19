using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;

    [SerializeField] private List<Bullet> _bullets;

    private void Start()
    {
        _bullets = new List<Bullet>();
    }

    public Bullet GetBullet()
    {
        return GetBulletFromList(); ;
    }

    private Bullet GetBulletFromList()
    {
        /*foreach (Bullet b in _bullets)
        {
            if (!b.gameObject.activeSelf)
            {
                return b;
            }
        }*/

        for (int i = 0; i < _bullets.Count; i++)
        {
            if (!_bullets[i].gameObject.activeSelf)
            {
                return _bullets[i];
            }
        }

        var a = Instantiate(_bulletPrefab).GetComponent<Bullet>();
        _bullets.Add(a);
        a.gameObject.SetActive(false);
        return a;
    }
}
