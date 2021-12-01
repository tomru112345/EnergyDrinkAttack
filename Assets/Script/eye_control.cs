using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class eye_control : MonoBehaviour
{
    int value;
    GameObject eye_openObject;
    GameObject eye_closeObject;

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
                this.eye_openObject.SetActive(true);
                this.eye_closeObject.SetActive(false);
            }
            else
            {
                this.eye_openObject.SetActive(false);
                this.eye_closeObject.SetActive(true);
            }
            seconds = 0;
        }
    }
}
