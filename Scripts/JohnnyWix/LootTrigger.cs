using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTrigger : MonoBehaviour
{
    [SerializeField]
    private string lootOwner;
    [SerializeField]
    private int carriedMoney = 0;
    public GameObject plusMoney;
    public GameObject minusMoney;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(lootOwner))
        {
            GameManager.Get().score += carriedMoney;
            if (gameObject.CompareTag("Gun_J"))
            {
                PistolCheck.hasGun = true;
            }
            GameObject clone = Instantiate(plusMoney, new Vector3(transform.position.x, transform.position.y + 3.5f, transform.position.z), Quaternion.identity, followJohn.instance.target);
            gameObject.SetActive(false);
            Destroy(clone, 1);
        }
        else if (other.gameObject.CompareTag("Dog") && gameObject.CompareTag("Money"))
        {
            GameManager.Get().score -= carriedMoney;
            GameObject clone = Instantiate(minusMoney, new Vector3(transform.position.x, transform.position.y + 3.5f, transform.position.z), Quaternion.identity, followJohn.instance.target);
            gameObject.SetActive(false);
            Destroy(clone, 1);
        }
        else if (other.gameObject.CompareTag("Johnny") && gameObject.CompareTag("Bone")) 
        {
            GameManager.Get().score -= carriedMoney;
            GameObject clone = Instantiate(minusMoney, new Vector3(transform.position.x, transform.position.y + 3.5f, transform.position.z), Quaternion.identity, followJohn.instance.target);
            gameObject.SetActive(false);
            Destroy(clone, 1);
        }
        else if (other.gameObject.CompareTag("Johnny") && gameObject.CompareTag("Pit_D"))
        {
            GameManager.Get().score -= carriedMoney;
            GameObject clone = Instantiate(minusMoney, new Vector3(transform.position.x, transform.position.y + 3.5f, transform.position.z), Quaternion.identity, followJohn.instance.target);
            gameObject.SetActive(false);
            Destroy(clone, 1);
        }
    }
}
