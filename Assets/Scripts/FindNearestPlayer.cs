using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FindNearestPlayer : MonoBehaviour {

    private GameObject[] _players;
    private Transform[] _playerTransforms;

    void Start ()
    {
        https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html
        if (_players == null)
        {
            _players = GameObject.FindGameObjectsWithTag("Player");
            _playerTransforms = _players.Select(p => p.transform).ToArray();
        }                    
    }

    // Update is called once per frame
    void Update ()
    {        
        var closestPlayer = GetClosestPlayer();
        print("Closest Player: " + closestPlayer.name);
	}

    // https://forum.unity3d.com/threads/clean-est-way-to-find-nearest-object-of-many-c.44315/
    Transform GetClosestPlayer()
    {
        Transform closestPlayer = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (var player in _playerTransforms)
        {
            float distance = Vector3.Distance(player.position, currentPos);
            if (distance < minDistance)
            {
                closestPlayer = player;
                minDistance = distance;
            }
        }
        return closestPlayer;
    }
}
