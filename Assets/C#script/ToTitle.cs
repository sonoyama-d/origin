using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ★（追加）
using UnityEngine.SceneManagement;

public class ToTitle : MonoBehaviour
{

    // ★（追加）
    // 先頭に「public」をつけること（ポイント）
    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene("Title");
    }
}
