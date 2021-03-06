﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCarton : MonoBehaviour {

    private PlayerControllerCarton player;
    private WinObjective pan;
    private ButtonScript panButton;
    private Transform playerSpawn;
    private LeverScript lever;
    private GM gm;
    private GameObject oldCarton;

    private bool first = true;

    private AudioSource audioSource;

    // Use this for initialization

    void Awake()
    {
        oldCarton = GameObject.Find("EggCarton_Master");
        oldCarton.SetActive(false);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gm = GameObject.Find("GameManager").GetComponent<GM>();

        //player base stats
        player = transform.GetChild(0).GetComponent<PlayerControllerCarton>();
        player.maxSpeed = 9;
        player.jumpForce = 11;
        player.canDoubleJump = false;

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

        SpawnPlayer();

        if (first)
        {
            player.anim.SetTrigger("Open");
            Instantiate(player.husk, player.huskSpawn.position, player.husk.transform.rotation);
            first = false;
        }
    }

    void KillPlayer()
    {
        audioSource.Play();
        gm.deathCount++;
        Start();
        //SpawnPlayer();
    }

    void SpawnPlayer()
    {
        player.transform.position = playerSpawn.position;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead)
        {
            player.isDead = false;
            KillPlayer();
        }
    }
}
