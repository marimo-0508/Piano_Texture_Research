using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Ground : MonoBehaviour {
//public GameObject bomb; // ノートに細い攻撃の矩形が当たった際の爆発エフェクト
public GameObject blockPrefab; // field用

void Start () {
	for (int i = -20; i < 20; i++)
	{
		for (int j = -5; j < 20; j++) {
			GameObject block = Instantiate(blockPrefab, new Vector3(i * 5, -15, j * 5), Quaternion.identity);
			block.name = "block" + "_" + i + "_" + j; // 名前の変更
		}
	}
}

// Update is called once per frame
	void Update () {
	}


}
