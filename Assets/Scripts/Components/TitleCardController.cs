using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCardController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGodSaysGameStateChanged(GameState newState)
    {
         if(newState == GameState.PLAYING)
        {
            gameObject.SetActive(false);
        }
    }
}
