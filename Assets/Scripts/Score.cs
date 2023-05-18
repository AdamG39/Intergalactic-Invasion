using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;

    [SerializeField]
    timer timerScript;

    [SerializeField]
    GameObject[] winAndDefeat;

    [SerializeField]
    Text scoreText;

    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (winAndDefeat[0].activeInHierarchy || winAndDefeat[1].activeInHierarchy)
        {
            score += timerScript.timeRemaining * 50;
            scoreText.text = "Score: " + score.ToString();
            Destroy(gameObject);
        }
        scoreText.text = "Score: " + score.ToString();
    }
}
