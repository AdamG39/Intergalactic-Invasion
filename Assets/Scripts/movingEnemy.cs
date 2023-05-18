using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingEnemy : MonoBehaviour
{
    [SerializeField]
    float speed;

    float dirX = -1f;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Point"))
        {
            dirX *= -1f;
        }
    }
}
