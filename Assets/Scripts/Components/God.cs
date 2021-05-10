using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class God : MonoBehaviour
{
    
    int score = 0;
    GameState state = GameState.WAIT_FOR_INPUT;

    // Start is called before the first frame update
    void Start()
    {
        SetState(state); // just so we broadcast the initial state
        BroadcastMessage("OnGodSaysScoreChanged", score);
    }

    // Update is called once per frame
    void Update()
    {
        if(_.DidInputOnce())
        {
            if(state == GameState.WAIT_FOR_INPUT)
            {
                SetState(GameState.PLAYING);
            }
            else if (state == GameState.WAIT_FOR_RESTART)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    IEnumerator DelayedGameOver(float delaySeconds){
        yield return new WaitForSeconds(delaySeconds);
        SetState(GameState.WAIT_FOR_RESTART);
    }

    // Messages sent upwards from playerController
    void OnPlayerCrossedCheckpoint()
    {
        BroadcastMessage("OnGodSaysExtendLevel");
    }
    void OnPlayerDied()
    {
        BroadcastMessage("OnGodSaysPlayerDied");
        StartCoroutine(DelayedGameOver(1f));
    }
    void OnPlayerScored() {
        score++;
        BroadcastMessage("OnGodSaysScoreChanged", score);
    }

    void SetState(GameState newState)
    {
        state = newState;
        BroadcastMessage("OnGodSaysGameStateChanged", newState);
    }

    public GameState GetState(){
        return state;
    }
}
