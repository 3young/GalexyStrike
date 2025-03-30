using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 플레이어 무기 시스템 및 타겟팅 관리
/// </summary>
public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;        // 레이저 무기 배열
    [SerializeField] RectTransform crosshair;    // 화면상 조준점 UI
    [SerializeField] Transform targetPoint;      // 3D 공간상 타겟 위치
    [SerializeField] float targetDistance = 100; // 타겟 거리
    [SerializeField] AudioClip shootSFX;         // 발사 사운드

    bool isFiring = false;                       // 발사 상태

    /// <summary>
    /// 초기화 및 커서 설정
    /// </summary>
    private void Start()
    {
        Cursor.visible = false;    
    }

    /// <summary>
    /// 프레임별 무기 및 타겟팅 처리
    /// </summary>
    private void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }

    /// <summary>
    /// 발사 입력 처리
    /// </summary>
    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    /// <summary>
    /// 무기 발사 효과 및 파티클 제어
    /// </summary>
    void ProcessFiring()
    {
        if (isFiring)
        {
            AudioSource.PlayClipAtPoint(shootSFX, transform.position, 0.5f);
        }

        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
    }

    /// <summary>
    /// 마우스 위치에 따른 조준점 이동
    /// </summary>
    void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }

    /// <summary>
    /// 마우스 위치를 3D 공간상 타겟 포인트로 변환
    /// </summary>
    private void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    /// <summary>
    /// 레이저 방향을 타겟 포인트를 향하도록 조정
    /// </summary>
    void AimLasers()
    {
        foreach(GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - this.transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }
}
