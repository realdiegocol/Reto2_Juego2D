using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float fuerzaSalto = 7.0f;
    public int maxJumps = 2;  // Maximum number of jumps (including the initial jump)
    public Vector3 posicionInicio { get; set; }    
    private int jumpsRemaining;
    private bool enElsuelo = false;
    private Rigidbody2D rb;
    private Animator animaciones;
    private AudioSource audioSalto;
    public LayerMask capaGround;
    private CapsuleCollider2D capsuleCollider;

    public LevelInteractionManager interactionManager; // Reference to the LevelInteractionManager script

    private void Start()
    {
        posicionInicio = transform.position;
	    rb = GetComponent<Rigidbody2D>();
        animaciones = GetComponent<Animator>();
	    audioSalto = GetComponent<AudioSource>();
        jumpsRemaining = maxJumps;
        capsuleCollider = GetComponent<CapsuleCollider2D>();

        // Make sure to assign the LevelInteractionManager reference in the Inspector
        if (interactionManager == null)
        {
            interactionManager = GameObject.FindObjectOfType<LevelInteractionManager>();
        }
    }

    private void Update()
    {
        if (interactionManager.CurrentState != GameState.Playing)
        return;
        
        // Character Movement
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(movimientoHorizontal * velocidadMovimiento, rb.velocity.y);
        rb.velocity = movement;

        if (movimientoHorizontal > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movimientoHorizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Update animation parameter
        animaciones.SetInteger("Salto", (int) rb.velocity.y);
        animaciones.SetBool("Piso", enElsuelo);
        animaciones.SetFloat("MovimientoHorizontal", Mathf.Abs(movimientoHorizontal));

        // Check if the character is grounded
        enElsuelo = EstaEnSuelo();

        // Jumping       
        if (Input.GetKeyDown(KeyCode.Space) && (enElsuelo || jumpsRemaining > 0))
        {
            if (!enElsuelo) jumpsRemaining--;
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
            audioSalto.Play();
        }

        // Reset double jump when grounded
        if (enElsuelo)
        {
            jumpsRemaining = maxJumps;
        }

        // Check for character death
        if (transform.position.y < -10) // You can adjust the death height
        {
            interactionManager.ShowGameOverPanel();
        }
    }

    private bool EstaEnSuelo()
    {
        Vector2 capsuleCenter = capsuleCollider.bounds.center;
        float capsuleWidth = capsuleCollider.size.x;
        float capsuleHeight = capsuleCollider.size.y;

        RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCenter, new Vector2(capsuleWidth, capsuleHeight), 0f, Vector2.down, 0.2f, capaGround);
        return raycastHit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        enElsuelo = collision.gameObject.CompareTag("Suelo"); 
        
        if (collision.gameObject.CompareTag("Morir"))
        {
            Reinicio();
        }
    }

    void Reinicio()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        rb.bodyType = RigidbodyType2D.Static;
        transform.position = posicionInicio;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
