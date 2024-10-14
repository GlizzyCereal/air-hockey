using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 0.15f;
    private Camera cam;
    private Vector3 worldPos;
    private Rigidbody2D rb;

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
        //transform.position = worldPos;
        
    }

    private void FixedUpdate() 
    {
        var destination = Vector3.MoveTowards(transform.position, worldPos, speed * Time.fixedDeltaTime);
        rb.MovePosition(worldPos);
    }
}
