﻿using System.Collections; using System.Collections.Generic; using UnityEngine;  public class PlayerController : MonoBehaviour {     public float moveSpeed;     public float jumpForce;     public CharacterController controller;     public Rigidbody rb;      private Vector3 moveDirection;     public float gravityScale;      public Animator anim;     public Transform pivot;     public float rotateSpeed;      public GameObject playerModel;       // Start is called before the first frame update     void Start()     {         controller = GetComponent<CharacterController>();     }       //Restart Game     void FixedUpdate ()
    {
        if (rb.position.y < -2f)
        {
            FindObjectOfType<ManagerGame>().EndGame();
        }
    }

    // Update is called once per frame
    void LateUpdate()     {         //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);          float yStore = moveDirection.y;         moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));         moveDirection = moveDirection.normalized * moveSpeed;         moveDirection.y = yStore;          if (controller.isGrounded)         {             moveDirection.y = 0f;             if (Input.GetButtonDown("Jump"))             {                 moveDirection.y = jumpForce;             }         }          moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);         controller.Move(moveDirection * Time.deltaTime);          //Move the player in different directions based on camera look direction         if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);             Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));             playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }          anim.SetBool("isGrounded", controller.isGrounded);         anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));     } }