using UnityEngine.UI;
using UnityEngine;

public class GunsMenuController : MonoBehaviour
{

    private Guns guns;

    [SerializeField]
    private Transform container;

    [SerializeField]
    private GameObject template;

    private void Start() { }

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
        foreach (Transform child in container)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Gun gun in guns.GetGuns())
        {
            var gunSlot = Instantiate(template, container).GetComponent<RectTransform>();
            gunSlot.gameObject.SetActive(true);

            gunSlot.Find("background").Find("name").GetComponent<Text>().text = gun.name;
            gunSlot.Find("background").Find("sprite").GetComponent<Image>().sprite = gun.sprite;
        }
    }

    public void ViewDetails()
    {
        
    }
}
