using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Player : MonoBehaviour
{

    private Rigidbody _rigidBody;
    // private Text _voiceText;

    // Use this for initialization
    void Start()
    {
        print("Parent GameObject: " + gameObject.name);
        _rigidBody = gameObject.GetComponent<Rigidbody>();
        // _voiceText = gameObject.GetComponentInChildren<Text>();

        // print("Voice Text: " + _voiceText.name);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        var xDirection = 0;
        var yDirection = 0;

        if (Input.GetKey(KeyCode.W))
        {
            xDirection = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            xDirection = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            yDirection = 1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            yDirection = -1;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            print("space pressed");
            // _voiceText.text = "Wanker!";
        }

        var movement = new Vector3(_rigidBody.position.x + xDirection, 0, _rigidBody.position.z + yDirection);
        _rigidBody.MovePosition(movement);
    }
}
