using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private string interactButtonName;
   
    [SerializeField] private GameObject playerModel;

    private float movementSpeed;

    [SerializeField] private float walkingSpeed;
    Vector3 velocity;
 
    private CharacterController charController;
    private Rigidbody rb;

    public float WalkingSpeed { get => walkingSpeed; set => walkingSpeed = value; }
    public float MovementSpeed { get => movementSpeed; }

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        movementSpeed = walkingSpeed;
    }

    private void Update()
    {
        PlayerMovement();
    }


    private void PlayerMovement()
    {
        float vertInput = Input.GetAxis(verticalInputName);
        float horizInput = Input.GetAxis(horizontalInputName);

        Vector3 movement = new Vector3(horizInput, 0.0f, vertInput);
        if (movement != Vector3.zero) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.2f);
        // rb.AddForce(movement * movementSpeed);
        charController.Move(movement * movementSpeed * Time.deltaTime);
        //transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
    }
}
