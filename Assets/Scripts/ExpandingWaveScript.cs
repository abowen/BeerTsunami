using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandingWaveScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.localScale += new Vector3(0.02f, 0, 0);
        gameObject.transform.position += new Vector3(0.01f, 0, 0);
	}
}
