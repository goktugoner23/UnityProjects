using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame_Cars : MonoBehaviour
{
    public GameObject car1;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;
    public GameObject car5;
    public bool passed;

    private void Start()
    {
        GameObject car = RandomizeDirection();
        car.transform.Rotate(new Vector3(0, 180, 0));
        car.GetComponent<ItemClickHandler>().flipped = true;
    }

    private GameObject RandomizeDirection()
    {
        GameObject car = new GameObject();
        int a = Random.Range(0,5);
        switch (a)
        {
            case 0:
                car = car1;
                break;
            case 1:
                car = car2;
                break;
            case 2:
                car = car3;
                break;
            case 3:
                car = car4;
                break;
            case 4:
                car = car5;
                break;
            default:
                car = null;
                break;
        }
        return car;
    }

    public void CheckIfPassed()
    {
        if (car1.GetComponent<ItemClickHandler>().flipped == false && car2.GetComponent<ItemClickHandler>().flipped == false &&
            car3.GetComponent<ItemClickHandler>().flipped == false && car4.GetComponent<ItemClickHandler>().flipped == false &&
            car5.GetComponent<ItemClickHandler>().flipped == false) 
        {
            passed = true;
            gameObject.SetActive(false);
        }
    }
}
