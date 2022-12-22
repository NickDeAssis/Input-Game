using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2 : MonoBehaviour
{

    PlayerController controls;
    Vector2 move;
    public float speed = 10;
    // Start is called before the first frame update
    void Awake()
    {
        controls = new PlayerController();
        controls.Player.Move.performed += ctx => SendMessage(ctx.ReadValue<Vector2>());
        controls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => move = Vector2.zero;
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }
    private void OnDisable()
    {
        controls.Player.Disable();
    }
    // Update is called once per frame
    
    void SendMessage(Vector2 coordinates)
    {
        Debug.Log("Button Coordinates = "+ coordinates);
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(move.x, 0.0f, move.y) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }
}
