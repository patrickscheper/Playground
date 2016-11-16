using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {

    public float timeBetweenSpawns;

    public ObjectOperator[] objectPrefabs;

    float timeSinceLastSpawn;

    public float velocity;

	void FixedUpdate ()
    {

        timeSinceLastSpawn += Time.deltaTime;
        if(timeSinceLastSpawn >= timeBetweenSpawns)
        {
            timeSinceLastSpawn -= timeBetweenSpawns;
            SpawnObjects();
        }
	
	}

    void SpawnObjects()
    {
        ObjectOperator prefab = objectPrefabs[Random.Range(0, objectPrefabs.Length)];
        ObjectOperator spawn = Instantiate<ObjectOperator>(prefab);
        spawn.transform.localPosition = transform.position;
        spawn.Body.velocity = transform.up * velocity;
    }
}
