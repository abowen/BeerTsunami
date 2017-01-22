using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandingWaveScript : MonoBehaviour {

    public int Speed = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.localScale += new Vector3(0.02f * Speed, 0, 0);
        gameObject.transform.position += new Vector3(0.01f * Speed, 0, 0);
	}
}
