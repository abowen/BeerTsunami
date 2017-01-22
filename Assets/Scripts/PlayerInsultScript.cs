﻿using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class PlayerInsultScript : MonoBehaviour, IPlayer, IPheromones
{
    public int PlayerNumber = 1;

    private Rigidbody _rigidBody;

    private Text _voiceText;
    private string[] _text = new[] { "You bogan", "Wanker", "Arsehole", "Get a job!", "Truckie", "Dole bludger", "Peasant", "Inbred", "Dero", "Dog", "Mug", "Piker", "Drop out", "Sook", "Wuss" };

    private float _nextBBQ = 0.5f;
    private float _timeBetweenBBQ = 2f;
    private float time = 0;

    public GameObject BBQ;
    public Transform BBQSpawn;
    public int NumberOfBBQs = 10;

    // Use this for initialization
    private PlayerInputButtonKeys _inputButtonKeys;

    // Use this for initialization
    void Start()
    {
        _inputButtonKeys = PlayerInputButtonKeys.CreateForPlayer(PlayerNumber);
        print("Parent GameObject: " + gameObject.name);
        _rigidBody = gameObject.GetComponent<Rigidbody>();
        _voiceText = gameObject.GetComponentInChildren<Text>();

        print("Voice Text: " + _voiceText.name);
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if (Input.GetButton(_inputButtonKeys.DropBBQKey) && NumberOfBBQs > 0 && time > _nextBBQ)
        {
            _nextBBQ = _timeBetweenBBQ + time;
            NumberOfBBQs -= 1;
            Instantiate(BBQ, BBQSpawn.position, BBQSpawn.rotation);
        }
    }

    private string GetRandomInsult()
    {
        https://docs.unity3d.com/ScriptReference/Random.Range.html
        var insultIndex = Random.Range(0, _text.Length);
        return _text[insultIndex];
    }

    void FixedUpdate()
    {
        if ((Input.GetKey(KeyCode.Space) && PlayerNumber == 1) ||
            Input.GetKey(KeyCode.Return) && PlayerNumber == 2)
        {
            print("space pressed");
            // TODO: Replace with dictionary of colloquial terms
            //_rigidBody.AddForce(new Vector3())
            _rigidBody.AddTorque(0, 50, 0);
            _voiceText.text = GetRandomInsult();
        }
    }
}
 