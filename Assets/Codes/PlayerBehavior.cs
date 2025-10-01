using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerController : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f; //running speed of player in SerializeField


    Rigidbody2D myRigidBody2D; //The body of the player
    BoxCollider2D myBoxCollider2D; //Collider or hitbox of player
    PolygonCollider2D myPlayersFeet; // honestly these are nothing smhsmh

    public Transform spawnPoint;

    float startingGravityScale;

    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();  //Get the component which is rigidbody, animations
        myBoxCollider2D = GetComponent<BoxCollider2D>();
        startingGravityScale = myRigidBody2D.gravityScale;
    }
    void Update()
    {
        Run();  // calling em
    }

    private void Run() //method for running
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveX, moveY, 0f) * runSpeed * Time.deltaTime;
        transform.Translate(movement);

    }

}
