using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public int Health = 3;

    public float moveSpeed = 100f;

    Rigidbody2D rb;
    [SerializeField]
    Transform shootingPoint;

    [SerializeField]
    Rigidbody2D bulletPrefab;
    [SerializeField]
    AudioSource fireSound;
    bool canFire = true;

    Animator animator;

    [SerializeField]
    int speedDuration = 10;
    int speedTimeRemaining;
    bool speedIsCountingDown = false;

    [SerializeField]
    int damageDuration = 10;
    int damageTimeRemaining;
    bool damageIsCountingDown = false;

    [SerializeField]
    GameObject gameOverScreen;

    [SerializeField]
    Score scoreScript;

    // Start is called before the first frame update
    void Start()
    {
        // Sets rb to the Rigidbody2D component attached to this object
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        bulletScript bullet = bulletPrefab.GetComponent<bulletScript>();
        bullet.damage = 1;
        if (Health > 0)
        {
            Time.timeScale = 1;
        }
    }

    // Fixed Update is called every phyisics update
    void FixedUpdate()
    {
        // Sets the rigidbody2D's velocity variable to the pre-defined input axis multiplied by moveSpeed and Time.deltaTime
        rb.velocity = new Vector3(
            Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime,
            Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime
            );
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (canFire)
            {
                Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
                fireSound.Play();
            }
        }

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            animator.SetBool("isMoving", true);
        }

        else
        {
            animator.SetBool("isMoving", false);
        }

        if (Health <= 0)
        {
            Time.timeScale = 0;
            canFire = false;
            gameOverScreen.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Powerup"))
        {
            scoreScript.score -= 25;
        }
    }

    public void speedBegin()
    {
        if (!speedIsCountingDown)
        {
            speedIsCountingDown = true;
            speedTimeRemaining = speedDuration;
            Invoke("_speedTick", 1f);
        }
    }

    void _speedTick()
    {
        speedTimeRemaining--;
        if (speedTimeRemaining > 0)
        {
            Invoke("_speedTick", 1f);
        }
        else
        {
            speedIsCountingDown = false;
            moveSpeed /= 2;
        }
    }

    public void damageBegin()
    {
        if (!damageIsCountingDown)
        {
            damageIsCountingDown = true;
            damageTimeRemaining = damageDuration;
            Invoke("_damageTick", 1f);
        }
    }

    void _damageTick()
    {
        damageTimeRemaining--;
        if (damageTimeRemaining > 0)
        {
            Invoke("_damageTick", 1f);
        }
        else
        {
            damageIsCountingDown = false;
            bulletScript bullet = bulletPrefab.gameObject.GetComponent<bulletScript>();
            bullet.IncreaseDamage(-1);
        }
    }
}
