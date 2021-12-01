using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FontScalable : MonoBehaviour
{
    [Range(1, 6)]
	public float fontScale = 100;
	TextMesh tetxMesh;


	void Start () {
		tetxMesh = GetComponent<TextMesh>();
	}
	
	void Update () 
	{
		Vector3 defaultScale = new Vector3(1,1,1) * fontScale;
		int fontSize = tetxMesh.fontSize;
		fontSize = fontSize == 0 ? 12 : fontSize;

		float scale = 0.1f * 128 / fontSize;
		transform.localScale = defaultScale * scale;
	}
}
