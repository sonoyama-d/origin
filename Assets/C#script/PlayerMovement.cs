using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 0.2f;

    // ★追加
    private Vector3 pos;

    void Update()
    {

        // Inputの前に「-」を付ける。
        float moveH = -Input.GetAxis("Horizontal") * moveSpeed;
        float moveV = -Input.GetAxis("Vertical") * moveSpeed;
        transform.Translate(moveH, 0.0f, moveV);

        // ★追加
        Clamp();
    }

    // ★追加
    // プレーヤーの移動できる範囲を制限する命令ブロック
    void Clamp()
    {

        // プレーヤーの位置情報を「pos」という箱の中に入れる。
        pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -20, 20);
        pos.z = Mathf.Clamp(pos.z, -23,1);

        transform.position = pos;
    }
}