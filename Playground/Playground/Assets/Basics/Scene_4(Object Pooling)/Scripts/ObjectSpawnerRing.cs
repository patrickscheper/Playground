using UnityEngine;
using System.Collections;

public class ObjectSpawnerRing : MonoBehaviour
{

    public int numberOfSpawners;
    public Material[] objectMaterials;

    public float radius, tiltAngle;

    public ObjectSpawner spawnerPrefab;

    void Awake()
    {
        for (int i = 0; i < numberOfSpawners; i++)
        {
            CreateSpawner(i);
        }
    }


    void CreateSpawner(int index)
    {
        Transform rotater = new GameObject("Rotater").transform;
        rotater.SetParent(transform, false);
        rotater.localRotation =
            Quaternion.Euler(0f, index * 360f / numberOfSpawners, 0f);

        ObjectSpawner spawner = Instantiate<ObjectSpawner>(spawnerPrefab);
        spawner.GetComponent<ObjectSpawner>().objectMaterial = objectMaterials[Random.Range(0, objectMaterials.Length)];
        spawner.transform.SetParent(rotater, false);
        spawner.transform.localPosition = new Vector3(0f, 0f, radius);
        spawner.transform.localRotation = Quaternion.Euler(-tiltAngle, 0f, 0f);
    }
}
