using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip collide;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip win;

    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    AudioSource audioSource;

    bool isControllable = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isControllable)
        {
            return;
        }

        switch (collision.gameObject.tag)
        {
            case "Obstacle":
                isControllable = false;
                // audioSource.PlayOneShot(collide);
                audioSource.PlayOneShot(collide);
                crashParticles.Play();
                break;
            case "LandPad":
                isControllable = false;
                audioSource.PlayOneShot(win);
                successParticles.Play();
                break;
            case "Ground":
                isControllable = false;
                audioSource.PlayOneShot(crash);
                crashParticles.Play();
                break;

        }
    }
}
