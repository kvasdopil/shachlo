using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhaustControl : MonoBehaviour {

	public ParticleSystem m_back;
	public ParticleSystem[] m_fwd;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float m_rotation = Input.GetAxis("Horizontal");
		float m_movement = Input.GetAxis("Vertical");

		if (m_movement > 0.01) {
			if (!m_back.isPlaying) {
				m_back.Play();
			}
		} else {
			if (m_back.isPlaying) {
				m_back.Stop();
			}
		}

		for (int i = 0; i < m_fwd.Length; i++) {
			bool playing = m_fwd[i].isPlaying;
			bool shouldPlay = (m_movement < -0.01);

			if (playing && !shouldPlay) {
				m_fwd[i].Stop();
			}
			if (!playing && shouldPlay) {
				m_fwd[i].Play();
			}
		}
	}
}
