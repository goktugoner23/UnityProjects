using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //singleton
    private static GameManager manager = null;
    public static GameManager Get()
    {
        if (manager == null) manager = (GameManager)FindObjectOfType(typeof(GameManager));
        return manager;
    }

    public int score;
    public int clickcount;
    public GameObject scoretext;
    public Transform target;
    private void Start()
    {
        score = 0;
        Get().score = score;
    }

    private void Update()
    {
        if (score <= 0) score = 0;
        scoretext.GetComponent<TextMeshProUGUI>().text = score.ToString();
        transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z);
    }
}
