using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{
	public ParticleSystem particle;

	public void Start()
	{
		StartCoroutine(PlayParticle());
	}

	public IEnumerator PlayParticle()
	{
		particle.Play();
		yield return new WaitForSeconds(particle.main.duration);
		Destroy(gameObject);
	}
}
