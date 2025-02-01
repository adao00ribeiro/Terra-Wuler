using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Stop()
    {
        audioSource.Stop();
    }
    public void PlayOneShot(Vector3 position, AudioClip clip)
    {
        transform.position = position;
        audioSource.PlayOneShot(clip);
    }
    public void Play(Vector3 position, AudioClip clip)
    {
        transform.position = position;
        audioSource.clip = clip;
        audioSource.Play();
    }
}