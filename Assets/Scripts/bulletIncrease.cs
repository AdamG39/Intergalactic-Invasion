using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class bulletIncrease : MonoBehaviour
{
    playerController player;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    GameObject powerupSound;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<playerController>();
            bulletScript bullet = bulletPrefab.gameObject.GetComponent<bulletScript>();
            Instantiate(powerupSound, transform.position, transform.rotation);
            bullet.IncreaseDamage(1);
            player.damageBegin();
            Destroy(gameObject);
        }
    }
}
