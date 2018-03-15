using UnityEngine;
using System.Collections;

public class RotationSettings : MonoBehaviour {

	public int rotationIndex = 5;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.one * rotationIndex * Time.deltaTime);
	}
}
