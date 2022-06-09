using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopPartyMemberHover : MonoBehaviour, IDropHandler, IPointerEnterHandler 
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        // Sets position of dragged object to the position of the dropzone
        if (eventData.pointerDrag != null)
        {
            Debug.Log("OnDrop");
            // eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
            Debug.Log("OnEnter");
    }
}
