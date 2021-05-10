using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackgroundController : MonoBehaviour
{

    ScrollTex texScroller;

    void Awake()
    {
        texScroller = GetComponent<ScrollTex>();
    }

    // Start is called before the first frame update
    void Start()
    {
        texScroller.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGodSaysGameStateChanged(GameState newState)
    {
        if(newState == GameState.PLAYING)
        {
            texScroller.enabled = true;
        }
    }

    void OnGodSaysPlayerDied() {
        if(texScroller){
            texScroller.enabled = false;
        }
    }
}
