using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
   
{
    public float jump;

    public bool Grounded;

    public LayerMask ground;
    public LayerMask dead;

    private Collider2D playerCollider;
    private Animator animator;

    private Rigidbody2D hero;
    public float speed;

    public AudioSource jumpsound;
    public AudioSource deathsound;

    public float milestone;
    private float milestoneCount;
    public float speedMultiplier;

    public GameManger gameManger;
    // Start is called before the first frame update
    void Start()
    {
        hero = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        milestoneCount = milestone;
    }

    // Update is called once per frame
    void Update()

    {
        bool death = Physics2D.IsTouchingLayers(playerCollider, dead);
        if (death)
        {
            gameOver();
        }

        if (transform.position.x > milestoneCount)
        {
            speed = speed * speedMultiplier;
            milestoneCount += milestone;
            milestone *= speedMultiplier;
            Debug.Log("M" + milestone + ", MC" + milestoneCount + " , PS" + speed);
        }
        hero.velocity = new Vector2(speed, hero.velocity.y);
        Grounded = Physics2D.IsTouchingLayers(playerCollider, ground);
        if(Input.GetMouseButtonDown(0)|| Input.GetKeyDown(KeyCode.Space))

        {
            if (Grounded) {
                
                hero.velocity = new Vector2(hero.velocity.x, jump);
                jumpsound.Play();
            }
            
        }
        animator.SetBool("Grounded", Grounded);
    }


    void gameOver()
    {
        
        gameManger.GameOver();
       
    }
   


}
