using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform_Models : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private GameObject[] clothes = new GameObject[5];
    [SerializeField]
    private GameObject poof;
    [SerializeField]
    private GameObject dog_small;
    [SerializeField]
    private GameObject dog_medium;
    [SerializeField]
    private GameObject dog_large;
    public Transform dogfollow;
    [Header("Variables")]
    private bool transform2casual = false;
    private bool transform2slick = false;
    private bool transform2hobo = false;
    //clothes0 = boxer
    //clothes1 = pants_casual
    //clothes2 = shirt_casual
    //clothes3 = pants
    //clothes4 = jacket
    //clothes5 = shirt_jacket
    //we want johnny to be a hobo at the start
    private void Start()
    {
        foreach (GameObject item in clothes)
        {
            item.gameObject.SetActive(false);
        }
        clothes[0].gameObject.SetActive(true);
        dog_small.SetActive(true);
        dog_medium.SetActive(false);
        dog_large.SetActive(false);
    }

    private void Update()
    {
        StartCoroutine(CheckTransform());
    }
    private bool inRange(int from, int to)
    {
        return GameManager.Get().score >= from && GameManager.Get().score < to;
    }
    
    IEnumerator CheckTransform()
    {
        if (inRange(0, 1000) && !transform2hobo) 
        {
            Hobo();
            transform2hobo = true;
            transform2casual = false;
            transform2slick = false;
        }
        else if (inRange(1000, 3000) && !transform2casual)
        {
            Poof();
            Casual();
            transform2hobo = false;
            transform2casual = true;
            transform2slick = false;
        }
        else if (inRange(3000, 100000) && !transform2slick)
        {
            Poof();
            Slick();
            transform2hobo = false;
            transform2slick = true;
            transform2casual = false;
        }
        yield return new WaitForEndOfFrame();
    }

    private void Hobo()
    {
        clothes[0].gameObject.SetActive(true);
        clothes[1].gameObject.SetActive(false);
        clothes[2].gameObject.SetActive(false);
        clothes[3].gameObject.SetActive(false);
        clothes[4].gameObject.SetActive(false);
        clothes[5].gameObject.SetActive(false);
        dog_small.SetActive(true);
        dog_small.transform.position = new Vector3(dogfollow.transform.position.x, dogfollow.transform.position.y, dogfollow.transform.position.z);
        dog_medium.SetActive(false);
        dog_large.SetActive(false);
        PistolCheck.hasGun = false;
    }
    private void Casual()
    {
        clothes[0].gameObject.SetActive(false);
        clothes[1].gameObject.SetActive(true);
        clothes[2].gameObject.SetActive(true);
        clothes[3].gameObject.SetActive(false);
        clothes[4].gameObject.SetActive(false);
        clothes[5].gameObject.SetActive(false);
        dog_medium.SetActive(true);
        dog_medium.transform.position = new Vector3(dogfollow.transform.position.x, dogfollow.transform.position.y, dogfollow.transform.position.z);
        dog_small.SetActive(false);
        dog_large.SetActive(false);
        PistolCheck.hasGun = false;
    }
    private void Slick()
    {
        clothes[0].gameObject.SetActive(false);
        clothes[1].gameObject.SetActive(false);
        clothes[2].gameObject.SetActive(false);
        clothes[3].gameObject.SetActive(true);
        clothes[4].gameObject.SetActive(true);
        clothes[5].gameObject.SetActive(true);
        dog_large.SetActive(true);
        dog_large.transform.position = new Vector3(dogfollow.transform.position.x, dogfollow.transform.position.y, dogfollow.transform.position.z);
        dog_small.SetActive(false);
        dog_medium.SetActive(false);
        PistolCheck.hasGun = true;
    }

    private void Poof()
    {
        //clone.transform.SetParent(dogfollow.transform);
        GameObject clone = Instantiate(poof, new Vector3(dogfollow.transform.position.x, dogfollow.transform.position.y + 1, dogfollow.transform.position.z + 1), Quaternion.identity);
        GameObject clone2 = Instantiate(poof, new Vector3(-1 * dogfollow.transform.position.x, dogfollow.transform.position.y + 1.5f, dogfollow.transform.position.z + 1), Quaternion.identity);
        Destroy(clone, 1);
        Destroy(clone2, 1);
    }
}
