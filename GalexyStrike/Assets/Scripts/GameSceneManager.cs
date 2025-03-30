using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 게임 씬 전환 및 관리
/// </summary>
public class GameSceneManager : MonoBehaviour
{
    /// <summary>
    /// 현재 레벨 재시작 처리
    /// </summary>
    public void ReloadLevel()
    {
        StartCoroutine(ReloadLevelRoutine());
    }

    /// <summary>
    /// 레벨 재시작 지연 처리 코루틴
    /// </summary>
    IEnumerator ReloadLevelRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
