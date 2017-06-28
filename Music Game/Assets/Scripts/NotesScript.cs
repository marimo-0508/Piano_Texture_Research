using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
// ---*---*--- ノートの動き(常に流れ続ける)を管理するプログラム ---*---*--- //
public class NotesScript : MonoBehaviour
{
    // ---*--- 変数一覧 ---*--- //
    public int lineNum; // 列の番号(どの鍵盤のノートを指すか)を示す変数)
    private GameManager _gameManager; // GameManager型の変数を用意
    public GameObject effect; // ノートに細い攻撃の矩形が当たった際の爆発エフェクト
    public Text score_text;
    public int score; // score用
    //private int sum;
    //private List<int> pass_num = new List<int>();
    
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        // GameManagerオブジェクトを見つけて代入
        score_text = this.GetComponent<Text>();
        score = 0;

    }

    void Update()
    {
        this.transform.position += Vector3.back * 10 * Time.deltaTime; // back方向(z軸方向)へと速度10で移動
        
        if (this.transform.position.z < -30.0f) // zの値が-0を超えた時
        {
            GameManager d2 = _gameManager.GetComponent<GameManager>();
            d2.Count_score(1); // 点数カウント(失敗数)をカウントしている
           
            Debug.Log("false"); // Debugにfalse(失敗)と表示される
            Destroy(this.gameObject); // オブジェクトを消滅
            
        }
        


    }

    // ---*--- 衝突判定 ---*--- //
    void OnTriggerStay(Collider other) // 衝突判定(OnTriggerStayは衝突している間呼ばれる)
    {
        switch (lineNum) // lineNumの値の判定
        {
            case 0: // 0の時
                CheckInput(KeyCode.D); // CheckInput関数にDを代入
                break;
            case 1: // 1の時
                CheckInput(KeyCode.F); // CheckInput関数にFを代入
                break;
            case 2: // 2の時
                CheckInput(KeyCode.G); // CheckInput関数にGを代入
                break;
            case 3: // 3の時
                CheckInput(KeyCode.H); // CheckInput関数にHを代入
                break;
            case 4: // 4の時
                CheckInput(KeyCode.J); // CheckInput関数にJを代入
                break;
            default: // default節では何もしない
                break;
        }
    }

    // ---*--- キー入力のタイミングを判定する関数 ---*--- //
    void CheckInput(KeyCode key)
    {
        if (Input.GetKeyDown(key)) // キーが押された時
        {
            _gameManager.GoodTimingFunc(lineNum); // lineNumの値をGoodTimingFunc関数に代入
        }
    }

    // ---*--- 爆発エフェクト処理 ---*--- //
    private void OnTriggerEnter(Collider other)
    {
        
        Destroy(gameObject); // ぶつかったオブジェクト全破壊
        Vector3 hitPos = other.ClosestPointOnBounds(this.transform.position);
        // 変数hitPosにぶつかった位置を検出し代入
        GameObject eff = Instantiate(effect, hitPos, transform.rotation);
        // 爆発エフェクトを生成
        Destroy(eff, 1.5f);
        // 1.5fに破壊
        /*if (GameManager._score > 0) {
            GameObject t = GameObject.Find("fire" + GameManager._score);
            Destroy(t);
        }*/
    }
    
}
