using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPianoController : MonoBehaviour
{
	private AudioSource source;
	private bool alreadyPlayed = false;

	[SerializeField] GameObject closeDoor;

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
		var player = GameObject.Find("NEW Player");
		var target = player.GetComponent<NewPlayerMovement>();
		if (target.hasKey)
		{
			source.PlayOneShot(source.clip);
			Destroy(gameObject);
			//closeDoor.transform.Rotate(new Vector3(0, -80, 0));
		}
	}
}
