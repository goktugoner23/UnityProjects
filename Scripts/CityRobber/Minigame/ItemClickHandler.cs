using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ItemClickHandler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    #region Fields
    [Header("Components")]
    [SerializeField]
    private RectTransform objectTransform;
    [Header("Variables")]
    public Vector3 objectStartPos;
    public bool flipped;
    #endregion

    private void Awake()
    {
        objectStartPos = transform.localPosition;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(objectTransform, Input.mousePosition))
        {
            Debug.Log("clicked");
            objectTransform.DORotate(new Vector3(0f, 0f, 0f), 0f);
            flipped = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData) 
    {
    
    }

    public void OnPointerUp(PointerEventData eventData) 
    {
    
    }
}
