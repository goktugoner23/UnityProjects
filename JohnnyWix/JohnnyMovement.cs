using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnnyMovement : MonoBehaviour
{
    [Header("Variables")]
    public float speed = 6;
    [SerializeField]
    private float clampValue;
    private Vector2 startPos;
    private Vector2 deltaPos;
    [SerializeField]
    public float swerveSpeed;
    [SerializeField]
    private float swerveSmoothness;

    public static JohnnyMovement Instance;
    public bool moving;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(Instance);
    }
    void Update()
    { 
        if (moving)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                deltaPos = (Vector2)Input.mousePosition - startPos;
                transform.position = new Vector3(Mathf.Lerp(transform.position.x,
                                                            transform.position.x + (deltaPos.x / Screen.width) * swerveSpeed, Time.deltaTime * swerveSmoothness),
                                                            transform.position.y, transform.position.z);
                startPos = Input.mousePosition;
            }
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        SwerveClamp(gameObject.transform, -clampValue, clampValue);
    }

    private void SwerveClamp(Transform player, float min, float max)
    {
        var xClamp = Mathf.Clamp(player.position.x, min, max);
        player.position = new Vector3(xClamp, player.position.y, player.position.z);
    }


}
