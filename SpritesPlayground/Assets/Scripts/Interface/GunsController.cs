using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GunsController : MonoBehaviour
{
    private Guns guns;
    [SerializeField] private Transform container;
    [SerializeField] private GameObject template;

    private void Start()
    {
    }

    public void SetGuns(Guns guns)
    {
        this.guns = guns;
    }

    public void OnEnable()
    {
        RefreshGuns();
    }


    private void RefreshGuns()
    {
        int y = 0;
        float offset = 105f;
        foreach (Gun gun in guns.GetGuns())
        {
            var gunSlot = Instantiate(template, container).GetComponent<RectTransform>();
            gunSlot.anchoredPosition = new Vector2(gunSlot.anchoredPosition.x, -y * offset);
            y++;
            gunSlot.gameObject.SetActive(true);
            gunSlot.Find("name").GetComponent<Text>().text = gun.name;
            gunSlot.Find("sprite").GetComponent<Image>().sprite = gun.sprite;
        }
    }
}
