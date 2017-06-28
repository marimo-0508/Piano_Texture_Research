using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ---*---*--- 流れてくるノートを破壊する細い矩形のプログラム ---*---*--- //
public class AttackCube : MonoBehaviour {

    // ---*--- 変数一覧 ---*--- //
    public GameObject[] Cube; // 5種類のノートを格納するための配列
    private int num; // 何番目のノートに対応しているか示す変数
    private bool flag; // Cubeの発生を判定する変数

    void Start () {
        flag = false;// 初期状態はflagをfalseにする
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.D)) // Dのキーが押された時
        {
            flag = true; // flagをtrueにする
            num = 0; // numに0を代入
        }
        if (Input.GetKeyDown(KeyCode.F)) // Fのキーが押された時
        {
            flag = true; // flagをtrueにする
            num = 1; // numに1を代入
        }
        if (Input.GetKeyDown(KeyCode.G)) // Gのキーが押された時
        {
            flag = true; // flagをtrueにする
            num = 2; // numに2を代入
        }
        if (Input.GetKeyDown(KeyCode.H)) // Hのキーが押された時
        {
            flag = true; // flagをtrueにする
            num = 3; // numに3を代入
        }
        if (Input.GetKeyDown(KeyCode.J)) // Jのキーが押された時
        {
            flag = true; // flagをtrueにする
            num = 4; // numに4を代入
        }
        if (flag) // flagがtrueの時
        {
            SpawnCube(); //SpawnCube関数の実行
        }
    
    }

    // ---*--- 細いCubeを生成する関数 ---*--- //
    void SpawnCube()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0); // 回転なし
        GameObject cuben = Instantiate(Cube[num], new Vector3(-4.0f + (2.0f * num), 5.0f, -21.0f), transform.rotation) as GameObject;
        // cubenというゲームオブジェクトに一度代入して生成(Destroyされた際にオリジナルが消滅されるのを防ぐ)
        cuben.name = "Cube" + num; // 名前の変更
        flag = false; // flagはfalseにする
        Destroy(cuben, 0.8f); // 生成後0.8fで消滅
    }
}
