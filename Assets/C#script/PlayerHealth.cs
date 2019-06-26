using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ★★★（追加）
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public GameObject effectPrefab;
    public AudioClip damageSound;
    public AudioClip destroySound;
    public int playerHP;
    private Slider playerHPSlider;
    public GameObject[] playerIcons;
    public int destroyCount = 0;

    void Start()
    {
        playerHPSlider = GameObject.Find("PlayerHPSlider").GetComponent<Slider>();
        playerHPSlider.maxValue = playerHP;
        playerHPSlider.value = playerHP;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyMissile"))
        {

            playerHP -= 1;
            AudioSource.PlayClipAtPoint(damageSound, Camera.main.transform.position);
            playerHPSlider.value = playerHP;

            Destroy(other.gameObject);

            if (playerHP == 0)
            {

                destroyCount += 1;
                UpdatePlayerIcons();

                GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity) as GameObject;
                Destroy(effect, 1.0f);
                AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
                this.gameObject.SetActive(false);


                // ★★★（追加）
                // 破壊された回数によって場合分けを行います。
                if (destroyCount < 2)
                    // リトライの命令ブロック（メソッド）を１秒後に呼び出す。
                    Invoke("Retry", 1.0f);
                else
                    // ゲームオーバーシーンに遷移する。
                    SceneManager.LoadScene("GameOver");  // （ポイント）GameOverはシーンの名前と一言一句全て同じであること
            }
        }
    }

    void UpdatePlayerIcons()
    {
        for (int i = 0; i < playerIcons.Length; i++)
        {
            if (destroyCount <= i)
                playerIcons[i].SetActive(true);
            else
                playerIcons[i].SetActive(false);
        }
    }

    void Retry()
    {
        this.gameObject.SetActive(true);
        playerHP = 5;
        playerHPSlider.value = playerHP;
    }
}