using System.Linq;
using UnityEngine;
using Assets.Constants;

public class Bouyancy : MonoBehaviour {

    public int BouyancyModifier = 50;
    private bool _isInWater = false;
    private GameObject water;

    private void Start()
    {
        water = GameObject.FindGameObjectsWithTag(TagNames.Water).FirstOrDefault();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == TagNames.Water)
        {
            _isInWater = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == TagNames.Water)
        {
            _isInWater = false; 
        }
    }

    void FixedUpdate()
    {
        if (_isInWater && water)
        {
            var deltaY = water.transform.position.y - transform.position.y;
            var rigidBody = GetComponent<Rigidbody>();
            var calc = deltaY * BouyancyModifier;

            rigidBody.AddForce(0, calc, 0);
        }
    }
}
