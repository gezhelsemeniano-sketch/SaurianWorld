using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference MoveActionToUse;
    [SerializeField] private float speed;

    Rigidbody2D myRigidBody2D; //The body of the player
    BoxCollider2D myBoxCollider2D; //Collider or hitbox of player
    PolygonCollider2D myPlayersFeet; // honestly these are nothing smhsmh

    public Transform spawnPoint;
    public Rigidbody2D rb; 
    float startingGravityScale;

    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();  //Get the component which is rigidbody, animations
        myBoxCollider2D = GetComponent<BoxCollider2D>();
        startingGravityScale = myRigidBody2D.gravityScale;
    }

    void FixedUpdate()
    {
        PlayerJoystick();
    }
    public void PlayerJoystick()
    {
        Vector2 moveDirection = MoveActionToUse.action.ReadValue<Vector2>();
        transform.Translate(moveDirection * speed * Time.fixedDeltaTime);
    }


}
