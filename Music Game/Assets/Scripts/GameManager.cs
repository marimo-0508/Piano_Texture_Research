using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;

// ---*---*--- ゲーム全般のプログラム ---*---*--- //
public class GameManager : MonoBehaviour
{
    // ---*--- ノート関係 ---*--- //
    public GameObject[] notes; // ノートの種類を代入する配列(今回は5個)
    private float[] _timing; // csvファイルからの秒数を入れるための配列
    private int[] _lineNum; // csvファイルの何列目を示すかの配列

    public string filePass; // csvファイルまでのファイルパス
    public int _notesCount = 0; // csvで何番目のノートを数え上げているかの変数

    // ---*---　楽曲関係 ---*--- //
    private AudioSource _audioSource; // 楽曲を示す変数
    private float _startTime = 0; // スタートボタンを押した時間を示す変数

    public float timeOffset = -1;// オフセット(時間の差分)を-1に固定

    private bool _isPlaying = false; // 楽曲を流しているかを示す変数
    public GameObject startButton; // Buttonの設置

    public Text scoreText; // スコアを数え上げていくためのテキスト
    public static int _score = 0; // スコアを算出するための変数

    
    public GameObject firePrefab; // 炎用
	public GameObject fire_cube_Prefab; // 炎用
    public int[] pos_x;
    public int[] pos_y;

    

    void Start()
    {
        _audioSource = GameObject.Find("GameMusic").GetComponent<AudioSource>();
        // GameMusicのオブジェクトを探して代入
        _timing = new float[25]; // 流れてくるノートの秒数をcsvファイルから読み込む配列
        _lineNum = new int[25]; // 流れてくるノートの種類をcsvファイルから読み込む配列

        pos_x = new int[25];
        pos_y = new int[25];

        LoadCSV();// プログラム起動してすぐにcsvファイルを読み込む
        
        for (int i = 0; i < 25; i++) // 炎の発生個所をランダムに指定(配列が今回25なのは25までしか音符のノートがないため)
        {
            pos_x[i] = UnityEngine.Random.Range(-40, 40);
           Debug.Log(pos_x[i]);
            pos_y[i] = UnityEngine.Random.Range(1, 65);
        }

    }

    void Update()
    {
        if (_isPlaying) // _isPlayingがtrueになった時
        {
            CheckNextNotes(); // 次の音符を出現させる関数を実行
            scoreText.text = _score.ToString(); // スコアをString型に変換してテキスト文に表示
        }

        Check("fire");
    }

    public void StartGame() // StartGame関数はInspectorで設定
    {
        startButton.SetActive(false); // StartButtonの状態はfalseにする
        _startTime = Time.time; // 現在時刻を代入
        _audioSource.Play(); // 楽曲の再生
        _isPlaying = true; // 現在演奏しているかどうか判定する変数をtrueにする
    }

    // ---*---　次の音符を管理する関数 ---*--- //
    void CheckNextNotes()
    {
        while (_timing[_notesCount] + timeOffset < GetMusicTime() && _timing[_notesCount] != 0 && _notesCount < 24)
        {
            // 楽曲の現在の再生時間を、あらかじめcsvファイルで設定した音符の時間を超えない
            // csvファイルの設定済みの音符の秒数が0ではない
            // 何番目の音符を現在出現させているかのカウントが27を超えないようにする
            SpawnNotes(_lineNum[_notesCount]); // 音符を生成する関数を実行
            _notesCount++; // 次のノートのカウントに増やす
            //Debug.Log("現在" + _notesCount+"個の音符を生成したところです");
        }
    }

    // ---*---　ノートの生成を行う関数 ---*--- //
    void SpawnNotes(int num)
    {
        Instantiate(notes[num],new Vector3(-4.0f + (2.0f * num), 13.5f, 20),Quaternion.identity);
        // ノートの生成
    }

    // ---*---　csvファイルの読み込むための関数 ---*--- //
    void LoadCSV()
    {
        int i = 0;
        TextAsset csv = Resources.Load(filePass) as TextAsset;
        StringReader reader = new StringReader(csv.text);
        while (reader.Peek() > -1)
        {

            string line = reader.ReadLine();
            string[] values = line.Split(',');
            _timing[i] = float.Parse(values[0])-3.01f; // 行列1列目(ノート発生の時刻を保存)をtiming配列に代入
            _lineNum[i] = int.Parse(values[1]); //　行列2列目(ノート種類を保存)をlineNum配列に代入
            i++;
            if(i > 24)
            {
                break;
            }
        }
    }

    // ---*---　楽曲が始まってから何秒経過したかを計算する関数---*--- //
    float GetMusicTime()
    {
        return Time.time - _startTime; // 現在時刻-曲が始まった時間をreturnする
        
    }

    // ---*---　タイミングを判定する関数---*--- //
    public void GoodTimingFunc(int num)
    {
        Debug.Log("Line:" + num + " good!");
        Debug.Log(GetMusicTime());
        _score++;

    }
    public void Count_score(int i)
    {
        _score += i;
        //Debug.Log(_score);
        GameObject fire = Instantiate(firePrefab, new Vector3(pos_x[_score % 25] , -5.0f, pos_y[_score % 25]), Quaternion.identity);
        fire.name = "fire" + _score; // 名前の変更

    }

    //シーン上のBlockタグが付いたオブジェクトを数える
    void Check(string tagname)
    {
        GameObject[] tagObjects; tagObjects = GameObject.FindGameObjectsWithTag(tagname);
        Debug.Log(tagObjects.Length + "個"); //tagObjects.Lengthはオブジェクトの数
        if (tagObjects.Length == 0)
        {
            Debug.Log(tagname + "タグがついたオブジェクトはありません");
        }
    }
}