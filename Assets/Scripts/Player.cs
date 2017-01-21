using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Player : MonoBehaviour
{
    public int PlayerNumber = 1;

    private Rigidbody _rigidBody;
    private Text _voiceText;

    // Use this for initialization
    void Start()
    {
        print("Parent GameObject: " + gameObject.name);
        _rigidBody = gameObject.GetComponent<Rigidbody>();
        _voiceText = gameObject.GetComponentInChildren<Text>();

        print("Voice Text: " + _voiceText.name);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        var xDirection = 0;
        var yDirection = 0;

        if ((Input.GetKey(KeyCode.W) && PlayerNumber == 1) ||
             Input.GetKey(KeyCode.UpArrow) && PlayerNumber == 2)
        {
            xDirection = 1;
        }
        else if ((Input.GetKey(KeyCode.S) && PlayerNumber == 1) ||
             Input.GetKey(KeyCode.DownArrow) && PlayerNumber == 2)
        {
            xDirection = -1;
        }

        if ((Input.GetKey(KeyCode.A) && PlayerNumber == 1) ||
             Input.GetKey(KeyCode.LeftArrow) && PlayerNumber == 2)
        {
            yDirection = 1;
        }
        else if ((Input.GetKey(KeyCode.D) && PlayerNumber == 1) ||
             Input.GetKey(KeyCode.RightArrow) && PlayerNumber == 2)
        {
            yDirection = -1;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            print("space pressed");
            _voiceText.text = "Wanker!";
        }

        var movement = new Vector3(_rigidBody.position.x + xDirection, 0, _rigidBody.position.z + yDirection);
        _rigidBody.MovePosition(movement);
    }
}
