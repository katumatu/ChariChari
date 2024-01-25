using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryMove : MonoBehaviour
{

    public float fadeSpeed; // 透明度を変更する速さ
    private SpriteRenderer spriteRenderer;
    float rotSpeed; //回転速度
    private float Tspeed;

    // Start is called before the first frame update
    void Start()
    {
        // SpriteRenderer コンポーネントを取得
        spriteRenderer = GetComponent<SpriteRenderer>();

        // オブジェクトの色を初期化（透明度を1.0に設定）
        Color initialColor = spriteRenderer.color;
        initialColor.a = 1.0f;
        spriteRenderer.color = initialColor;

        this.fadeSpeed = 1f + 5f * Random.value; //回転速度をランダムに設定
        this.rotSpeed = 10f + 15f * Random.value; //回転速度をランダムに設定

        Tspeed = -0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        // 現在の透明度を取得
        Color currentColor = spriteRenderer.color;

        // 新しい透明度を計算
        float newAlpha = currentColor.a - fadeSpeed * Time.deltaTime;

        // 透明度が0以下にならないように制御
        newAlpha = Mathf.Clamp01(newAlpha);
            
        // 新しい透明度を設定
        currentColor.a = newAlpha;

        // オブジェクトの色を更新
        spriteRenderer.color = currentColor;

        //透明度が0になったら
        if(newAlpha <= 0f)
        {
            //オブジェクトを非表示にする
            //gameObject.SetActive(false);

            //弾を破棄する
            Destroy(gameObject);
        }

        if(player.quickflg == true)
        {
            Tspeed = -0.2f - ((float)scoreMan.score / 500000);
        }

        if(player.quickflg == false)
        {
            Tspeed = -0.1f - ((float)scoreMan.score / 500000);
        }
        //transform.rotation = Quaternion.Euler(0, 0, 15);
        //transform.Translate(-0.1f, 0, 0, Space.World);
        //軌跡の位置が-14よりも左に移動していた場合、
        if(transform.position.x < -14.0f)
        {
            //弾を破棄する
            Destroy(gameObject);
        }

        //transform.rotation = Quaternion.Euler(0, 0, 15);
        transform.Translate(Tspeed, 0, 0, Space.World);
        transform.Rotate(0, 0, rotSpeed); //隕石を回転させる
    }
}
