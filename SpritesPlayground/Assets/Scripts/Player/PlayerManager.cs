using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton
{
    public static bool canShoot() {
        return !InGameMenuManager.menuOpened;
    }
}
