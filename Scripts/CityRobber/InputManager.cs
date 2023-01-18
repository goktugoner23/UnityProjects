using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public GameObject tap2play;
    public GameObject city1;
    public GameObject city2;
    public GameObject city3;

    private void Awake()
    {
        if (Instance != this)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        States.Instance.state = GameStates.Idle;
        tap2play.SetActive(true);
        city1.SetActive(true);
        city2.SetActive(false);
        city3.SetActive(false);
    }

    private void Update()
    {
        switch (States.Instance.state)
        {
            case GameStates.Idle:
                IdleInput();
                break;
        }
    }

    public void IdleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            States.Instance.state = GameStates.Play;
            tap2play.SetActive(false);
        }
    }
}
