using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunRange : MonoBehaviour
{
    public Animator _animJohnny;
    public ParticleSystem _muzzleFlash;
    void Update()
    {
        transform.position = new Vector3(JohnnyMovement.Instance.transform.position.x, JohnnyMovement.Instance.transform.position.y + 3.04f, JohnnyMovement.Instance.transform.position.z + 4.2f);       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC")) 
        {
            if (PistolCheck.hasGun) 
            {
                _animJohnny.SetTrigger("Shoot");
                _muzzleFlash.Play();
            }
        }
    }
}
