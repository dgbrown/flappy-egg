using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTiledUV : MonoBehaviour
{
    public float scrollRate;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var offset = spriteRenderer.material.mainTextureOffset;
        offset.x = Time.time * scrollRate;
        spriteRenderer.material.mainTextureOffset = offset;
    }
}
