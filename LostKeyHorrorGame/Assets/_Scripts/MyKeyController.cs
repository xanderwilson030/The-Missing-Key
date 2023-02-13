using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyKeyController : MonoBehaviour
{
	public Transform theKeyDest;
	private AudioSource source;

	private void Awake()
	{
		source = gameObject.GetComponent<AudioSource>();
	}
	void OnMouseDown()
	{
		this.transform.position = theKeyDest.position;
		this.transform.parent = GameObject.Find("KeyDestination").transform;
		var player = GameObject.Find("First Person Player");
		var target = player.GetComponent<PlayerMovement>();
		target.hasKey = true;
		source.PlayOneShot(source.clip);
		Debug.Log("Has Key Is True");
	}

}
