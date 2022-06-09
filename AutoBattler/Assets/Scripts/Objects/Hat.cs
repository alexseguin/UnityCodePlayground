using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hat", menuName = "Hat")]
public class Hat : ScriptableObject
{
    public Sprite art;
    public string title;
    [Multiline]
    public string flavor;
    // put your penis in here
    public int price;
    public int sellPrice;
}
