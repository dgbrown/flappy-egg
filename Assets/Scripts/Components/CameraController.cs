using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    FollowCamera followCamera;

    void Awake() {
        followCamera = GetComponent<FollowCamera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGodSaysPlayerDied() {
        if(followCamera){
            followCamera.enabled = false;
        }
    }
}
