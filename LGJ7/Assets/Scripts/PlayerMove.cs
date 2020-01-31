using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;

    private float movementSpeed;

    [SerializeField] private float walkingSpeed;
    Vector3 velocity;
 
    private CharacterController charController;

    public float WalkingSpeed { get => walkingSpeed; set => walkingSpeed = value; }
    public float MovementSpeed { get => movementSpeed; }

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
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

        Vector3 move = transform.right * horizInput + transform.forward * vertInput;

        charController.Move(move * movementSpeed * Time.deltaTime);    
    }
}
