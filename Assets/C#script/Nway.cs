﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nway : MonoBehaviour
{

    public GameObject enemyFireMissilePrefab;
    public int wayNumber;

    void Start()
    {
        for (int i = 0; i < wayNumber; i++)
        {

            // ★改良
            // 小数の場合「f」を必ずつけること。fを忘れるとエラーになります。（ポイント）
            GameObject enemyFireMissile = (GameObject)Instantiate(enemyFireMissilePrefab, transform.position, Quaternion.Euler(0, 7.5f - (7.5f * wayNumber) + (15 * i), 0));

            enemyFireMissile.transform.SetParent(this.gameObject.transform);
        }
    }
}