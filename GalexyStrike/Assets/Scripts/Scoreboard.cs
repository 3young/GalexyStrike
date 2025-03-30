using UnityEngine;
using TMPro;

/// <summary>
/// 게임 점수 관리 및 UI 표시
/// </summary>
public class Scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreboardText; // 점수 표시 UI 텍스트

    int score = 0;                            // 현재 점수

    /// <summary>
    /// 점수 증가 및 UI 업데이트
    /// </summary>
    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreboardText.text = score.ToString();
    }
}
