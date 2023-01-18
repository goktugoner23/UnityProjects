using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossFight_Dog : MonoBehaviour
{
    public Animator _animDog;
    public Transform bosspoint;
    public Transform boss;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            _animDog.SetTrigger("Idle");
        }
    }

    private void Update()
    {
        if (BossFight.Instance.bossfight)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _animDog.SetTrigger("Boss_Attack");
                gameObject.transform.LookAt(new Vector3(boss.position.x, boss.position.y, boss.position.z));
            }
        }
    }
}
