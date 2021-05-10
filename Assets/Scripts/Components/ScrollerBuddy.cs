using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollerBuddy : MonoBehaviour
{
    [SerializeField]
    InfiniteScrollItem template;

    List<GameObject> objectPool;
    [SerializeField] int poolSize;
    
    int nSKipped;
    int instancesSpawned;
    int nextPoolIndex;

    // Start is called before the first frame update
    void Start()
    {
        instancesSpawned = 0;
        nextPoolIndex = 0;
        objectPool = new List<GameObject>(poolSize);

        template.gameObject.SetActive(false);
        for(int i = 0; i < poolSize; i++)
        {
            var go = Instantiate(template.gameObject, transform);
            go.SetActive(true);
            objectPool.Add(go);
            PlaceNext();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_.GetCameraRightEdgeWorldX() >= transform.position.x + template.width * (instancesSpawned-1))
        {
            PlaceNext();
        }
    }

    void PlaceNext()
    {
        var go = objectPool[nextPoolIndex];
        go.transform.localPosition = new Vector3(template.width * instancesSpawned, 0f, 0f);
        instancesSpawned++;

        nextPoolIndex++;
        if(nextPoolIndex >= poolSize){
            nextPoolIndex = 0;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        float x = _.GetCameraRightEdgeWorldX();
        Gizmos.DrawLine(new Vector3(x, -5f, 0f), new Vector3(x, 5f, 0f));

        Gizmos.color = Color.blue;
        x = transform.position.x + template.width * (instancesSpawned-1);
        Gizmos.DrawLine(new Vector3(x, -5f, 0f), new Vector3(x, 5f, 0f));
    }
}
