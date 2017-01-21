using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class PlayerScript : MonoBehaviour
{
    public int PlayerNumber = 1;
    public float Speed = 10f;

    private Rigidbody _rigidBody;
    private Text _voiceText;

    private float _nextBBQ = 0.5f;
    private float _timeBetweenBBQ = 2f;
    private float time = 0;

    public GameObject BBQ;
    public Transform BBQSpawn;
    public int NumberOfBBQs = 10;

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

        if ((Input.GetKey(KeyCode.Space) && PlayerNumber == 1) ||
            Input.GetKey(KeyCode.Return) && PlayerNumber == 2)
        {
            print("space pressed");
            // TODO: Replace with dictionary of colloquial terms
            _voiceText.text = "Wanker!";
        }

        var movement = new Vector3(xDirection, 0, yDirection).normalized * Speed * Time.deltaTime;
        var newPosition = _rigidBody.position += movement;
        _rigidBody.MovePosition(newPosition);
    }
}
 