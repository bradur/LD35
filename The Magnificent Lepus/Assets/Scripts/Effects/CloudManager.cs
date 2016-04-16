// Date   : 16.04.2016 15:04
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CloudManager : MonoBehaviour {

    [SerializeField]
    private List<GameObject> cloudTypes = new List<GameObject>();

    [SerializeField]
    private Transform spawnXMin;
    [SerializeField]
    private Transform spawnXMax;
    [SerializeField]
    private Transform spawnYMin;
    [SerializeField]
    private Transform spawnYMax;

    [SerializeField]
    private Transform cloudContainer;

    [SerializeField]
    private Transform pooledCloudContainer;

    [SerializeField]
    [Range(0.03f, 0.1f)]
    private float speedMin;

    [SerializeField]
    [Range(0.11f, 0.2f)]
    private float speedMax;

    [SerializeField]
    [Range(0.8f, 3f)]
    private float perlinMin;

    [SerializeField]
    [Range(3f, 6f)]
    private float perlinMax;


    private float timer = 0f;

    [SerializeField]
    [Range(0.5f, 3f)]
    private float spawnInterval;

    [SerializeField]
    [Range(10f, 40f)]
    private int poolSize = 10;
    private List<GameObject> cloudPool = new List<GameObject>();

    void Start () {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject poolObject = (GameObject)Instantiate(cloudTypes[Random.Range(0, cloudTypes.Count - 1)]);
            poolObject.transform.parent = pooledCloudContainer;
            Cloud cloud = poolObject.GetComponent<Cloud>();
            cloud.Init(Random.Range(speedMin, speedMax), Random.Range(perlinMin, perlinMax));
            cloud.gameObject.SetActive(false);
            cloudPool.Add(cloud.gameObject);
        }
    }

    void Update () {
        timer += Time.deltaTime;
        if (timer > spawnInterval)
        {
            timer = 0f;
            SpawnCloud();
        }
    }

    void ReturnCloudToPool(GameObject cloud){
        cloud.transform.parent = pooledCloudContainer;
        cloud.SetActive(false);
        cloudPool.Add(cloud);
    }

    void SpawnCloud()
    {
        if (cloudPool.Count > 0){
            int index = Random.Range(0, cloudPool.Count - 1);
            GameObject newCloud = cloudPool[index];
            newCloud.transform.parent = cloudContainer;
            newCloud.transform.position = new Vector3(
                Random.Range(spawnXMin.position.x, spawnXMax.position.x),
                Random.Range(spawnYMin.position.y, spawnYMax.position.y),
                0f
            );
            cloudPool.RemoveAt(index);
            newCloud.SetActive(true);
        }
    }

    public void CloudCollected(Cloud cloud)
    {
        ReturnCloudToPool(cloud.gameObject);
    }

}
