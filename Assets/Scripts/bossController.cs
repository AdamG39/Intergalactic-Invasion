using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossController : MonoBehaviour
{
    public bool invunrable = true;

    public bool waitForWave;
    [SerializeField]
    GameObject[] wave;

    public int Health = 3;
    public float fireSpeed;

    [SerializeField]
    Transform[] shootingPoint;
    [SerializeField]
    Rigidbody2D bulletPrefab;

    [SerializeField]
    GameObject explosionPrefab;
    [SerializeField]
    GameObject explosionAudio;

    public int duration;
    public int timeRemaining;
    public bool isCountingDown = false;

    [SerializeField]
    GameObject winScreen;

    // Start is called before the first frame update
    void Start()
    {
        Begin();
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForWave)
        {
            if (wave[0] == null && wave[1] == null && wave[2] == null && wave[3] == null)
            {
                waitForWave = false;
            }
        }

        if (wave[0] == null && wave[1] == null && wave[2] == null && wave[3] == null && wave[4] == null && wave[5] == null)
        {
            invunrable = false;
        }

        if (Health <= 0)
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Instantiate(explosionAudio, transform.position, transform.rotation);
            winScreen.SetActive(true);
            Time.timeScale = 0;
            Destroy(gameObject);
        }
    }

    public void Begin()
    {
        if (!isCountingDown)
        {
            isCountingDown = true;
            timeRemaining = duration;
            Invoke("_tick", fireSpeed);
        }
    }

    void _tick()
    {
        timeRemaining--;
        if (timeRemaining > 0)
        {
            Invoke("_tick", fireSpeed);
        }
        else
        {
            isCountingDown = false;
            Shoot();
            Begin();
        }
    }

    void Shoot()
    {
        if (!waitForWave) 
        { 
            Instantiate(bulletPrefab, shootingPoint[0].position, shootingPoint[0].rotation);
            Instantiate(bulletPrefab, shootingPoint[1].position, shootingPoint[1].rotation);
            Instantiate(bulletPrefab, shootingPoint[2].position, shootingPoint[2].rotation);
            Instantiate(bulletPrefab, shootingPoint[3].position, shootingPoint[3].rotation);
        }
    }
}
