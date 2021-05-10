using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusTextController : MonoBehaviour
{
    TextMeshProUGUI textRenderer;

    void Awake()
    {
        textRenderer = GetComponent<TextMeshProUGUI>(); 
    }

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
        if(newState == GameState.WAIT_FOR_INPUT)
        {
            textRenderer.text = "PLAY";
        }
        else if(newState == GameState.PLAYING)
        {
            textRenderer.text = "";
        }
        else if(newState == GameState.WAIT_FOR_RESTART)
        {
            textRenderer.text = "GAME OVER";
        }
    }
}
