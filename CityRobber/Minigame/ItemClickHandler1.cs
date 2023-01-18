using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ItemClickHandler1 : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    #region Fields
    [Header("Components")]
    [SerializeField]
    private RectTransform objectTransform;
    public GameObject alarm_off;
    [Header("Variables")]
    public Vector3 objectStartPos;
    #endregion

    private void Awake()
    {
        objectStartPos = transform.localPosition;
        alarm_off.gameObject.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(objectTransform, Input.mousePosition))
        {
            gameObject.SetActive(false);
            alarm_off.gameObject.SetActive(true);
        }
    }

    public void OnPointerDown(PointerEventData eventData) 
    {
    
    }

    public void OnPointerUp(PointerEventData eventData) 
    {
    
    }
}
