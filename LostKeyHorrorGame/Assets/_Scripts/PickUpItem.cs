using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

            // Creating the raycast to check what the player is shooting
            if (Physics.Raycast(raySource.transform.position, raySource.transform.forward, out hit, range))
            {
                // The Ray hit something less than 10 Units away,
                // It was on the a certain Layer
                // But it wasn't a Trigger Collider

                Debug.DrawRay(raySource.transform.position, raySource.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red, range);
                Debug.Log("Did Hit" + hit.transform.gameObject.tag);

                GameObject newGameObject = hit.transform.gameObject;

                CheckObject(newGameObject);
            }


            //RaycastHit hit;
            //if (Physics.Raycast(raySource.transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, 8))
            //{
                

            //}
            //else
            //{
            //    Debug.Log("No Hit");
            //}
        }
    }


    private void CheckObject(GameObject target)
    {
        Debug.Log("Checking object");
        if (target.tag.Equals("equippable"))
        {
            Debug.Log("SUCCESS");
            target.transform.parent = holdPos.transform;
            target.transform.position = holdPos.transform.position;
        }
    }

    
}
