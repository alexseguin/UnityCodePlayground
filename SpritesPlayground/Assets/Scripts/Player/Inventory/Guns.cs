using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns
{
    List<Gun> guns;

    public Guns()
    {
        guns = new List<Gun>();
        AddGun(new Gun(){name = "Ye Olde Reliable", sprite = Resources.Load<Sprite>("ye-olde-reliable")});
        AddGun(new Gun(){name = "Ye Olde Reliable 2", sprite = Resources.Load<Sprite>("ye-olde-reliable")});
    }

    public void AddGun(Gun gun)
    {
        guns.Add(gun);
    }

    public List<Gun> GetGuns()
    {
        return guns;
    }
}
