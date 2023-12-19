using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float Damage;
    [SerializeField] private float Size;
    [SerializeField] private float Speed;

    public void Construct(float damage, float size, float speed, Vector2 position, Quaternion rotation) 
    {
        Damage = damage;
        Size = size;
        Speed = speed;

        transform.position = position;
        transform.rotation = rotation;

        transform.localScale = new Vector2(Size, Size);

        gameObject.SetActive(true);
    }

    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            collision.gameObject.GetComponent<Enemy>().Damage(Damage);
        }
        else if (collision.gameObject.layer == 7)
        {
            gameObject.SetActive(false);
        }
    }
}
