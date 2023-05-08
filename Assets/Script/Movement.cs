using UnityEngine;


public class Movement : MonoBehaviour
{
    [SerializeField] float forcaPrincipal = 100f;
    [SerializeField] float forcaDeRotacao = 100f;
    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessoPropulsao();
        ProcessoRotacao();
    }

    void ProcessoPropulsao()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            rb.AddRelativeForce(Vector3.up * forcaPrincipal *Time.deltaTime);
        }
        else 
        {
            audioSource.Stop();
        }

    }

    void ProcessoRotacao() 
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Rotacionar(forcaDeRotacao);
        }

        else if (Input.GetKey(KeyCode.RightArrow)) 
        {
            Rotacionar(-forcaDeRotacao);
        }

    }

    void Rotacionar(float rotacaoPorFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotacaoPorFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
