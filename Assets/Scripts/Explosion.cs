using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Explosion : MonoBehaviour
{
    Animator animator;

    float TimeStart;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.Play("ExplosionAnim");
        TimeStart = Time.time;
    }

    void Update()
    {
        float timeDifference = Time.time - TimeStart;
        if (timeDifference >= 0.333333333f)
        {
            Destroy(gameObject);
        }
    }
}
