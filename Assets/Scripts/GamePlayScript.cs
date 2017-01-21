using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayScript : MonoBehaviour {

    public int GameLength = 15;
    public int GameLengthRemaining;

    public bool Success = false;
    public bool Fail = false;

    private Text _text;

    // Use this for initialization
    void Start () {
        _text = gameObject.GetComponentInChildren<Text>();
    }
	
	// Update is called once per frame
	void Update () {         
        if (Time.unscaledTime > GameLength)
        {
            Fail = true;
            _text.text = "Fail!";
        } else
        {
            GameLengthRemaining = (int)(GameLength - Time.unscaledTime);
            _text.text = GameLengthRemaining.ToString();
        }
    }
}
