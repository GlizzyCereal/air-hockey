using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public Transform target;
    public float speed = 15f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var targetPos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        if (targetPos.x <= 0){
            rb.MovePosition(targetPos);
        }
    }
}
