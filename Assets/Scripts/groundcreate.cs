using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcreate : MonoBehaviour
{
	//スクリプトに格納するもの
    public GameObject groundPrefab; //生成する隕石のプレハブ
    
    void Start()
    {
        //1秒後から、1秒ごとにGenRockメソッドを繰り返し実行する
        InvokeRepeating("GenRock", 1, 1);
    }

    void GenRock()
    {
        //画面の上部端より少し上から、画面の左端から右端の間でランダムな位置に隕石を生成する
        Instantiate(groundPrefab, new Vector3(12.0f + 2.0f * Random.value, -5.0f + 5.0f * Random.value, 0), Quaternion.identity);
    }
}
