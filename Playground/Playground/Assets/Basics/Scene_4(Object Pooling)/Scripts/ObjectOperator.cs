using UnityEngine;
using System.Collections;

public class ObjectOperator : PooledObject
{

    public Rigidbody Body { get; private set; }

    void Awake()
    {
        Body = GetComponent<Rigidbody>();
    }

    void Start()
    {

    }


    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "KillZone")
            ReturnToPool();
    }
}
