using UnityEngine;

/// <summary>
/// 배경 음악 관리 및 씬 전환 간 연속성 유지
/// </summary>
public class MusicPlayer : MonoBehaviour
{
    /// <summary>
    /// 초기화 및 중복 음악 플레이어 관리
    /// </summary>
    void Start()
    {
        int numOfMusicPlayers = FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length;   
        
        if(numOfMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
