using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public bool shouldFollow = true;
    public bool shouldMatchX = true;
    public bool shouldMatchY = true;
    public Transform target;
    
    Vector3 followOffset;

    // Start is called before the first frame update
    void Start()
    {
        followOffset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!shouldFollow)
            return;

        Vector3 newPosition = transform.position;
        if(shouldMatchX)
        {
            newPosition.x = target.position.x + followOffset.x;
        }
        if(shouldMatchY)
        {
            newPosition.y = target.position.y + followOffset.y;
        }
        transform.position = newPosition;
    }

    void OnGodSaysGameStateChanged(GameState newState)
    {
        if(newState == GameState.WAIT_FOR_RESTART)
        {
            shouldFollow = false;
        }
    }
}
