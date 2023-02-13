using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDoorController : MonoBehaviour
{
	private Animator doorAnim;
	private AudioSource source;
	private bool doorOpen = false;
	private bool alreadyPlayed = false;

	private void Awake()
	{
		doorAnim = gameObject.GetComponent<Animator>();
		source = gameObject.GetComponent<AudioSource>();
	}
	public void PlayAnimation()
	{
		if(!doorOpen)
		{
			doorAnim.Play("DoorOpen", 0, 0.0f);
			doorOpen = true;
		}
		else
		{
			doorAnim.Play("DoorClose", 0, 0.0f);
			doorOpen = false;
		}
	}
	public void PlaySound()
	{
		if (!alreadyPlayed)
		{
			source.PlayOneShot(source.clip);
			alreadyPlayed = true;
		}
	}
}
