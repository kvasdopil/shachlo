using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour {
	public GameObject m_player;
	public float m_rotationSpeed = 100;
	public float m_maxAcceleration = 100;

	private float m_rotation;
	private float m_movement;

	private Rigidbody m_body;


	// Use this for initialization
	private void Start () {
		m_body = m_player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	private void Update () {
		m_rotation = Input.GetAxis("Horizontal");
		m_movement = Input.GetAxis("Vertical");
	}

	private void FixedUpdate() {
		Vector3 angles = m_body.rotation.eulerAngles;
		m_body.rotation = Quaternion.Euler(angles.x, angles.y, angles.z + m_rotation * m_rotationSpeed * Time.deltaTime);

		if (Mathf.Abs(m_movement) > 0.1) {
			m_body.AddForce(Vector3.up * m_maxAcceleration * m_movement * Time.deltaTime);
		}
	}
}
