using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthUpdate : MonoBehaviour
{
    [SerializeField]
    playerController playerController;
    // Update is called once per frame
    void Update()
    {
        Text text = gameObject.GetComponent<Text>();
        string health = playerController.Health.ToString();
        text.text = "x " + health;
    }
}
