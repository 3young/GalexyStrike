using UnityEngine;

/// <summary>
/// 모선 객체의 지속적 회전 처리
/// </summary>
public class RotateMotherShip : MonoBehaviour
{
    /// <summary>
    /// 프레임별 모선 회전 처리
    /// </summary>
    void Update()
    {
        transform.Rotate(new Vector3(3, 3, 3) * Time.deltaTime);
    }
}
