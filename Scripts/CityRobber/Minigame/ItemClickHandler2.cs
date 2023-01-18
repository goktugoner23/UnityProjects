using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ItemClickHandler2 : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    #region Fields
    [Header("Components")]
    [SerializeField]
    private RectTransform objectTransform;
    public GameObject differentDonut;
    [Header("Variables")]
    public Vector3 objectStartPos;
    #endregion

    private void Awake()
    {
        objectStartPos = transform.localPosition;
        differentDonut.gameObject.SetActive(true);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(objectTransform, Input.mousePosition))
        {
            gameObject.SetActive(false);

        }
    }

    public void OnPointerDown(PointerEventData eventData) 
    {
    
    }

    public void OnPointerUp(PointerEventData eventData) 
    {
    
    }
}
