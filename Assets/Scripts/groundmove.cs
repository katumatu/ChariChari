using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundmove : MonoBehaviour
{

    private float Gspeed;

    // Start is called before the first frame update
    void Start()
    {
        Gspeed = -0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.quickflg == true)
        {
            Gspeed = -0.2f - ((float)scoreMan.score / 500000);
        }

        if(player.quickflg == false)
        {

            Gspeed = -0.1f - ((float)scoreMan.score / 500000);
            //transform.rotation = Quaternion.Euler(0, 0, 15);
        }

        //弾の位置が-5よりも左に移動していた場合、
        if(transform.position.x < -15.0f)
        {
            //弾を破棄する
            Destroy(gameObject);
        }

        transform.Translate(Gspeed, 0, 0);
    }
}
