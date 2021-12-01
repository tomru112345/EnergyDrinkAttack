using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePosition : MonoBehaviour
{
    public Rigidbody myRigidbody;
	private float speed = 1.0f;
    float angleDiff;
    List<GameObject> childrenList;
    // 半径
    [SerializeField]
	private float radius;

    private void Deploy(){
        //子を取得
        childrenList = new List<GameObject> ();
        foreach(Transform child in transform) {
            childrenList.Add (child.gameObject);
        }

        //数値、アルファベット順にソート
        childrenList.Sort (
            (a, b) => {
                return string.Compare(a.name, b.name);
                }
        );

        //オブジェクト間の角度差
        angleDiff = 360f / (float)childrenList.Count;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Rigidbodyにアクセスして変数に保持しておく
        myRigidbody = GetComponent<Rigidbody>();
        Deploy();
    }

    // Update is called once per frame
    void Update()
    {
        //各オブジェクトを円状に配置
        for (int i = 0; i < childrenList.Count; i++)  {
            Vector3 childPostion = transform.position;
            float angle = (90 - angleDiff * i) * Mathf.Deg2Rad + Time.time * speed;
            childPostion.x += radius * Mathf.Cos (angle);
            childPostion.y += radius * Mathf.Sin (angle);
            childPostion.z = 0;
            childrenList[i].transform.position = childPostion;
        }
    }
}