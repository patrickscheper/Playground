using UnityEngine;
using System.Collections;

public class NucleonSpawner : MonoBehaviour {

    public float timeBetweenSpawns;

    public float spawnDistance;

    public NucleonOperator[] nucleonPrefabs;

    private float timeSinceLastSpawn;

    public int maxNucleons;
    public int currentNucleons;

	void Start ()
    {
	
	}
	

	void FixedUpdate ()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if(timeSinceLastSpawn >= timeBetweenSpawns && currentNucleons <= maxNucleons)
        {
            timeSinceLastSpawn -= timeBetweenSpawns;
            SpawnNucleon();
        }
	}

    void SpawnNucleon()
    {
        currentNucleons += 1;
        NucleonOperator prefab = nucleonPrefabs[Random.Range(0, nucleonPrefabs.Length)];
        NucleonOperator spawn = Instantiate<NucleonOperator>(prefab);
        spawn.transform.localPosition = Random.onUnitSphere * spawnDistance;
    }
}
