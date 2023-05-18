using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossBar : MonoBehaviour
{
    public bossController boss;
    public Slider slider;

    // Update is called once per frame
    void Update()
    {
        slider.value = boss.Health;
    }
}
