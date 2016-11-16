using UnityEngine;
using System.Collections;

public class FractalOperator : MonoBehaviour {

    public Mesh[] meshes;
    public Material material;
    public int MaxDepth;
    public float childScale;

    public float spawnProbability;

    public float maxRotationSpeed;
    public float maxTwist;
    private float rotationSpeed;


    private static Vector3[] childDirections =
    {
        Vector3.up,
        Vector3.right,
        Vector3.left,
        Vector3.forward,
        Vector3.back

    };

    private static Quaternion[] childOrientations =
    {
        Quaternion.identity,
        Quaternion.Euler(0f, 0f, -90f),
        Quaternion.Euler(0f, 0f, 90),
        Quaternion.Euler(90f, 0f, 0f),
        Quaternion.Euler(-90f, 0f, 0f)
    };

    private Material[,] materials;

    private void InitializeMaterials()
    {
        materials = new Material[MaxDepth + 1, 2];
        for (int i = 0; i <= MaxDepth; i++)
        {
            float t = i / (MaxDepth - 1f);
            t *= t;
            materials[i, 0] = new Material(material);
            materials[i, 0].color = Color.Lerp(Color.black, Color.blue, t);
            materials[i, 1] = new Material(material);
            materials[i, 1].color = Color.Lerp(Color.white, Color.cyan, t);
        }
        materials[MaxDepth, 0].color = Color.black;
        materials[MaxDepth, 1].color = Color.white;
    }

    private int depth;

	void Start ()
    {
        rotationSpeed = Random.Range(-maxRotationSpeed, maxRotationSpeed);
        transform.Rotate(Random.Range(-maxTwist, maxTwist), 0f, 0f);
        if (materials == null)
        {
            InitializeMaterials();
        }

        gameObject.AddComponent<MeshFilter>().mesh = meshes[Random.Range(0, meshes.Length)]; ;
        gameObject.AddComponent<MeshRenderer>().material = materials[depth, Random.Range(0, 2)];

        if (depth < MaxDepth)
            StartCoroutine(CreateChildren());
	
	}
	

	void Update ()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
	}

    private IEnumerator CreateChildren()
    {
        for (int i = 0; i < childDirections.Length; i++)
            if(Random.value < spawnProbability)
            {
                yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
                new GameObject("Fractal Child").AddComponent<FractalOperator>().Initialize(this, i);
            }

    }

    private void Initialize(FractalOperator parent, int childIndex)
    {
        maxRotationSpeed = parent.maxRotationSpeed;
        spawnProbability = parent.spawnProbability;
        maxTwist = parent.maxTwist;

        meshes = parent.meshes;
        materials = parent.materials;
        MaxDepth = parent.MaxDepth;
        depth = parent.depth + 1;
        childScale = parent.childScale;

        transform.parent = parent.transform;
        transform.localScale = Vector3.one * childScale;
        transform.localPosition = childDirections[childIndex] * (0.5f + 0.5f * childScale);
        transform.localRotation = childOrientations[childIndex];

    }
}
