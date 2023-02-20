using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PickUpItem : MonoBehaviour
{
    [SerializeField] GameObject holdPos;
    public GameObject objectHeld;

    public Camera raySource;

    int range = 100;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Ray ray = new Ray(raySource.transform.position, raySource.transform.forward);
            //RaycastHit hitData;
            RaycastHit hit;

            if (Physics.Raycast(raySource.transform.position, raySource.transform.forward, out hit, range))
            {

                Debug.DrawRay(raySource.transform.position, raySource.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red, range);
                Debug.Log("Did Hit" + hit.transform.gameObject.tag);

                GameObject newGameObject = hit.transform.gameObject;

                CheckObject(newGameObject, hit);
            }

        }
    }


    private void CheckObject(GameObject target, RaycastHit hit)
    {
        Debug.Log("Checking object");
        if (target.tag.Equals("equippable"))
        {
            Debug.Log("SUCCESS");
            target.transform.parent = holdPos.transform;
            target.transform.position = holdPos.transform.position;
        }

        if (target.tag.Equals("Resting Place"))
        {
            Debug.Log("Placing Object " + hit.transform.gameObject.name);

            GameObject holdingSpot = gameObject.transform.GetChild(2).gameObject;
            GameObject childOfHolding = holdingSpot.transform.GetChild(0).gameObject;

            GameObject child = hit.transform.GetChild(0).gameObject;

            childOfHolding.transform.parent = child.transform;
            childOfHolding.transform.position = child.transform.position;
            
            if (childOfHolding.gameObject.name.Equals("Vase"))
            {
                GameEvents.current.e_ObjectPlaced.Invoke(0);
            }

            if (childOfHolding.gameObject.name.Equals("Plank"))
            {
                GameEvents.current.e_ObjectPlaced.Invoke(1);
            }
        }
    }

    
}
