using UnityEngine;

public class SoundStep : MonoBehaviour
{
    public AudioClip footstepSound;
    public float stepInterval = 0.5f;

    private AudioSource audioSource;
    private CharacterController characterController;
    private float stepTimer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            Debug.LogError("CharacterController não encontrado no jogador. Adicione um CharacterController ao GameObject.");
        }

        stepTimer = 0f;
    }

    void Update()
    {
        if (characterController.isGrounded && characterController.velocity.magnitude > 0.1f)
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0f)
            {
                PlayFootstepSound();
                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }

    void PlayFootstepSound()
    {
        if (footstepSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(footstepSound);
        }
        else
        {
            Debug.LogWarning("AudioClip ou AudioSource não configurado corretamente.");
        }
    }
}