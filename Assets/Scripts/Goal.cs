using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{
    public GameObject objectToMove;
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI text element
    public AudioClip hitSound; // Reference to the audio clip to play on hit

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

                // Play the hit sound at a constant volume
                if (hitSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(hitSound, 1f); // Play sound at full volume
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