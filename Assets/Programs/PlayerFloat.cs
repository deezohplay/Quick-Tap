using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFloat : MonoBehaviour
{
    public float floatStrength; // How strong the floating effect is
    public float waterDrag = 1f;     // Resistance when moving through water
    public LayerMask waterLayer;     // Define which layer represents water

    private Rigidbody2D rb;
    public bool isInWater = false;

    public static PlayerFloat Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckIfInWater();
    }

    void CheckIfInWater()
    {
        // Raycast downwards to detect if player is in water
        Vector2 origin = transform.position;
        float distance = 0.1f;  // How far down we check (tweak this based on player size)

        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, distance, waterLayer);
        isInWater = hit.collider != null;
    }

    void FixedUpdate()
    {
        if (isInWater)
        {
            ApplyBuoyancy();
            if (Input.GetMouseButtonDown(0))
            {
                //Add force to push player upward faster
                floatStrength += 0.1f;
            }
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    //Add force to push player upward faster
                    floatStrength += 0.1f;
                }
            }
        }
    }

    void ApplyBuoyancy()
    {
        // Buoyancy force is an upward force
        float upwardForce = floatStrength - rb.velocity.y;
        rb.AddForce(new Vector2(0f, upwardForce), ForceMode2D.Force);
        // Simulate drag or resistance while moving in water
        rb.drag = waterDrag;
    }
    public void ApplyGravity()
    {
        rb.gravityScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            isInWater = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            isInWater = false;
        }
    }
}
