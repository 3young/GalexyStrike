using System.Runtime.CompilerServices;
using UnityEngine;

/// <summary>
/// 적 객체의 동작 및 상태 관리
/// </summary>
public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;    // 적 폭발 시각 효과
    [SerializeField] AudioClip explosionSFX;     // 적 폭발 사운드 효과
    [SerializeField] int hitPoints = 3;          // 적 체력
    [SerializeField] int scoreValue = 10;        // 파괴 시 획득 점수

    Scoreboard scoreboard;                       // 점수 관리 참조
    AudioSource audioSource;                     // 오디오 소스 컴포넌트

    /// <summary>
    /// 초기화 및 필요한 컴포넌트 참조 설정
    /// </summary>
    private void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// 파티클 충돌 감지 처리
    /// </summary>
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    /// <summary>
    /// 적 피격 및 파괴 처리
    /// </summary>
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
