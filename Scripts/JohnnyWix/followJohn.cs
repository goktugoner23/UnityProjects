using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followJohn : MonoBehaviour
{
    public static followJohn instance;
    public Transform target;
    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
    }
    void Update()
    {
        transform.position = new Vector3(-1 * target.position.x, transform.position.y, target.position.z);
    }
}
