using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGrid : MonoBehaviour
{

    [SerializeField] private float xOffset = 100f;
    [SerializeField] private float yOffset = 100f;
    [SerializeField] private int columns = 2;
    [SerializeField] private int rows = 2;
    [SerializeField] private GameObject slotFab;
    [SerializeField] private Transform generationPoint;

    void Awake()
    {
    }

    void Start() {

        // Vector3 position = this.transform.position;
        Vector3 position = generationPoint.GetComponent<RectTransform>().anchoredPosition;
        var initX = position.x;
        for (int i = 0; i < columns; i++)
        {

            for (int j = 0; j < rows; j++)
            {
                GameObject slot = Instantiate(slotFab, transform);
                RectTransform slotRectTransform = slot.GetComponent<RectTransform>();
                slotRectTransform.anchoredPosition = new Vector3(position.x, position.y, 1);
                position.x+= xOffset;
            }
            position.x = initX;
            position.y -= yOffset;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
