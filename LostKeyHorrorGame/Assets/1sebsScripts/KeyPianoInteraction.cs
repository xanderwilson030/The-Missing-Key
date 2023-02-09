using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyPianoInteraction : MonoBehaviour
{

	public Transform TriggerZone;
	public GameObject PianoKey;
	private AudioSource source;

	public bool hasKey = false;

	private void Awake()
	{
		source = gameObject.GetComponent<AudioSource>();
	}

	public void OnCollisionEnter(Collision pkey)
	{
		Debug.Log("AHHHHH");
		if (pkey.gameObject.tag.Equals("pkey") == true)
		{
			source.PlayOneShot(source.clip);
			Destroy(PianoKey);
			Debug.Log("Key Is Dead");
			StartCoroutine(Credits());
		}
	}
	IEnumerator Credits()
	{
		yield return new WaitForSeconds(10f);
		SceneManager.LoadScene("Credits", LoadSceneMode.Single);
	}
}

