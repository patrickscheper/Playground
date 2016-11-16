using UnityEngine;
using System.Collections;

public class ObjectOperator : MonoBehaviour {

    public Rigidbody Body { get; private set; }

    void Awake()
    {
        Body = GetComponent<Rigidbody>();
    }

	void Start () {
	
	}
	

	void Update () {
	
	}
}
