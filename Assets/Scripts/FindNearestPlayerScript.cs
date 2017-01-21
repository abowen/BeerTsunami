using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FindNearestPlayerScript : MonoBehaviour {

    public GameObject ClosestPlayer;

    private GameObject[] _players;
    private Transform[] _playerTransforms;

    void Start ()
    {
        if (_players == null)
        {
            _players = GameObject.FindGameObjectsWithTag("Player");            
        }                    
    }

    // Update is called once per frame
    void Update ()
    {
        ClosestPlayer = GetClosestPlayer();
        // print("Closest Player: " + closestPlayer.name);
	}

    // https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html
    GameObject GetClosestPlayer()
    {                
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject player in _players)
        {
            Vector3 diff = player.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = player;
                distance = curDistance;
            }
        }
        return closest;
    }
}
