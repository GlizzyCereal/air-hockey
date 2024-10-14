using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{
    public GameObject objectToMove;
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI text element
    public AudioClip hitSound; // Reference to the audio clip to play on hit
    public float volumeSensitivity = 10f; // Public variable to adjust volume sensitivity

    private int score = 0; // Variable to keep track of the score
    private AudioSource audioSource; // Reference to the AudioSource component

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == objectToMove)
        {
            objectToMove.transform.position = new Vector3(0, 0, 0);

            // Ensure the object loses all momentum
            Rigidbody2D rb = objectToMove.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
                rb.angularVelocity = 0f;

                // Calculate volume based on the speed of the object
                float speed = collision.relativeVelocity.magnitude;
                float volume = Mathf.Clamp(speed / volumeSensitivity, 0.1f, 1f); // Use the public variable for sensitivity

                // Play the hit sound with calculated volume
                if (hitSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(hitSound, volume);
                }
            }

            // Increment the score and update the text
            score++;
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        // Update the score text with leading zeros
        scoreText.text = score.ToString("D4");
    }
}