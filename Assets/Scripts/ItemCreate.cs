using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCreate : MonoBehaviour
{

    public GameObject coin; //生成するcoinのプレハブ
    int nff = 0;//50%の確率で生成するようにする為の変数

    public GameObject timer; //生成するtimerのプレハブ
    
    // Start is called before the first frame update
    void Start()
    {
        nff = 0;

        //1秒後から、1秒ごとにgenCOINメソッドを繰り返し実行する
        InvokeRepeating("genCOIN", 1, 1);
        //1秒後から、1秒ごとにgenTIMERメソッドを繰り返し実行する
        InvokeRepeating("genTIMER", 10.0f, 10.0f + 30.0f * Random.value);
    } 

    void genCOIN()
    {
        nff = Random.Range(0, 2);

        if(nff == 1)
        {
            //画面の上部端より少し上から、画面の左端から右端の間でランダムな位置に敵を生成する
            Instantiate(coin, new Vector3(18.0f + 2.0f * Random.value, -3.0f + 5.0f * Random.value, 0), Quaternion.identity);
        }
    }

    void genTIMER()
    {
        if(nff == 1)
        {
            //画面の上部端より少し上から、画面の左端から右端の間でランダムな位置に敵を生成する
            Instantiate(timer, new Vector3(18.0f + 2.0f * Random.value, -3.0f + 5.0f * Random.value, 0), Quaternion.identity);
        }
    }
}
