using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    [Header("Components")]
    public Animator anim;
    public Transform johnny;
    [Header("Variables")]
    [SerializeField]
    private float clampValue;


    public static DogMovement Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(Instance);
    }
    void Update()
    {
        transform.position = new Vector3(-1 * johnny.position.x, johnny.position.y, johnny.position.z);
        SwerveClamp(gameObject.transform, -clampValue, clampValue);
    }

    private void SwerveClamp(Transform player, float min, float max)
    {
        var xClamp = Mathf.Clamp(player.position.x, min, max);
        player.position = new Vector3(xClamp, player.position.y, player.position.z);
    }


}