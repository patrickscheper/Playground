using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{

    public ObjectOperator[] objectPrefabs;
    public Material objectMaterial;
    public FloatRange timeBetweenSpawn, scale, randomVelocity, angularVelocity;

    private float timeSinceLastSpawn;

    private float currentSpawnDelay;

    public float velocity;

    void FixedUpdate()
    {

        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= currentSpawnDelay)
        {
            timeSinceLastSpawn -= currentSpawnDelay;
            currentSpawnDelay = timeBetweenSpawn.RandomInRange;
            SpawnObjects();
        }

    }

    void SpawnObjects()
    {
        ObjectOperator prefab = objectPrefabs[Random.Range(0, objectPrefabs.Length)];
        ObjectOperator spawn = prefab.GetPooledInstance<ObjectOperator>();

        spawn.GetComponent<MeshRenderer>().material = objectMaterial;
        spawn.transform.localPosition = transform.position;
        spawn.transform.localScale = new Vector3(1, 1, 1) * scale.RandomInRange;
        spawn.transform.localRotation = Random.rotation;

        spawn.Body.velocity = transform.up * velocity + Random.onUnitSphere * randomVelocity.RandomInRange;
        spawn.Body.angularVelocity = Random.onUnitSphere * angularVelocity.RandomInRange;
    }
}
