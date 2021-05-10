using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab = null;
    [SerializeField] GameObject scoreTriggerPrefab = null;
    [SerializeField] float outerLimit = 2.8f; // max top or bottom
    [SerializeField] float gapBetweenPipesY = 3.4f; // between top/bottom pair for an x
    [SerializeField] float gapBetweenPipesX = 5f; // between top/bottom pair and the next
    [SerializeField] float maxDeltaY = 6f; // between a top/bottom pair and the next
    [SerializeField] float superCliffChance = 0.2f; // % per pair
    
    const int nPoolItems = 5; // number of top/bottom pairs to generate
    const float scoreTriggerOffsetX = 1.2f;
    const int nSkip = 2;

    float halfGapY;
    float limitCenterY;
    float x;
    float centerY;
    List<PoolItem> pool;
    int nSkipped;
    int nextPoolItemIndex;
    
    class PoolItem {
        public GameObject top;
        public GameObject bottom;
        public GameObject scoreTrigger;
    }

    // Start is called before the first frame update
    void Start()
    {
        nSkipped = 0;
        nextPoolItemIndex = 0;
        halfGapY = gapBetweenPipesY * 0.5f;
        limitCenterY = outerLimit - halfGapY;

        pool = new List<PoolItem>(nPoolItems);
        for(int i = 0; i < nPoolItems; i++){
            var poolItem = new PoolItem();
            poolItem.bottom = Instantiate(obstaclePrefab, new Vector3(), Quaternion.identity, this.transform);
            poolItem.top = Instantiate(obstaclePrefab, new Vector3(), Quaternion.AngleAxis(180, Vector3.forward), this.transform);
            poolItem.scoreTrigger = Instantiate(scoreTriggerPrefab, new Vector3(), Quaternion.identity, this.transform);
            pool.Add(poolItem);
        }
        
        x = 0f;
        centerY = 0f;
        for(int i = 0; i < nPoolItems; i++)
        { 
            AddSet(i);
        }
    }

    void OnGodSaysExtendLevel() {
        nSkipped++;
        if(nSkipped > nSkip){
            AddSet(nextPoolItemIndex);
            nextPoolItemIndex++;
            if(nextPoolItemIndex >= nPoolItems){
                nextPoolItemIndex = 0;
            }
        }
    }

    void AddSet(int poolItemIndex){
        float topY = centerY + halfGapY;
        float bottomY = centerY - halfGapY;

        var poolItem = pool[poolItemIndex];
        poolItem.bottom.transform.position = new Vector3(x, bottomY, 0f);
        poolItem.top.transform.position = new Vector3(x, topY, 0f);
        poolItem.scoreTrigger.transform.position = new Vector3(x + scoreTriggerOffsetX, 0f);

        x += gapBetweenPipesX;

        if(Random.value > superCliffChance)
        {
            centerY += Random.Range(-1f * 0.5f * maxDeltaY, 0.5f * maxDeltaY);
        }
        else // make a super cliff
        { 
            centerY = 1000f * Mathf.Sign(centerY) * -1f;
        }

        centerY = Mathf.Clamp(centerY, -limitCenterY, limitCenterY);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
