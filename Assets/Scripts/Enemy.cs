using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    public bool waitForWave;
    [SerializeField]
    GameObject[] wave;

    public int Health = 3;
    public float fireSpeed;

    [SerializeField]
    Transform shootingPoint;
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
    AudioSource fireSound;

    [SerializeField]
    GameObject customDrop;

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
        if (Health <= 0)
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Instantiate(explosionAudio, transform.position, transform.rotation);
            if (customDrop != null)
            {
                Instantiate(customDrop, transform.position, transform.rotation);
            }
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
            Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
            fireSound.Play();
        }
    }
}
