using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    // These variables allow for bullet upgrades
    public int damage = 1, speed = 10;

    Rigidbody2D rb;

    [SerializeField]
    GameObject bulletHitPrefab;
    [SerializeField]
    GameObject bulletHitAudio;

    // Awake is called when an object enters the hierarchy
    void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
        rb.velocity = transform.TransformDirection(Vector2.up * speed);
    }

    public void IncreaseDamage(int increasedmg)
    {
        damage += increasedmg;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BoundingBox"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy hitEnemy = collision.gameObject.GetComponent<Enemy>();
            hitEnemy.Health -= damage;
            Instantiate(bulletHitPrefab, transform.position, transform.rotation);
            Instantiate(bulletHitAudio, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            bossController hitEnemy = collision.gameObject.GetComponent<bossController>();
            if (!hitEnemy.invunrable)
            {
                hitEnemy.Health -= damage;
            }
            Instantiate(bulletHitPrefab, transform.position, transform.rotation);
            Instantiate(bulletHitAudio, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
