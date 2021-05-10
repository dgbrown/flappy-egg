using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FloppyTurdController : MonoBehaviour
{
    [SerializeField] GameObject goSprite;
    [SerializeField] GameObject goDeathEffect;
    [SerializeField] ParticleSystem jumpEffect;

    [SerializeField] float gravityForce = 20f;
    [SerializeField] float repeatFlapForce = 6f;
    [SerializeField] float firstFlapForce = 9f;
    [SerializeField] float velocityX = 4f;
    [SerializeField] bool isGod = false;

    new Rigidbody2D rigidbody2D;

    Vector2 velocity;
    bool isDead = false;
    bool isPlayStarted = false;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnGodSaysGameStateChanged(GameState newState)
    {
        if(newState == GameState.PLAYING)
        {
            isPlayStarted = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPlayStarted)
            return;
        if(isDead)
            return;

        velocity.x = velocityX;
        velocity += Time.deltaTime * Vector2.down * gravityForce;

        if(_.DidInputOnce())
        {
            if(jumpEffect){
                jumpEffect.Play();
            }
            if(velocity.y <= 0f)
            {
                velocity.y = firstFlapForce;
            }
            else
            {
                velocity += Vector2.up * repeatFlapForce;
            }
        }

        Vector3 newPos = transform.position;
        newPos.x += Time.deltaTime * velocity.x;
        newPos.y += Time.deltaTime * velocity.y;
        transform.position = newPos;
    }

    void Kill()
    {
        if(isGod)
            return;

        if(isDead)
            return;

        goDeathEffect.SetActive(true);
        goSprite.SetActive(false);
        goSprite.transform.SetParent(transform.parent);

        velocity = Vector2.zero;
        rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        isDead = true;
        SendMessageUpwards("OnPlayerDied");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(!isDead){
            Kill();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SendMessageUpwards("OnPlayerScored", null, SendMessageOptions.RequireReceiver);
        SendMessageUpwards("OnPlayerCrossedCheckpoint");
    }
}
