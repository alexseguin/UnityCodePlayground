using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InGameMenuManager : Singleton
{
    [SerializeField]
    private GameObject inventory;
    
    public static bool menuOpened = false;
    public static Gun gun = null;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            InGameMenuManager.ToggleMenu();
            inventory.SetActive(!inventory.activeSelf);
        }
    }


    private static void ToggleMenu()
    {
        if (InGameMenuManager.menuOpened)
        {
            InGameMenuManager.Close();
        }
        else
        {
            InGameMenuManager.Open();
        }
    }

    private static void Open()
    {
        InGameMenuManager.menuOpened = true;
        InGameMenuManager.gun = null;
    }

    private static void Close()
    {
        InGameMenuManager.menuOpened = false;
        InGameMenuManager.gun = null;
    }
}
