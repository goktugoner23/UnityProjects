using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobButtonInteract : MonoBehaviour, IInteractible_Button
{
    #region Fields
    [Header("Components")]
    public GameObject minigame;
    [SerializeField]
    private GameObject shop;
    #endregion

    #region Functions
    public void Interact() //on-click
    {
        if (shop.GetComponent<RobInteract>().reqKeyCount <= PlayerUpgrades.Instance.ownedKeyCount)
        {
            gameObject.SetActive(false);
            minigame.gameObject.SetActive(true);
        }
    }

    public void Closed()
        //close minigame without passing
    {
        minigame.gameObject.SetActive(false);
        States.Instance.state = GameStates.Idle; //back to idle
    }

    public void CheckWin() //check if the game is won
    {
        if (minigame.GetComponent<Minigame_KeyLocks>() != null)
        {
            if (minigame.GetComponent<Minigame_KeyLocks>().passed)
            {
                PlayerUpgrades.Instance.ownedKeyCount -= shop.GetComponentInChildren<RobInteract>().reqKeyCount;
                Closed();
            }
        }
        else if (minigame.GetComponent<Minigame_Diamonds>() != null) 
        {
            if (minigame.GetComponent<Minigame_Diamonds>().passed)
            {
                PlayerUpgrades.Instance.ownedKeyCount -= shop.GetComponentInChildren<RobInteract>().reqKeyCount;
                Closed();
            }
        }
        else if (minigame.GetComponent<Minigame_Cars>() != null)
        {
            if (minigame.GetComponent<Minigame_Cars>().passed)
            {
                PlayerUpgrades.Instance.ownedKeyCount -= shop.GetComponentInChildren<RobInteract>().reqKeyCount;
                Closed();
            }
        }
        else if (minigame.GetComponent<Minigame_Alarm>() != null)
        {
            if (minigame.GetComponent<Minigame_Alarm>().passed)
            {
                PlayerUpgrades.Instance.ownedKeyCount -= shop.GetComponentInChildren<RobInteract>().reqKeyCount;
                Closed();
            }
            //minigame.GetComponent<Minigame_Alarm>().passed = false;
            //minigame.GetComponent<Minigame_Alarm>().alarm_off.SetActive(false);
            //minigame.GetComponent<Minigame_Alarm>().alarm_on.SetActive(true);
        }
        else if (minigame.GetComponent<Minigame_Donut>() != null)
        {
            if (minigame.GetComponent<Minigame_Donut>().passed)
            {
                PlayerUpgrades.Instance.ownedKeyCount -= shop.GetComponentInChildren<RobInteract>().reqKeyCount;
                Closed();
            }
            minigame.GetComponent<Minigame_Donut>().differentDonut.SetActive(true);
        }
        //or the other games passed
    }
    #endregion
}
