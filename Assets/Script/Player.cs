using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    // 速さを指定する変数
    public float speed = 10f;
    Rigidbody myRigidbody;

    public bool Clickflg = false;
    Transform myTransform;
    bool isGameClear = false;
    bool isGameOver = false;
    public Text Message;
    void Start()
    {
        // Rigidbodyにアクセスして変数に保持しておく
        myRigidbody = GetComponent<Rigidbody>();
        myTransform = this.transform;
    }

    void Update()
    {
        if ((isGameClear || isGameOver) && Input.GetButtonDown("Submit"))
        {
            // シーンのロード
            SceneManager.LoadScene("TitleScene");
            Time.timeScale = 1f;
        }

        if (!Clickflg)
        {
            // 左右のキー入力により速度を変更する
            myRigidbody.velocity = new Vector3(0f, Input.GetAxis("Vertical") * speed, 0f);
        }
        else
        {
            myRigidbody.velocity = new Vector3(10 * speed, 0f, 0f);
        }

        // マウスの動きと反対方向に発射される
        if (Input.GetMouseButtonDown(0))
        {
            Clickflg = true;
        }
        var gamepad = Gamepad.current;
        if (gamepad == null)
        {
            return;
        }

        if (gamepad.buttonEast.isPressed)
        {
            Clickflg = true;
        }
    }

    // 何かとぶつかった時に呼ばれるビルトインメソッド
    void OnCollisionEnter(Collision collision)
    {
        Time.timeScale = 0f;
        if (collision.gameObject.CompareTag("Face"))
        {
            Message.text = "撃沈";
            isGameOver = true;
        }
        else if (collision.gameObject.CompareTag("wall"))
        {
            Message.text = "遠方";
            isGameOver = true;
        }
    }
}
