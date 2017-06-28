using UnityEngine;
using System.Collections;
using System.IO; // csvを管理する際に必要
using System.Collections.Generic;

// ---*---*--- csvファイルのテスト用 ---*---*--- //
public class csvReader : MonoBehaviour
{

    public string fileName; // 保存するファイル名

    // --- テスト用 --- //
    void Start()
    {
        WriteCSV("Hello,World");
    }
    
    void Update()
    {
    }

    // ---*--- 楽曲を再生するクラス ---*--- //
    public void WriteCSV(string txt)
    {
        StreamWriter streamWriter;
        FileInfo fileInfo;
        fileInfo = new FileInfo(Application.dataPath + "/" + fileName + ".csv"); // 取得データを決定
        streamWriter = fileInfo.AppendText();
        streamWriter.WriteLine(txt);
        streamWriter.Flush();
        streamWriter.Close();
    }
}
