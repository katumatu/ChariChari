using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCreate : MonoBehaviour
{

    public GameObject coin; //生成するcoinのプレハブ
    int nff = 0;
    // Start is called before the first frame update
    void Start()
    {
        nff = 0;

        //1秒後から、1秒ごとにGenRockメソッドを繰り返し実行する
        InvokeRepeating("genCOIN", 1, 1);
    } 

    void genCOIN()
    {
        nff = Random.Range(0, 2);

        if (nff == 1)
        {
            //画面の上部端より少し上から、画面の左端から右端の間でランダムな位置に敵を生成する
            Instantiate(coin, new Vector3(12.0f + 2.0f * Random.value, 0.0f + 5.0f * Random.value, 0), Quaternion.identity);
        }
    }
}
