using System.Collections;
using UnityEngine;

/// <summary>
/// 플레이어 충돌 처리 및 파괴 효과 관리
/// </summary>
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject playerExplosionVFX; // 플레이어 폭발 시각 효과
    [SerializeField] AudioClip playerExplosionSFX;  // 플레이어 폭발 사운드 효과

    GameSceneManager gameSceneManager;              // 게임 씬 관리자 참조
    AudioSource audioSource;                        // 오디오 소스 컴포넌트

    /// <summary>
    /// 초기화 및 필요한 컴포넌트 참조 설정
    /// </summary>
    private void Start()
    {
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }

    /// <summary>
    /// 충돌 발생 시 플레이어 파괴 효과 처리
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(playerExplosionSFX, Camera.main.transform.position, 1.0f);
        Instantiate(playerExplosionVFX, transform.position, Quaternion.identity);
        StartCoroutine(DestroyPlayerRoutine());
    }

    /// <summary>
    /// 플레이어 파괴 및 레벨 재시작 코루틴
    /// </summary>
    IEnumerator DestroyPlayerRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
        gameSceneManager.ReloadLevel();
    }
}
