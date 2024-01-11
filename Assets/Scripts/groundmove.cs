using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.Euler(0, 0, 15);
        transform.Translate(-0.1f, 0, 0);
        //弾の位置が-5よりも左に移動していた場合、
        if (transform.position.x < -15.0f)
        {
            //弾を破棄する
            Destroy(gameObject);
        }
    }
}
