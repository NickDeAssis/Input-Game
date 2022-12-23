using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController2 : MonoBehaviour
{
    private Rigidbody rb;
    PlayerController controls;
    Vector2 move;
    public float speed = 10;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private int count;
    // Start is called before the first frame update
    void Awake()
    {
        controls = new PlayerController();
        controls.Player.Buttons.performed += ctx => Shoot();
        controls.Player.Move.performed += ctx => SendMessage(ctx.ReadValue<Vector2>());
        controls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => move = Vector2.zero;
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }
    private void OnDisable()
    {
        controls.Player.Disable();
    }
    
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >=12)
        {
            winTextObject.SetActive(true);
        }
    }
    
    void SendMessage(Vector2 coordinates)
    {
        Debug.Log("Button Coordinates = "+ coordinates);
    }

    void Shoot()
    {
        Debug.Log("Fire");
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(move.x, 0.0f, move.y) * speed * Time.deltaTime;
        //transform.Translate(movement, Space.World);
        rb.AddForce(movement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            count = count +1;

            SetCountText();
        }

    }
}
