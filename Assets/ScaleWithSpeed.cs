using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWithSpeed : MonoBehaviour {

	public float m_maxScale = 3;
	public float m_maxSpeed = 20;

	private Rigidbody m_body;
	private Transform m_tf;

	// Use this for initialization
	void Start () {
		m_body = GetComponent<Rigidbody>();
		m_tf = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void FixedUpdate() {
		float scale = Mathf.Min(m_maxScale, Mathf.Lerp(1, m_maxScale, m_body.velocity.magnitude / m_maxSpeed));
		
		m_tf.localScale = new Vector3(scale, scale, scale);
	}
}
