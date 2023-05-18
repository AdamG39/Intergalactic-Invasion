using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public int damage = 1, speed = 10;

    Rigidbody2D rb;

    [SerializeField]
    GameObject bulletHitPrefab;
    [SerializeField]
    GameObject bulletHitAudio;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.TransformDirection(Vector2.up * speed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BoundingBox"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            playerController player = collision.gameObject.GetComponent<playerController>();
            player.Health -= damage;
            Instantiate(bulletHitPrefab, transform.position, transform.rotation);
            Instantiate(bulletHitAudio, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
