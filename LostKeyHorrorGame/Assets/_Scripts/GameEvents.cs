using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class MyIntEvent : UnityEvent<int>
{

}


public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    public MyIntEvent e_ObjectPlaced;


    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        if (e_ObjectPlaced == null)
        {
            e_ObjectPlaced = new MyIntEvent();
        }
    }


}