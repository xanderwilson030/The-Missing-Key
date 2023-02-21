using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAttack : MonoBehaviour
{

    private Animator anim;
    private AudioSource audio;

    [SerializeField] GameObject trigger;

    [SerializeField] AudioClip monsterNoises;


    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.e_MonsterAttack.AddListener(CueAttack);

        anim = gameObject.GetComponent<Animator>();
        audio = trigger.gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CueAttack()
    {
        Debug.Log("Monster Attack Event");

        anim.Play("DoorClose", 0, 0.0f);

        gameObject.GetComponent<MyDoorController>().enabled = false;

        audio.Play();

        trigger.GetComponent<BoxCollider>().enabled= false;


        Invoke("InvokeAttack", 2f);

    }


    private void InvokeAttack()
    {
        trigger.GetComponent<BoxCollider>().enabled = true;

        trigger.GetComponent<BoxCollider>().isTrigger = false;

        //anim.Play("DoorRattle", 0, 0.0f);

        audio.clip = monsterNoises;

        //audio.loop = true;
        audio.Play();
    }
}
