using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool isOn = false;
    public GameObject lightSource;
    public bool failSafe = false;
    [SerializeField] float decrementAmount = .25f;
    [SerializeField] float incrementAmount = 1f;

    private float originalIntensity = 5f;
    private float flashlightCurIntensity;

    private void Start()
    {
        flashlightCurIntensity = originalIntensity;
    }

    void Update()
    {
        //Debug.Log(lightSource.GetComponent<Light>().intensity);


        if (Input.GetButtonDown("FKey"))
		{
            if(isOn == false && failSafe == false)
			{
                failSafe = true;
                lightSource.SetActive(true);
                isOn = true;
                StartCoroutine(FailSafe());
			}
            if(isOn == true && failSafe == false)
			{
                failSafe = true;
                lightSource.SetActive(false);
                isOn = false;
                StartCoroutine(FailSafe());
            }
        }

        if (isOn)
        {
            flashlightCurIntensity -= decrementAmount * Time.deltaTime;

            lightSource.GetComponent<Light>().intensity = flashlightCurIntensity;
        }
        if (!isOn)
        {
            flashlightCurIntensity += incrementAmount * Time.deltaTime;

            if (flashlightCurIntensity >= originalIntensity)
            {
                flashlightCurIntensity = originalIntensity;
            }

            lightSource.GetComponent<Light>().intensity = flashlightCurIntensity;
        }
    }
    IEnumerator FailSafe()
	{
        yield return new WaitForSeconds(0.25f);
        failSafe = false;
	}

}
