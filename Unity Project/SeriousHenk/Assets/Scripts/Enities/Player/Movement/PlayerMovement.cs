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

    [Header("Gets the Main Camera")]
    [SerializeField]
    private Transform cameraTransform;

    CharacterController characterController;

    private Vector3 moveDirection = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        CheckCharacterController();

        //Find the current camera
        cameraTransform = GameObject.FindGameObjectWithTag("Main Camera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Check if the player is on the ground
        if (characterController.isGrounded)
        {
            MoveDirection();
        }

        
    }

    void MoveDirection()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;

        //Move the player
        characterController.Move(moveDirection * Time.deltaTime);
    }

    void CheckCharacterController()
    {
        //If there is no Controller detected, create one for now
        if (GetComponent<CharacterController>() == null)
        {
            gameObject.AddComponent<CharacterController>();
            Debug.LogWarning("No CharacterController detected! Added one for now.");
        }

        characterController = GetComponent<CharacterController>();
    }
}
