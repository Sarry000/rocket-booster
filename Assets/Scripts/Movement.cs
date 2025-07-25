using UnityEngine;
using UnityEngine.InputSystem;


public class Movement : MonoBehaviour
{
    [SerializeField] InputAction Thrust ;
    [SerializeField] InputAction rotation;
    [SerializeField] float Thruststring=100f ;
    [SerializeField] float rotationstrength =100f;
    [SerializeField] AudioClip mainthrust;
    [SerializeField] ParticleSystem mainengineParticles ;
    [SerializeField] ParticleSystem LeftEngineParticle ;
    [SerializeField] ParticleSystem RightEngineParticle ;

    
    Rigidbody rb;
    AudioSource audioo;
    
    private void Start() {
        
        rb = GetComponent<Rigidbody>();
        audioo = GetComponent<AudioSource>();

    }
    private void OnEnable() {
        
        Thrust.Enable();
        rotation.Enable();
    }
    private void FixedUpdate()
    {
        ProcessThrust();
        Processrotation();
    }

    private void ProcessThrust()
    {
        if (Thrust.IsPressed())
        {
            StartThrusting();
        }
        else
        {
            Stop();
        }
    }

    private void Stop()
    {
        audioo.Stop();
        mainengineParticles.Stop();
    }

    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * Thruststring * Time.fixedDeltaTime);
        if (!audioo.isPlaying)
        {
            audioo.PlayOneShot(mainthrust);
        }
        if (!mainengineParticles.isPlaying)
        {
            mainengineParticles.Play();
        }
    }

    private void Processrotation()
    {
        ProcessedRotation();

    }

    private void ProcessedRotation()
    {
        rb.freezeRotation = true;
        float rotationInput = rotation.ReadValue<float>();
        if (rotationInput < 0)
        {
            RotInputleft();
        }
        else if (rotationInput > 0)
        {
            RotInputright();
        }
        else
        {
            RightEngineParticle.Stop();
            LeftEngineParticle.Stop();
        }
    }

    private void RotInputleft()
    {
        transform.Rotate(Vector3.forward * rotationstrength * Time.fixedDeltaTime);
        rb.freezeRotation = false;

        if (!LeftEngineParticle.isPlaying)
        {
            LeftEngineParticle.Play();
        }
    }

    private void RotInputright()
    {
        transform.Rotate(Vector3.forward * -rotationstrength * Time.fixedDeltaTime);
        if (!RightEngineParticle.isPlaying)
        {
            RightEngineParticle.Play();
        }
    }
}
