using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPianoController : MonoBehaviour
{
	private AudioSource source;
	private bool alreadyPlayed = false;

	private void Awake()
	{
		source = gameObject.GetComponent<AudioSource>();
	}
	public void PlaySound()
	{
		if (!alreadyPlayed)
		{
			source.PlayOneShot(source.clip);
			alreadyPlayed = true;
		}
	}
	public void KeyCheck()
	{
		var player = GameObject.Find("First Person Player");
		var target = player.GetComponent<PlayerMovement>();
		if (target.hasKey)
		{
			source.PlayOneShot(source.clip);
			Destroy(gameObject);
		}
	}
}
