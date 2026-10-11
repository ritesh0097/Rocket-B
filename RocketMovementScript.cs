using UnityEngine;
using UnityEngine.InputSystem;

public class RocketMovementScript : MonoBehaviour
{

    [SerializeField] float thrustForce;
    [SerializeField] float rotationForce;

    [SerializeField] ParticleSystem mainEngineParticles;

    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;

    // Audios
    [SerializeField] AudioClip mainEngine;

    AudioSource audioSource;

    Rigidbody rocketRigi;

    public bool isRocketFly = true;

    void Start()
    {
        rocketRigi = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    void FixedUpdate()
    {
        ProcessRotation();
        ProcessThrust();
    }

    void ProcessRotation()
    {
        float rotationInput = rotation.ReadValue<float>();

        if (rotationInput < 0)
        {
            transform.Rotate(Vector3.forward * rotationForce * Time.fixedDeltaTime);
        }
        else if (rotationInput > 0)
        {
            transform.Rotate(Vector3.forward * -rotationForce * Time.fixedDeltaTime);
        }
        else
        {
            return;
        }
    }

    void ProcessThrust()
    {
        if (!isRocketFly)
        {
            return;
        }

        if (thrust.IsPressed())
        {
            rocketRigi.freezeRotation = true;
            rocketRigi.AddRelativeForce(transform.up * thrustForce * Time.fixedDeltaTime);
            rocketRigi.freezeRotation = false;

            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
                mainEngineParticles.Play();
            }
        }
        else
        {
            audioSource.Stop();
            mainEngineParticles.Stop();
        }
    }
}
