using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoganScript : MonoBehaviour
{
    public float MinimumDistance = 1;
    public float MaximumDistance = 100;
    public float Speed = 1;

    private FindNearestPlayerScript _nearestPlayerScript;
    private Rigidbody _rigidBody;

    void Start()
    {
        // https://docs.unity3d.com/Manual/ControllingGameObjectsComponents.html        
        _nearestPlayerScript = gameObject.GetComponent<FindNearestPlayerScript>();
        _rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (_nearestPlayerScript == null || _nearestPlayerScript.ClosestPlayer == null)
        {
            return;
        }
        var player = _nearestPlayerScript.ClosestPlayer.transform;

        // Rotate towards player
        transform.LookAt(player);
        var distance = Vector3.Distance(transform.position, player.position);

        if (distance >= MinimumDistance &&
            distance <= MaximumDistance)
        {
            _rigidBody.MovePosition(transform.position += transform.forward * Speed * Time.deltaTime);
        }

        // TODO: Could do certain things like:
        // - if < minimum distance, punch the player
        // - if > maximum distance, yell at them
    }
}
