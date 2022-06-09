using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopHat : MonoBehaviour
{

    public Hat hat;

    public Text title;
    public Text flavour;
    public Image art;

    // Start is called before the first frame update
    void Start()
    {
        title.text = hat.title;
        flavour.text = hat.flavor;
        art.sprite = hat.art;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
