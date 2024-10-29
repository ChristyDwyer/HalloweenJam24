using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    public HalloweenJam24 controls;
    //private CharacterController controller;
    private Rigidbody rb;
    private Vector2 movement_inputs = Vector2.zero;
    [SerializeField] private float clampY = 1.15f;
    [SerializeField] private float player_speed = 10f;
    [SerializeField] private GameObject closestGuest;
    [SerializeField] private GuestManager guestManager;
    void Awake()
    {
        //controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        SetUpControls();
    }
    private void SetUpControls()
    {
        controls = new();
        controls.Player.Move.performed += ctx => movement_inputs = ReadInput(ctx.ReadValue<Vector2>());
        controls.Player.Move.canceled += ctx => movement_inputs = Vector2.zero;
       // controls.Player.Move.canceled += ctx => walk.enabled = false;
        controls.Player.Interact.performed += ctx => HandleInteraction();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Guest" && closestGuest == null)
        {
            closestGuest = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == closestGuest)
        {
            closestGuest = null;
        }
    }
    private void HandleMovement()
    {
        float tempY = RectY(rb.velocity.y);
        float moveX = movement_inputs.x * Time.deltaTime * player_speed;
        float moveZ = movement_inputs.y * Time.deltaTime * player_speed;
        //controller.Move(new Vector3 (movement_inputs.x, 0, movement_inputs.y));
        rb.velocity = new Vector3(moveX, tempY, moveZ);
        //Debug.Log(moveX + " " + moveZ);
    }
    
    private void HandleInteraction()
    {
        if(closestGuest != null)
        {
            var guestAI = closestGuest.GetComponent<GuestAI>();
            if(guestAI.isFollowing)
            {
                guestAI.isFollowing = false;
                guestManager.NextGuest();
            }
            else
            {
                guestAI.isFollowing=true;
            }
        }
        else
        {
            Debug.Log("alone");
        }
    }
    private float RectY(float y_velocity)
    {
        if (transform.position.y > clampY && y_velocity > 0)
        {
            transform.position = new Vector3(transform.position.x, clampY, transform.position.z);
            y_velocity = 0; 
        }
        return y_velocity;
    }
    private Vector2 ReadInput(Vector2 input)
    {
        return input;
    }

    /// <summary>
    /// Enables usage of the Player input map from new input system.
    /// </summary>
    public void EnableInput()
    {
        controls.Player.Enable();
    }
    /// <summary>
    /// Diables usage of the Player input map from the new input system
    /// </summary>
    public void DisableInput()
    {
        controls.Player.Disable();
    }
    private void OnDisable()
    {
        DisableInput();
    }
    private void OnEnable()
    {
        EnableInput();
    }
}
