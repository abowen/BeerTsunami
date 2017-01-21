using UnityEngine;

public class WaterLevel : MonoBehaviour {

    private int frame;
    private float yMax;

    public float aCoeff { get; set; }
    public float bCoeff { get; set; }
    public float fCoeff { get; set; }

    void Start () {
        frame = 0;
        aCoeff = 0.001f;
        bCoeff = 0.3f;
        fCoeff = 0.01f;
        yMax = 5.5f;
	}

    private void Update()
    {
        frame++;

        var currentVector = transform.position;

        transform.position = new Vector3
        {
            x = currentVector.x,
            z = currentVector.z,
            y = currentVector.y < yMax ? aCoeff * frame + bCoeff* Mathf.Sin(fCoeff * frame) : currentVector.y
        };
    }
}
