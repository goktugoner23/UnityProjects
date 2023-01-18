using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Components")]
    public Image progressfill;
    public Image progressfill_clickcount;
    public Image progressfill_clickcountOutline;
    public Image progressfill_dog;
    public Image text_hobo;
    public Image text_casual;
    public Image text_assassin;
    public Image text_puppy;
    public Image text_retriever;
    public Image text_guarddog;
    public Image swipeToPlay;
    public GameObject scoreText;
    public GameObject finalscoreText;
    public Image _levelPassed;
    public Image scoreImage;
    public NumberCounter counter;
    public GameObject dollarbag;
    public GameObject dollarbag_text;
    [Header("Variables")]
    private float smoothprogress = 0;
    private float smoothprogress_clickcount = 0;
    private bool movingcheck = true;
    public static bool levelPassed;
    public static UIManager Instance;
    private int finalScore;

    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }else Destroy(Instance);
    }
    private void Start()
    {
        progressfill.fillAmount = 0;
        progressfill_clickcount.fillAmount = 0;
        progressfill_clickcount.enabled = false;
        progressfill_clickcountOutline.enabled = false;
        text_hobo.enabled = true;
        text_casual.enabled = false;
        text_assassin.enabled = false;
        _levelPassed.gameObject.SetActive(false);
        scoreImage.enabled = false;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            if (movingcheck)
            {
                JohnnyMovement.Instance.moving = true;
                swipeToPlay.enabled = false;
                movingcheck = false;
            }
            if (BossFight.Instance.bossfight) 
            {
                progressfill_clickcount.enabled = true;
                progressfill_clickcountOutline.enabled = true;
                smoothprogress_clickcount = (float)BossFight.Instance.clickcount / 15f;
                if (progressfill_clickcount.fillAmount < smoothprogress_clickcount)
                {
                    progressfill_clickcount.fillAmount += 1f * Time.deltaTime;
                }
            }
        }
        if (levelPassed)
        {
            finalScore = GameManager.Get().score * (BossFight.Instance.clickcount / 3);
            counter.Value = finalScore;
            finalscoreText.SetActive(true);
            _levelPassed.gameObject.SetActive(true);
            scoreImage.enabled = true;
            dollarbag.SetActive(false);
            dollarbag_text.SetActive(false);
            levelPassed = false;
        }
        smoothprogress = (float)GameManager.Get().score / 5000f;
        if (progressfill.fillAmount < smoothprogress)
        {
            progressfill.fillAmount += 0.001f;
        }
        else progressfill.fillAmount -= 0.001f; //smooth increment
        progressfill_dog.fillAmount = progressfill.fillAmount;
        if (inRange(0, 1000))
        {
            Transform2Hobo(true);
        }
        else if (inRange(1000, 3000))
        {
            Transform2Casual(true);
        }
        else if (inRange(3000, 100000)) 
        {
            Transform2Slick(true);
        }
    }

    private bool inRange(int from, int to)
    {
        return GameManager.Get().score >= from && GameManager.Get().score < to;
    }
    private void Transform2Hobo(bool state) 
    {
        text_hobo.enabled = state;
        text_puppy.enabled = state;
        text_casual.enabled = !state;
        text_retriever.enabled = !state;
        text_assassin.enabled = !state;
        text_guarddog.enabled = !state;
    }
    private void Transform2Casual(bool state) 
    {
        text_hobo.enabled = !state;
        text_puppy.enabled = !state;
        text_casual.enabled = state;
        text_retriever.enabled = state;
        text_assassin.enabled = !state;
        text_guarddog.enabled = !state;
    }
    private void Transform2Slick(bool state) 
    {
        text_hobo.enabled = !state;
        text_puppy.enabled = !state;
        text_casual.enabled = !state;
        text_retriever.enabled = !state;
        text_assassin.enabled = state;
        text_guarddog.enabled = state;
    }
}
