using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScrollItem : MonoBehaviour
{
    public float width;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        _.GizmosDrawCross2D(new Vector2(transform.position.x, transform.position.y), 0.5f);
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(width, 0f, 0f));
        Gizmos.DrawLine(transform.position + new Vector3(width, -0.5f, 0f), transform.position + new Vector3(width, 0.5f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
