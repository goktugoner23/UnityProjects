using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame_Donut : MonoBehaviour
{
    public GameObject differentDonut;
    public bool passed;

    private void Start()
    {
        differentDonut.SetActive(true);
    }

    public void CheckIfPassed()
    {
        if (!differentDonut.activeSelf)
        {
            passed = true;
            gameObject.SetActive(false);
        }
    }
}
