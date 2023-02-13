using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(MainMenu());
	}
	IEnumerator MainMenu()
	{
		yield return new WaitForSeconds(15f);
		Debug.Log("halp");
		SceneManager.LoadScene("Menu", LoadSceneMode.Single);
	}
}