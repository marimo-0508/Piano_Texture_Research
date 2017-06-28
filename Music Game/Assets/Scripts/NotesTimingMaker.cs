using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// ---*---*--- 楽曲を再生するクラス ---*---*--- //

public class NotesTimingMaker : MonoBehaviour
{

    // ---*--- 楽曲を再生する変数 ---*--- //
    private AudioSource _audioSource; // Audioを管理する変数
    public GameObject startButton; // StartするButtonの管理

    // ---*--- タイミングデータを打ち込むキー変数 ---*--- //
    private float _startTime = 0;
    private CSVWriter _CSVWriter;
    private bool _isPlaying = false;

    void Start()
    {
        _audioSource = GameObject.Find("GameMusic").GetComponent<AudioSource>();
        // GameMusic(楽曲データ)のオブジェクトを取得
        _CSVWriter = GameObject.Find("CSVWriter").GetComponent<CSVWriter>();
        // CSVWriterのオブジェクトを取得
    }

    void Update()
    {
        if (_isPlaying == true)
        {
            DetectKeys();
        }
    }

    // ---*--- 楽曲を再生する関数 ---*--- //
    public void StartMusic() // 曲を再生させる関数
    {
        _audioSource.Play(); // 曲を再生
        _startTime = Time.time; // 現在の時間を取得
        _isPlaying = true; // 曲が再生されたら_isPlayingをtrueに変える
    }

    // ---*--- どのキーが押されたか管理する関数 ---*--- //
    void DetectKeys()
    {
        if (Input.GetKeyDown(KeyCode.A)) // 間奏
        {
            WriteNotesTiming(0);
        }
        if (Input.GetKeyDown(KeyCode.W)) // C3(ド)
        {
            WriteNotesTiming(1);
        }
        if (Input.GetKeyDown(KeyCode.E)) // D3(レ) 
        {
            WriteNotesTiming(2);
        }
        if (Input.GetKeyDown(KeyCode.R)) // E3(ミ)
        {
            WriteNotesTiming(3);
        }
        if (Input.GetKeyDown(KeyCode.T)) // F3(ファ)
        {
            WriteNotesTiming(4);
        }
        if (Input.GetKeyDown(KeyCode.Y)) // G3(ソ)
        {
            WriteNotesTiming(5);
        }
        if (Input.GetKeyDown(KeyCode.U)) // A3(ラ)
        {
            WriteNotesTiming(6);
        }
        if (Input.GetKeyDown(KeyCode.I)) // B3(シ)
        {
            WriteNotesTiming(7);
        }
        if (Input.GetKeyDown(KeyCode.W)) // C4(ド)
        {
            WriteNotesTiming(8);
        }
        if (Input.GetKeyDown(KeyCode.E)) // D4(レ) 
        {
            WriteNotesTiming(9);
        }
        if (Input.GetKeyDown(KeyCode.R)) // E4(ミ)
        {
            WriteNotesTiming(10);
        }
        if (Input.GetKeyDown(KeyCode.T)) // F4(ファ)
        {
            WriteNotesTiming(11);
        }
        if (Input.GetKeyDown(KeyCode.Y)) // G4(ソ)
        {
            WriteNotesTiming(12);
        }
        if (Input.GetKeyDown(KeyCode.U)) // A4(ラ)
        {
            WriteNotesTiming(13);
        }
        if (Input.GetKeyDown(KeyCode.I)) // B4(シ)
        {
            WriteNotesTiming(14);
        }
        if (Input.GetKeyDown(KeyCode.S)) // C5(ド)
        {
            WriteNotesTiming(15);
        }
        if (Input.GetKeyDown(KeyCode.D)) // D5(レ) 
        {
            WriteNotesTiming(16);
        }
        if (Input.GetKeyDown(KeyCode.F)) // E5(ミ)
        {
            WriteNotesTiming(17);
        }
        if (Input.GetKeyDown(KeyCode.G)) // F5(ファ)
        {
            WriteNotesTiming(18);
        }
        if (Input.GetKeyDown(KeyCode.H)) // G5(ソ)
        {
            WriteNotesTiming(19);
        }
        if (Input.GetKeyDown(KeyCode.J)) // A5(ラ)
        {
            WriteNotesTiming(20);
        }
        if (Input.GetKeyDown(KeyCode.K)) // B5(シ)
        {
            WriteNotesTiming(21);
        }
    }
    void WriteNotesTiming(int num)
    {
        Debug.Log(GetTiming());
        _CSVWriter.WriteCSV(GetTiming().ToString() + "," + num.ToString());
        // 例えば2.3秒にSが、4.1秒にGが押されると、(2.3, 0)と(4.1, 3)という形でcsvに保存される
    }

    float GetTiming()
    {
        return Time.time - _startTime; // スタートしてから何秒経過したかをreturn
    }
}


