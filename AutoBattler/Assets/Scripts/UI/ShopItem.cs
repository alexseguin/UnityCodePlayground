using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    [SerializeField]
    private GameObject hatDetails;

    private CanvasGroup group;
    private Canvas canvas;
    private RectTransform rectTransform;
    float desiredFade = 0;

    private bool dragging;
    private Vector2 originalPosition;

    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        rectTransform = GetComponent<RectTransform>();

        group = hatDetails.GetComponent<CanvasGroup>();
        group.alpha = 0;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        desiredFade = 1;
        hatDetails.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        desiredFade = 0;
    }

    GameObject lastHovered;
    bool currentlyHovering = false;

    void Update()
    {
        if (dragging)
        {
            desiredFade = 0;

            var screenToWorldPosition = Camera.main.ScreenToWorldPoint(rectTransform.transform.position);
            Debug.DrawRay(screenToWorldPosition, Vector3.forward * 25, Color.red);

            var hit = Physics2D.Raycast(screenToWorldPosition, this.transform.forward);
            if (hit.collider != null && hit.collider.tag == "PartyMember")
            {
                lastHovered = hit.collider.gameObject;
                currentlyHovering = true;
            }
            else
            {
                currentlyHovering = false;
            }
        }
        if (group != null)
        {
            group.alpha = Mathf.Lerp(group.alpha, desiredFade, 15f * Time.deltaTime);
        }
        if (group.alpha < 0.01f)
        {
            hatDetails.SetActive(false);
        }



        if (!currentlyHovering && lastHovered != null)
        {
            var anim = lastHovered.GetComponent<Animator>();
            anim.SetBool("HoveredByHat", false);
            // boyer was here
            lastHovered = null;
        }
        else if (currentlyHovering && lastHovered != null)
        {
            var anim = lastHovered.GetComponent<Animator>();
            anim.SetBool("HoveredByHat", true);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Reset animations for currently hovered party member
        if (lastHovered != null)
        {
            lastHovered.GetComponent<BaseController>().hatSlot.GetComponent<SpriteRenderer>().sprite = this.GetComponent<ShopHat>().hat.art;

            var anim = lastHovered.GetComponent<Animator>();
            anim.SetBool("HoveredByHat", false);
            lastHovered = null;
        }
        currentlyHovering = false;

        // Dragging is done
        group.blocksRaycasts = true;
        dragging = false;
        this.rectTransform.anchoredPosition = originalPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        this.rectTransform.SetAsLastSibling();
        originalPosition = this.rectTransform.anchoredPosition;
        dragging = true;
        group.blocksRaycasts = false;
    }
}
