using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------
//- This script moves the player
//- By: Peter Schreuder
//---------------

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 6f, gravity = 20f;
    
    private Transform cameraTransform;

    private Rigidbody rigidbodyPlayer;

    private bool isGrounded;

    private Vector3 moveDirection = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        //Find the current camera
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        rigidbodyPlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //Check if the player is on the ground
        
        MoveDirection();
        

        
    }

    void MoveDirection()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;


        rigidbodyPlayer.AddForce(moveDirection, ForceMode.Impulse);
        //Move the player
        //characterController.Move(moveDirection * Time.deltaTime);
    }

    /*void CheckGrounded()
    {
        RaycastHit _hit;
        Ray _ray = Physics.Raycast(transform.position, Vector3.down, 1f, 8, out _hit);


        if ()

    }*/
}
