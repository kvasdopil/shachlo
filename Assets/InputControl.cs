using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour {
	public float m_rotationSpeed = 100;
	public float m_maxAcceleration = 100;

	private float m_rotation;
	private float m_movement;

	private Transform m_transform;
	private Rigidbody m_body;

	// Use this for initialization
	private void Start () {
		m_body = GetComponent<Rigidbody>();
		m_transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	private void Update () {
		m_rotation = Input.GetAxis("Horizontal");
		m_movement = Input.GetAxis("Vertical");
	}

	private void FixedUpdate() {
		Vector3 angles = m_transform.rotation.eulerAngles;
		m_transform.rotation = Quaternion.Euler(angles.x, angles.y, angles.z + m_rotation * m_rotationSpeed * Time.deltaTime * -1);

		if (Mathf.Abs(m_movement) > 0.1) {
			m_body.AddForce(m_transform.rotation * Vector3.up * m_maxAcceleration * m_movement * Time.deltaTime);
		}
	}
}
