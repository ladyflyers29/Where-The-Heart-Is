﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVictimDead : MonoBehaviour
{
    private Animator animator;
    private AudioSource death;
    private AudioSource heartbeat;
    public bool dead = false;

    bool died = false;
    //Rigidbody2D rb;


    private VictimAI waypoint;
    // Start is called before the first frame update
    void Start()
    {
 
//        thisobject = GetComponent<GameObject>();
        animator = GetComponent<Animator>();
        waypoint = GetComponent<VictimAI>();
        AudioSource[] sounds = GetComponents<AudioSource>();

        Debug.Log("2");
        heartbeat = sounds[0];
        death = sounds[1];
        Debug.Log("3");

       // rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (dead == true && died == false)
        {
            Debug.Log("hey i got you");
            animator.SetBool("isDead", true);
            //rb.constraints = RigidbodyConstraints2D.FreezeAll;
            waypoint.enabled = false;
            death.Play();
            heartbeat.Stop();
            gameObject.transform.Find("Field of Vision").gameObject.SetActive(false);
            died = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hey i touched you");
    }
}
