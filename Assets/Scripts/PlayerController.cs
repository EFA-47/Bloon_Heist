using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator playerAnim;
    public float jumpForce = 10.0f;
    public float gravityModdifier;
    private bool isOnGround = true;
    public bool gameOver;
    public ParticleSystem exposionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSFX;
    public AudioClip crashSFX;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModdifier;
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        gameObject.AddComponent<AudioSource>();
        playerAudio = GetComponent<AudioSource>();
        dirtParticle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver){
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAudio.PlayOneShot(jumpSFX, 1.0f);
            isOnGround = false;
            dirtParticle.Stop();
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision){
        
        if(collision.gameObject.CompareTag("Ground")){
            isOnGround = true;
            if(!gameOver)
            dirtParticle.Play();
        }

        if(collision.gameObject.CompareTag("Obstacle")){
            gameOver = true;
            playerAudio.PlayOneShot(crashSFX, 1.0f);
            playerAnim.SetInteger("DeathType_int", 1);
            playerAnim.SetBool("Death_b", true);
            exposionParticle.Play();
            dirtParticle.Stop();
            Debug.Log("Game Over!");
            
        }
    }
}
