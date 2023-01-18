using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JohnnyTrigger : MonoBehaviour
{
    [Header("Components")]
    private Animator _animator;
    public List<string> animtype = new List<string>();
    public ParticleSystem getmoney;
    //public ParticleSystem getmoneyeffect;
    public ParticleSystem losemoney;
    //public ParticleSystem losemoneyeffect;
    [Header("Variables")]
    public static bool busy = false;

    private void Start()
    {
        //hasGun = false;
        //adding animations for different occasions
        animtype.Add("Punch");
        animtype.Add("Kick"); 
        animtype.Add("FistFightA");
        animtype.Add("ShackleA");
        _animator = GetComponent<Animator>();
        _animator.SetTrigger("Run");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            if (!PistolCheck.hasGun)
            {
                _animator.SetTrigger(animtype[Random.Range(0,2)]);
            }
        }
        else if (other.gameObject.CompareTag("Obstacle_J"))
        {
            StartCoroutine(SpeedDamp());
            IEnumerator SpeedDamp()
            {
                Debug.Log("works");
                JohnnyMovement.Instance.speed = 2f;
                yield return new WaitForSeconds(1f);
                JohnnyMovement.Instance.speed = 8f;
            }
        }
        else if (other.gameObject.CompareTag("NPCFighting"))
        {
            _animator.SetTrigger(animtype[2]);
            StartCoroutine(WaitForAnim("Run", 1.8f)); //fight+shoot duration
        }
        else if (other.gameObject.CompareTag("Money") || other.gameObject.CompareTag("Safe"))
        {
            getmoney.Play();
            //getmoneyeffect.Play();
        }
        else if (other.gameObject.CompareTag("Bone") || other.gameObject.CompareTag("Pit_D")) 
        {
            losemoney.Play();
            //losemoneyeffect.Play();
        }
    }

    IEnumerator WaitForAnim(string trigger, float time) 
    {
        JohnnyMovement.Instance.moving = false;
        busy = true;
        yield return new WaitForSeconds(time);
        busy = false;
        _animator.SetTrigger(trigger);
        JohnnyMovement.Instance.moving = true;
    }
}
