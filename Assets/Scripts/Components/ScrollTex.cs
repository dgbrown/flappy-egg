using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTex : MonoBehaviour
{
    Material material;
    public float scrollSpeedX;
    public float scrollSpeedY;

    // Start is called before the first frame update
    void Start()
    {
        var renderer = GetComponent<MeshRenderer>();
        if(renderer){
            material = renderer.material;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(material){
            var texOffset = material.mainTextureOffset;
            texOffset += new Vector2(scrollSpeedX, scrollSpeedY) * Time.deltaTime;
            material.mainTextureOffset = texOffset;
        }
    }
}
