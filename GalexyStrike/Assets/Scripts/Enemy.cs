using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    [SerializeField] AudioClip explosionSFX; // Change AudioSource to AudioClip
    [SerializeField] int hitPoints = 3;
    [SerializeField] int scoreValue = 10;

    Scoreboard scoreboard;
    AudioSource audioSource;

    private void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
        audioSource = GetComponent<AudioSource>(); // Add this line to get the AudioSource component
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints--;

        if (hitPoints <= 0)
        {
            scoreboard.IncreaseScore(scoreValue);
            AudioSource.PlayClipAtPoint(explosionSFX, Camera.main.transform.position, 1.0f);
            Instantiate(explosionVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
