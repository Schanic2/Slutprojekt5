using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    private float movementSpeed;

    [SerializeField] private float walkSpeed, sprintSpeed;
    [SerializeField] private KeyCode sprintKey;

    [SerializeField] private AnimationCurve JumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode jumpKey;

    private CharacterController charController;

    private bool isJumping;
    private bool isSprinting;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }


    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovement + rightMovement);

        SprintInput();
        JumpInput();

    }

    private void JumpInput()
    {
        if (Input.GetKey(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }
    private void SprintInput()
    {
        if (Input.GetKey(sprintKey))
            movementSpeed = Mathf.Lerp(movementSpeed, sprintSpeed, Time.deltaTime);
        else
            movementSpeed = Mathf.Lerp(walkSpeed, sprintSpeed, Time.deltaTime);

    }

    private IEnumerator JumpEvent() // Hopp funktion
    {
        charController.slopeLimit = 90.0f; // Gör så att vi inte Darra när vi " Går mot en låda och försöker hoppa på den "
        float timeInAir = 0.0f;

        do
        {
            float jumpForce = JumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
            try
            {
                JumpInput();
            }
            catch 
            {
                Debug.LogError("Something is wrong");
            }
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
        isJumping = false;
    }
  

    

}

