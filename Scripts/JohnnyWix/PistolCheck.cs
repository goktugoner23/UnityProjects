using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolCheck : MonoBehaviour
{
    [Header("Components")]
    public GameObject _gun;
    [Header("Variables")]
    public static bool hasGun;

    private void Start()
    {
        hasGun = false;
        _gun.SetActive(false);
    }

    private void Update()
    {
        if (hasGun)
        {
            _gun.SetActive(true);
        }
        else 
        {
            _gun.SetActive(false);
        }
    }

    
}
