using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class speedBoost : MonoBehaviour
{
    playerController player;
    [SerializeField]
    GameObject powerupSound;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<playerController>();
            Instantiate(powerupSound, transform.position, transform.rotation);
            player.moveSpeed *= 2;
            player.speedBegin();
            Destroy(gameObject);
        }
    }
}
