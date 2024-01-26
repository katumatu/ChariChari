using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcreate : MonoBehaviour
{
	//スクリプトに格納するもの
    public GameObject groundPrefab; //生成する隕石のプレハブ
    
    void Start()
    {
        // コルーチンを開始
        StartCoroutine(GenGround());

        //初期の足場を生成
        Instantiate(groundPrefab, new Vector3(-2.0f, 0.0f, 0), Quaternion.identity);
        Instantiate(groundPrefab, new Vector3(3.0f, -2.0f + 1.0f * Random.value, 0), Quaternion.identity);
        Instantiate(groundPrefab, new Vector3(8.0f, -3.5f + 1.5f * Random.value, 0), Quaternion.identity);
        Instantiate(groundPrefab, new Vector3(13.0f, -5.0f + 2.0f * Random.value, 0), Quaternion.identity);
        Instantiate(groundPrefab, new Vector3(18.0f + 2.0f * Random.value, -5.0f + 5.0f * Random.value, 0), Quaternion.identity);
    }

    /*void GenRock()
    {
        if(player.quickflg == true)
        {
            x = 0.5f;
            //画面の上部端より少し上から、画面の左端から右端の間でランダムな位置に隕石を生成する
            //Instantiate(groundPrefab, new Vector3(15.5f + 2.0f * Random.value, (-4.0f - ((float)scoreMan.score / 5000000)) + (3.0f + ((float)scoreMan.score / 1000000)) * Random.value, 0), Quaternion.identity);
        }

        if(player.quickflg == false)
        {
            x = 1;
        }

        //画面の上部端より少し上から、画面の左端から右端の間でランダムな位置に隕石を生成する
        Instantiate(groundPrefab, new Vector3(20.0f + 2.0f * Random.value, (-4.0f - ((float)scoreMan.score / 5000000)) + (3.0f + ((float)scoreMan.score / 1000000)) * Random.value, 0), Quaternion.identity);
    }*/

    private IEnumerator GenGround()
    {
        while (true)
        {
            if(player.quickflg == true)
            {
                Instantiate(groundPrefab, new Vector3(20.0f + 2.0f * Random.value, (-4.0f - ((float)scoreMan.score / 5000000)) + (3.0f + ((float)scoreMan.score / 1000000)) * Random.value, 0), Quaternion.identity);
            }
            // 0.5秒待つ
            yield return new WaitForSeconds(0.5f);
            Instantiate(groundPrefab, new Vector3(20.0f + 2.0f * Random.value, (-4.0f - ((float)scoreMan.score / 5000000)) + (3.0f + ((float)scoreMan.score / 1000000)) * Random.value, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
