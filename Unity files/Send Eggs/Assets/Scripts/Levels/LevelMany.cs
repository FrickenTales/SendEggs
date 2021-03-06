﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMany : MonoBehaviour {

    private GameObject shell;
    private Animator cartonanim;
    private PlayerController player;
    private WinObjective pan;
    private ButtonScript panButton;
    private Transform playerSpawn;
    private LeverScript lever;
    private GM gm;

    public GameObject playerObject;

    private void Start()
    {
        Invoke("Begin", 0.1f);
    }

    // Use this for initialization
    void Begin ()
    {
        shell = Resources.Load("BrokenEgg") as GameObject;
        cartonanim = GameObject.FindGameObjectWithTag("Carton").GetComponent<Animator>();
        gm = GameObject.Find("GameManager").GetComponent<GM>();

        //player base stats
        //player = transform.GetChild(0).GetComponent<PlayerController>();
        //player.maxSpeed = 9;
        //player.jumpForce = 11;
        //player.canDoubleJump = false;

        //pan
        pan = GameObject.FindGameObjectWithTag("Objective").GetComponent<WinObjective>();
        pan.ready = false;

        //pan button
        panButton = GameObject.FindGameObjectWithTag("PanButton").GetComponent<ButtonScript>();
        panButton.isOn = false;

        //bridge lever
        lever = GameObject.FindGameObjectWithTag("Lever").GetComponent<LeverScript>();
        lever.toggles = false;
        lever.isOn = false;

        //spawn point
        playerSpawn = GameObject.Find("SpawnPoint").transform;

        //SpawnPlayer();
        InvokeRepeating("SpawnPlayer", 0.1f, 0.7f);
	}

    void KillPlayer()
    {
        //Instantiate(shell, player.body.transform.position, player.body.transform.rotation);
        //gm.deathCount++;
        //Start();
        //SpawnPlayer();
    }

    void SpawnPlayer()
    {
        //player.transform.position = playerSpawn.position;
        Instantiate(playerObject, playerSpawn.position, playerObject.transform.rotation);
        //player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        cartonanim.SetTrigger("SpawnEgg");
        //player.anim.SetTrigger("Spawn");
    }
	
	// Update is called once per frame
	void Update ()
    {
        /*
        if (player.isDead)
        {
            player.isDead = false;
            KillPlayer();
        }
        */
	}
}
