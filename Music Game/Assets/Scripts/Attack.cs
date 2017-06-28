using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ---*---*--- 流れてくるノートを破壊するエフェクトのプログラム ---*---*--- //
public class Attack : MonoBehaviour
{
    // ---*--- 変数一覧 ---*--- //
    public GameObject[] attack; // 5種類のノートを格納するための配列
    private int number; // 何番目のノートに対応しているか示す変数
    private bool flag; // Cubeの発生を判定する変数
    
    void Start()
    {
        flag = false;// 初期状態はflagをfalseにする
    }

    void Update()
    {
        // z キーが押された時
        if (Input.GetKeyDown(KeyCode.D)) // Dのキーが押された時
        {
            flag = true; // flagをtrueにする
            number = 0; // numに0を代入
        }
        if (Input.GetKeyDown(KeyCode.F)) // Fのキーが押された時
        {
            flag = true; // flagをtrueにする
            number = 1; // numに1を代入
        }
        if (Input.GetKeyDown(KeyCode.G)) // Gのキーが押された時
        {
            flag = true; // flagをtrueにする
            number = 2; // numに2を代入
        }
        if (Input.GetKeyDown(KeyCode.H)) // Hのキーが押された時
        {
            flag = true; // flagをtrueにする
            number = 3; // numに3を代入
        }
        if (Input.GetKeyDown(KeyCode.J)) // Jのキーが押された時
        {
            flag = true; // flagをtrueにする
            number = 4; // numに4を代入
        }
        if (flag) // flagがtrueの時
        {
            SpawnAttck(); //SpawnCube関数の実行
        }
    }

    // ---*--- 4細いCubeを生成する関数 ---*--- //
    void SpawnAttck()
    {
        transform.rotation = Quaternion.Euler(-90, 0, 0); // 回転させた状態を初期設定
        GameObject attack_eff = Instantiate(attack[number], new Vector3(-4.0f + (2.0f * number), 5.0f, -21.0f), transform.rotation) as GameObject;
        // cubenというゲームオブジェクトに一度代入しておく(Destroyされた際にオリジナルが消滅されるのを防ぐ)
        attack_eff.name = "attack" + number; //名前を変更
        flag = false; // flagをfalseにする
        Destroy(attack_eff, 1.5f); // 生成後1.5fに消滅

    }

}
