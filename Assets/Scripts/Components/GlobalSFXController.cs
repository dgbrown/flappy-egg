using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSFXController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGodSaysPlayerDied()
    {
        transform.Find("Game Over").GetComponent<AudioSource>().Play();
        transform.Find("Player Died").GetComponent<AudioSource>().Play();
    }
}
