using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    [SerializeField]
    playerController player;
    [SerializeField]
    int duration = 10;
    public int timeRemaining;
    bool isCountingDown = false;

    // Start is called before the first frame update
    void Start()
    {
        Begin();
    }

    void Update()
    {
        Text text = gameObject.GetComponent<Text>();
        text.text = "Time: " + timeRemaining;
    }

    public void Begin()
    {
        if (!isCountingDown)
        {
            isCountingDown = true;
            timeRemaining = duration;
            Invoke("_tick", 1f);
        }
    }

    void _tick()
    {
        timeRemaining--;
        if (timeRemaining > 0)
        {
            Invoke("_tick", 1f);
        }
        else
        {
            isCountingDown = false;
            player.Health = 0;
        }
    }
}
