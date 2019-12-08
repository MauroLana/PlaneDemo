using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class controls player movement, weapons behaviour and collisions
public class PlayerController : MonoBehaviour
{    
    [Tooltip("Set player forward speed. Constant thrust is applied.")]
    public float playerSpeed;
    [Tooltip("Set player rotation speed on X and Y axis.")]
    public float xRotationSpeed, yRotationSpeed;
    [Tooltip("Time interval between shots. Lower = faster fire.")]
    public float fireRate;
    [Tooltip("Reference to the bullet prefab.")]
    public GameObject bullet;
    [Tooltip("Force added to each bullet")]
    public float bulletSpeed;
    [Tooltip("Reference to the muzzle fire particle effects. Used to activate them and to get their transform")]
    public ParticleSystem muzzle1, muzzle2;
    [Tooltip("Reference to the gun sound")]
    public AudioClip gunSound;
    //Used to move the player
    private Rigidbody rb;
    //used to limit the fire rate 
    private float nextFire;
    //used to access the player transform. This was added to make the following code slimmer, avoiding some typing
    private Transform playerTransform;
    //used to simulate bullet spread
    private float spread;
    //Used to play sounds
    private AudioSource audioSource;
    

    private void Start()
    {
        //Get the player's rigidbody component
        rb = GetComponent<Rigidbody>();
        //And the transform
        playerTransform = GetComponent<Transform>();
        //And the audio source
        audioSource = GetComponent<AudioSource>();
    }
    
    private void FixedUpdate()
    {
        //Movement 
        FlyForward();
        GetMovementInput();
        //Weapons
        Shoot();
    }

    //The forward thrust is always applied. I assumed that removing the thrust command would be appropriate for a mobile game.
    private void FlyForward()
    {
        rb.transform.Translate(0, 0, playerSpeed);
    }

    //Controls are bound to the keys UP, DOWN, LEFT , RIGHT and SPACEBAR.
    //UP and DOWN tilt the plane up or down
    //LEFT and RIGHT rotate the plane on the Z axis
    private void GetMovementInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.transform.Rotate(xRotationSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.transform.Rotate(-xRotationSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.transform.Rotate(0, 0, yRotationSpeed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.transform.Rotate(0, 0, -yRotationSpeed);
        }
    }

    //This handles the shooting and bullet behaviour. Bullets are also affected by gravity.
    private void Shoot()
    {
        //The following if statement ensures that the next bullet if fired at the right time: when "fireRate" time is elapsed from the last bullet fired
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            //set "nextFire" for the following iteration of the function
            nextFire = Time.time + fireRate;

            //Temporary GO used to instantiate the bullet. The spawn position is the same as the muzzle fire postion.
            GameObject spawnBullet1, spawnBullet2;
            spawnBullet1 = Instantiate(bullet, muzzle1.transform.position, playerTransform.rotation);
            spawnBullet2 = Instantiate(bullet, muzzle2.transform.position, playerTransform.rotation);
            
            //Play the particle effects for muzzle fire
            muzzle1.Play();
            muzzle2.Play();

            //Call the function that plays gun sounds
            PlaySound();

            //Get a reference to teh rigidbodies of the fired bullets: will be used to move them 
            Rigidbody rb1, rb2;
            rb1 = spawnBullet1.GetComponent<Rigidbody>();
            rb2 = spawnBullet2.GetComponent<Rigidbody>();

            //Random spread is applied to each bullet. This is just to achieve a pleasant visual effect.
            spread = Random.Range(-200, 200f);
            rb1.AddForce(transform.forward* bulletSpeed);
            rb1.AddForce(transform.right * spread);
            rb1.AddForce(transform.up * spread);
            spread = Random.Range(-200, 200f);
            rb2.AddForce(transform.forward * bulletSpeed);
            rb2.AddForce(transform.right * spread);
            rb2.AddForce(transform.up * spread);

            //Finally destroy each instance after 3 seconds to avoid slowing donws the system
            Destroy(spawnBullet1, 3F);
            Destroy(spawnBullet2, 3F);
        }
    }

    private void PlaySound()
    {
        //Play sound
        audioSource.PlayOneShot(gunSound);
    }
}
