using TMPro;
using UnityEngine;

/// <summary>
/// 게임 내 대화 시스템 관리
/// </summary>
public class DialogueLines : MonoBehaviour
{
    [SerializeField] string[] timelineTextLines; // 순차적으로 표시할 대화 텍스트 배열
    [SerializeField] TMP_Text dialogueText;      // 대화 텍스트를 표시할 UI 요소

    int currentLine = 0;                         // 현재 표시 중인 대화 라인 인덱스
     
    /// <summary>
    /// 다음 대화 라인으로 진행
    /// </summary>
    public void NextDialogueLine()
    {
        currentLine++;
        dialogueText.text = timelineTextLines[currentLine];
    }
} 