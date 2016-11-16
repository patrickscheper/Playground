using UnityEngine;
using System.Collections;

public class NucleonOperator : MonoBehaviour {

    public float attractionForce;

    Rigidbody body;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

	void Start () {
	
	}
	

	void FixedUpdate ()
    {
        body.AddForce(transform.localPosition * -attractionForce);
	
	}
}
