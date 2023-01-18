using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeOpen_Disable : MonoBehaviour
{
    [Header("Components")]
    private Animator anim;
    [SerializeField]
    private GameObject effect_dissipate;
    [SerializeField]
    private GameObject plusMoney;
    [SerializeField]
    private GameObject minusMoney;
    [Header("Variables")]
    public int carriedMoney = 0;
    private void Start()
    {
        effect_dissipate.SetActive(false);
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Johnny"))
        {
            StartCoroutine(SafeAnim("SafeOpen", other.transform, 1f));
            
        }
        else if (other.gameObject.CompareTag("Dog"))
        {
            GameObject clone = Instantiate(minusMoney, new Vector3(other.transform.position.x, other.transform.position.y + 3.5f, other.transform.position.z), Quaternion.identity, other.transform);
            GameManager.Get().score -= carriedMoney;
            gameObject.SetActive(false);
            Destroy(clone, 1);
            effect_dissipate.SetActive(true);
        }

    }

    IEnumerator SafeAnim(string trigger, Transform other, float time) 
    {
        anim.SetTrigger(trigger);
        GameObject clone = Instantiate(plusMoney, new Vector3(other.transform.position.x, other.transform.position.y + 3.5f, other.transform.position.z), Quaternion.identity, other.transform);
        yield return new WaitForSeconds(time);
        Destroy(clone, 1);
        gameObject.SetActive(false);
        effect_dissipate.SetActive(true);
        GameManager.Get().score += carriedMoney;
    }
}
