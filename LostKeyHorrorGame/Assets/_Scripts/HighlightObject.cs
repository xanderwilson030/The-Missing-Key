using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObject : MonoBehaviour
{
    private Color startcolor;
    [SerializeField] Material hoverMat;
    private Material originalMat;


    private void Start()
    {
        //originalMat = GetComponentinChildren<MeshRenderer>().material;

        originalMat = gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material;

    }
    void OnMouseEnter()
    {
        Debug.Log("Mouse Over");
        //GetComponent<MeshRenderer>().material = hoverMat;

        gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = hoverMat;
    }
    void OnMouseExit()
    {
        //GetComponent<MeshRenderer>().material = originalMat;

        gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = originalMat;
    }
}
