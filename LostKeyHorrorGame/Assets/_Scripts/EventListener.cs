using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListener : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.e_ObjectPlaced.AddListener(CarryOutEvent);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CarryOutEvent(int i)
    {
        if (i == 0)
        {
            Debug.Log("Destroy Event");

            gameObject.SetActive(false);
        }
        else if (i == 1)
        {
            Debug.Log("Place Board Event");
        } 
    }
}
