using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject effect_dissipate;
    public GameObject minusMoney;
    public int carriedMoney;

    private void Start()
    {
        effect_dissipate.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Johnny") || other.gameObject.CompareTag("Dog")) 
        {
            GameObject clone = Instantiate(minusMoney, new Vector3(other.transform.position.x, other.transform.position.y + 3.5f, other.transform.position.z), Quaternion.identity, other.transform);
            GameManager.Get().score -= carriedMoney;
            gameObject.SetActive(false);
            Destroy(clone, 1);
            effect_dissipate.SetActive(true);
        }
    }

    
}
