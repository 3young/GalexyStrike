using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 플레이어 우주선 이동 및 회전 제어
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;       // 이동 속도
    [SerializeField] float xClampRange = 5f;         // X축 이동 제한 범위
    [SerializeField] float yClampRange = 5f;         // Y축 이동 제한 범위

    [SerializeField] float controlPitchFactor = 15f; // 세로 입력에 따른 피치 회전 계수
    [SerializeField] float controlRollFactor = 20f;  // 가로 입력에 따른 롤 회전 계수
    [SerializeField] float rotationSpeed = 10f;      // 회전 속도

    Vector2 movement;                                // 현재 이동 입력값

    /// <summary>
    /// 프레임별 플레이어 이동 및 회전 처리
    /// </summary>
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    /// <summary>
    /// 플레이어 입력 처리
    /// </summary>
    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    /// <summary>
    /// 플레이어 이동 위치 계산 및 제한
    /// </summary>
    void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }

    /// <summary>
    /// 이동 입력에 따른 우주선 회전 처리
    /// </summary>
    void ProcessRotation()
    {
        float pitch = -controlPitchFactor * movement.y;
        float roll = -controlRollFactor * movement.x;

        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
