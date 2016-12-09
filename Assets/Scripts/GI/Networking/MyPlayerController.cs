﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyPlayerController : PlayerController
{
    ControlWrapping.GamePadWrapper controller;
    // Use this for initialization

    [SyncVar]
    float xAxis = 0;
    [SyncVar]
    float yAxis = 0;
    DoOnce registerGamePad = new DoOnce();
    //protected void Start()
    //{
    //    base.Start();
    //    if (localPlayerAuthority)
    //    {
    //        controller = GI.ControllerManager.Instance.RequestGamepad();
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        if (registerGamePad.Enter() && localPlayerAuthority)
        {
            Logger.Log("Controller " + ID);
            controller = GI.ControllerManager.Instance.RequestGamepad();
        }

        if (localPlayerAuthority)
        {
            xAxis = controller.Stick.Left.X;
            yAxis = controller.Stick.Left.Y;
        }

        Debug.Log("Controller: " + ID + " x:" + xAxis + ", y: " + yAxis);
    }
}