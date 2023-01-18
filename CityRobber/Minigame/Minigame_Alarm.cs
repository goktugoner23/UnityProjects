using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame_Alarm : MonoBehaviour
{
    public GameObject alarm_on;
    public GameObject alarm_off;
    public bool passed;

    private void Start()
    {
        alarm_off.SetActive(false);
        alarm_on.SetActive(true);
    }

    public void CheckIfPassed()
    {
        if (!alarm_on.gameObject.activeSelf && alarm_off.gameObject.activeSelf)
        {
            passed = true;
            gameObject.SetActive(false);
        }
    }
}
