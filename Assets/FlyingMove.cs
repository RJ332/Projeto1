using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMove : MonoBehaviour
{
    private Rigidbody2D Flyingeye;
    public Collider2D coll;
    public Animator animator;
    private SpriteRenderer mySpriteRenderer;
    public Collider2D collvisao;
    private float fEnemyX;
    public float speed = 0f;
    public float fMinX = 0.8f;
    public float fMaxX = 3.2f;
    private int Direction = -1;
    private int vida = 3;
    private float XLimit = 3.7f;
    private float YLimit = 5f;
    public int vdead = 0;

    // Start is called before the first frame update
    void Start()
    {
      speed = 0.2f;
      mySpriteRenderer = GetComponent<SpriteRenderer>(); 
      Flyingeye = GetComponent<Rigidbody2D> (); 
    }

    // Use this for initialization
    void Update () 
    {
       
    }

    void FixedUpdate()
    {
      DoBasicMovement();
      CorrectMovement();
    }

    void DoBasicMovement ()
    {
    fEnemyX = this.transform.position.x;

      switch( Direction )
        {
    case -1:
        // Moving Left
        if( fEnemyX > fMinX )
        {
            fEnemyX = -2f;
            this.mySpriteRenderer.flipX = true;
            collvisao.offset = new Vector2 (-0.63f , 0f);
            this.transform.Translate(fEnemyX * Time.deltaTime * speed, 0,0);
            animator.SetFloat("speed", Mathf.Abs(speed));
        }
        else
        {
            // Hit left boundary, change direction
            Direction = 1;
        }
        break;
     
    case 1:
        // Moving Right
        if( fEnemyX < fMaxX )
        {
          
            fEnemyX = 2f;
            this.mySpriteRenderer.flipX = false;
            collvisao.offset = new Vector2 (0.63f , 0f);
            this.transform.Translate(fEnemyX * Time.deltaTime * speed, 0,0);
            animator.SetFloat("speed", Mathf.Abs(speed));  
        }
        else
        {
            // Hit right boundary, change direction
            Direction = -1;
        }
        break;
    }         
    }

    void CorrectMovement ()
    {
    if (transform.position.x < -XLimit)
    {
    transform.Translate(-XLimit - transform.position.x, 0, 0);
    }
    if (transform.position.x > XLimit)
    {
    transform.Translate(XLimit - transform.position.x, 0, 0);
    }
    if (transform.position.y < -YLimit)
    {
    transform.Translate(0, -YLimit - transform.position.y, 0);
    }
    if (transform.position.y > YLimit)
    {
    transform.Translate(0, YLimit - transform.position.y, 0);
    }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.CompareTag("bullet"))
    {
      // collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 3f), ForceMode2D.Impulse);      
      // collision.GetComponent<Animator>().SetBool("hit", true);
        
        animator.SetBool("hit", true);    
    }  
    }

    void OnTriggerStay2D(Collider2D collision)
    {
    if (collision.CompareTag("limit"))
    {
      speed = 0f;    
    }   
    }

    void OnTriggerExit2D(Collider2D collision)
    {
    if (collision.CompareTag("bullet"))
    {
      // collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 3f), ForceMode2D.Impulse);      
      // collision.GetComponent<Animator>().SetBool("hit", true);
      
      if (vida <= 0) {
        speed = 0f;
        vdead = 1;
        StartCoroutine(KillEnemy());
      } else if(vida > 0) {
        speed = 0f;
        StartCoroutine(HitEnemy());
        vida = vida - 1; 
      }  
    } 
    }

    IEnumerator HitEnemy()
    {
      yield return new WaitForSeconds(0.5f);    
      animator.SetBool("hit", false);
      speed = 0.2f;
    }

    IEnumerator KillEnemy()
    {
      yield return new WaitForSeconds(0.5f); 
      speed = 0f; 
      vdead = 1;
      animator.SetBool("dead", true);
      Flyingeye.GetComponent<Rigidbody2D>().gravityScale = 1f;
      yield return new WaitForSeconds(1f); 
      collvisao.enabled = false;
      coll.enabled = false;
      Flyingeye.GetComponent<Rigidbody2D>().isKinematic = true;
      //coll.isTrigger = true;
      yield return new WaitForSeconds(5f);
      Destroy(this.gameObject);
    }
}
