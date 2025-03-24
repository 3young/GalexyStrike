using System.Collections;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject playerExplosionVFX;
    [SerializeField] AudioClip playerExplosionSFX;

    GameSceneManager gameSceneManager;
    AudioSource audioSource;

    private void Start()
    {
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(playerExplosionSFX, Camera.main.transform.position, 1.0f);
        Instantiate(playerExplosionVFX, transform.position, Quaternion.identity);
        StartCoroutine(DestroyPlayerRoutine());
    }

    IEnumerator DestroyPlayerRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
        gameSceneManager.ReloadLevel();
    }
}
