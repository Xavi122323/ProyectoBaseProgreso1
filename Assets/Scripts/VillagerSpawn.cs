using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] objectToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        spawnVillager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnVillager(){
        int randomNum = Mathf.RoundToInt(Random.Range(0f, objectToSpawn.Length-1));
        Instantiate(objectToSpawn[randomNum],spawnPoints[randomNum].transform.position,Quaternion.identity);
    }
}
