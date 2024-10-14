using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 20f; // Increased speed value
    private Camera cam;
    private Vector3 worldPos;
    private Rigidbody2D rb;

    // Public variable to choose the side (true for right, false for left)
    public bool moveRightSide = true;

    void Start()
    {
        cam = Camera.main;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        worldPos = cam.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;
    }

    private void FixedUpdate() 
    {
        var destination = Vector3.MoveTowards(transform.position, worldPos, speed * Time.fixedDeltaTime);

        // Check if the new x position is within the allowed range
        if (moveRightSide)
        {
            // Allow movement only on the right side of the screen
            if (destination.x >= 0)
            {
                rb.MovePosition(destination);
            }
        }
        else
        {
            // Allow movement only on the left side of the screen
            if (destination.x <= 0)
            {
                rb.MovePosition(destination);
            }
        }
    }
}