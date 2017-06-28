using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Grass : MonoBehaviour {
	public GameObject bomb;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision col)
	{
		
		Destroy(col.gameObject);
		// 爆発エフェクトを生成
		foreach (ContactPoint point in col.contacts) {
			
			Destroy(gameObject);
			Destroy(this.gameObject);
			GameObject bom = Instantiate(bomb, (Vector3)point.point, transform.rotation);
			// 爆発エフェクトを生成
			Destroy(bom, 1.5f);

		}

	}
}
