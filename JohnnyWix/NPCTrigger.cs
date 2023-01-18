using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    private Animator _animator;
    public int carriedMoney = 0;
    public GameObject plusMoney;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("NPCFighting"))
        {
            if (other.gameObject.CompareTag("Johnny"))
            {
                _animator.SetTrigger("FistFightB");
                Die();
                GameObject clone = Instantiate(plusMoney, new Vector3(other.transform.position.x, other.transform.position.y + 3.5f, other.transform.position.z), Quaternion.identity, followJohn.instance.target);
                Destroy(clone, 1);
            }
            else if (other.gameObject.CompareTag("Dog"))
            {
                Die();
                GameObject clone = Instantiate(plusMoney, new Vector3(other.transform.position.x, other.transform.position.y + 3.5f, other.transform.position.z), Quaternion.identity, followJohn.instance.target);
                Destroy(clone, 1);
            }
        }
        else if (other.gameObject.CompareTag("Johnny") || other.gameObject.CompareTag("Dog"))
        {
            Die();
            GameObject clone = Instantiate(plusMoney, new Vector3(other.transform.position.x, other.transform.position.y + 3.5f, other.transform.position.z), Quaternion.identity, followJohn.instance.target);
            Destroy(clone, 1);
        }
        else if (other.gameObject.CompareTag("gunRange")) 
        {
            if (PistolCheck.hasGun) 
            {
                Die();
                GameObject clone = Instantiate(plusMoney, new Vector3(other.transform.position.x, other.transform.position.y + 3.5f, other.transform.position.z), Quaternion.identity, followJohn.instance.target);
                Destroy(clone, 1);
            }
            
        }
    }

    private void Die()
    {
        _animator.SetTrigger("Death");
        GameManager.Get().score += carriedMoney;
        gameObject.GetComponent<Collider>().enabled = false;
    }
}
