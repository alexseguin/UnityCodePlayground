using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
// Accesses properties of the object within the UI Canvas
    private CanvasGroup canvasGroup;

    // 
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;

    void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        this.canvasGroup.alpha = 0.5f;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        this.canvasGroup.alpha = 1f;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }
}
