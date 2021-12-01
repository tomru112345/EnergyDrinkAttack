using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class eye_control : MonoBehaviour
{
    int value;
    GameObject eye_openObject;
    GameObject eye_closeObject;
    bool isGameClear = false;
    bool isGameOver = false;
    public Text Message;

    public bool Eye_opend = false;

    float seconds;
    void Start()
    {
        this.eye_openObject = GameObject.Find("eye_open");
        this.eye_closeObject = GameObject.Find("eye_close");
        this.eye_openObject.SetActive(false);
    }

    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= 2)
        {
            value = Random.Range(0, 10);
            if (value > 6)
            {
                Eye_opend = true;
                this.eye_openObject.SetActive(true);
                this.eye_closeObject.SetActive(false);
            }
            else
            {
                Eye_opend = false;
                this.eye_openObject.SetActive(false);
                this.eye_closeObject.SetActive(true);
            }
            seconds = 0;
        }

        if ((isGameClear || isGameOver) && Input.GetButtonDown("Submit"))
        {
            // シーンのロード
            Time.timeScale = 1f;
            SceneManager.LoadScene("TitleScene");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Eye_opend)
            {
                Message.text = "覚醒";
                isGameClear = true;
            }
            else
            {
                isGameOver = true;
                Message.text = "激痛";
            }

        }
    }
}
