using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puk : MonoBehaviour
{
    public AudioClip hitSound; // Reference to the audio clip to play on hit
    public float volumeSensitivity = 20f; // Public variable to adjust volume sensitivity (higher value for less sensitivity)
    public float animationSpeedSensitivity = 0.5f; // Public variable to adjust animation speed sensitivity (lower value for less sensitivity)

    private AudioSource audioSource; // Reference to the AudioSource component
    private Animator animator; // Reference to the Animator component

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        animator.speed = 0f; // Start with animation turned off
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the speed of the Puk
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            float speed = rb.velocity.magnitude;
            // Adjust the animation speed based on the speed of the Puk
            if (animator != null)
            {
                if (speed > 0)
                {
                    animator.speed = Mathf.Clamp(speed * animationSpeedSensitivity, 0.1f, 3f); // Adjust the multiplier and clamp values as needed
                }
                else
                {
                    animator.speed = 0f; // Turn off animation if not moving
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a wall (assuming walls have the tag "Wall")
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Calculate volume based on the speed of the Puk
            float speed = collision.relativeVelocity.magnitude;
            float volume = Mathf.Clamp(speed / volumeSensitivity, 0.1f, 1f); // Use the public variable for sensitivity

            // Play the hit sound with calculated volume
            if (hitSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(hitSound, volume);
            }
        }
    }
}