using UnityEngine;

public class TorchController : MonoBehaviour {
    public int torchId;

	private bool _isLighting;
	private ParticleSystem _particles;
	private Light _light;
	private AudioSource _audioSource;

	private void Start () {
		_particles = GetComponent<ParticleSystem> ();
		_light = GetComponentInChildren<Light> (true);
		_audioSource = GetComponent<AudioSource>();
	}
	
	public void Lighting(){
		//Start particle system.
		_particles.Play();
		//Turn on the light
		_light.enabled = true;
		//Set attribute isLighting to true.
		_isLighting = true;
		//Start sound
		_audioSource.Play();
	}
    
	public bool GetIsLighting(){
		return _isLighting;
	}


}
