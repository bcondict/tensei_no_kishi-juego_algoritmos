using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine;
// using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{
    // public Rigidbody2D rigidbody;
    // public float speed = 10;
    [SerializeField] private float moveSpeed = 1f;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
    }

    private void Move()
    {
        rb.MovePosition((rb.position + movement * (moveSpeed * Time.fixedDeltaTime)));
    }
}
