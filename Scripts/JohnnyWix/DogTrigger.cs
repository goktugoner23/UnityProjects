using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DogTrigger : MonoBehaviour
{
    private Animator _animator;
    public static bool busy;
    public Transform johnny;
    public ParticleSystem getmoney;
    //public ParticleSystem getmoneyeffect;
    public ParticleSystem losemoney;
    //public ParticleSystem losemoneyeffect;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetTrigger("Run");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC") || other.gameObject.CompareTag("NPCFighting"))
        {
            _animator.SetTrigger("Attack");
            _animator.SetTrigger("Run");
        }
        if (other.gameObject.CompareTag("Pit_D"))
        {
            _animator.SetTrigger("Dig");
            _animator.SetTrigger("Run");
        }
        else if (other.gameObject.CompareTag("Bone") || other.gameObject.CompareTag("Pit_D"))
        {
            getmoney.Play();
            //getmoneyeffect.Play();
        }
        else if (other.gameObject.CompareTag("Money") || other.gameObject.CompareTag("Safe"))
        {
            losemoney.Play();
            //losemoneyeffect.Play();
        }
        else
        {
            //falling animation
        }
    }

    private void Update()
    {
        if (JohnnyMovement.Instance.moving)
        {
            _animator.SetTrigger("Run");
        }
        else _animator.SetTrigger("Idle");
    }
}
