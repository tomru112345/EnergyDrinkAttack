using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 速さを指定する変数
    public float speed = 10f;
    // Vector2 startPos;
    // Rigidbody2D rigid2d;
    Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        // Rigidbodyにアクセスして変数に保持しておく
        myRigidbody = GetComponent<Rigidbody>();
        // rigid2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       // 左右のキー入力により速度を変更する
        myRigidbody.velocity = new Vector3(0f, Input.GetAxis("Vertical") * speed, 0f);

        // マウスの動きと反対方向に発射される
        if (Input.GetMouseButtonDown(0)){
            Vector3 nowPos = this.transform.position;
            nowPos.x += 1000 * speed;
            myRigidbody.AddForce(nowPos.x, nowPos.y, 0);
        } 
    }

    // 何かとぶつかった時に呼ばれるビルトインメソッド
    void OnCollisionEnter(Collision collision)
    {
        Time.timeScale = 0f;
        // なにかに当たったとき止まる
        myRigidbody.velocity = new Vector3(0f, 0f, 0f);
    }
}
