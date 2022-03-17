using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterMove : MonoBehaviour
{
    private Text textToView;
    private Rigidbody2D rb;
    public GameObject mf;
    public GameObject gm;
    public Animator animator;
    private SpriteRenderer mySpriteRenderer;
    private Vector3 jump;
    private float speed = 3f;
    private float jumpHeight = 4f;
    private static bool isJumping = false; 
    private float moveHorizontal;
    private float XLimit = 3.8f;
    private float YLimit = 5f;
    private float x1;
    private float y1;
    private float x2;
    private float y2;
    private float z;
    public int vdead = 0;
    public int c;
    private GameObject[] players;
    private int playersn;
    private int final = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

       DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        x1 = mf.transform.position.x;
        y1 = transform.position.y;
        x2 = transform.position.x;
        y2 = mf.transform.position.y;
        z = mf.transform.position.z;

        if(vdead == 1) {
          animator.SetBool("death", true);
        }

        if (Input.GetKeyDown(KeyCode.D) && (vdead == 0))
        {
            x2 = x2 + 0.283f;
            mf.transform.position = new Vector3(x2 , y2, z);
            gm.transform.position = new Vector3(x2 , y2, z);
           this.mySpriteRenderer.flipX = false; 
        }

        if (Input.GetKeyDown(KeyCode.A) && (vdead == 0))
        {
            x2 = x2 - 0.283f;
            mf.transform.position = new Vector3(x2 , y2, z);
            gm.transform.position = new Vector3(x2 , y2, z);
           this.mySpriteRenderer.flipX = true;    
        }

        if (Input.GetButtonDown("Jump") && (isJumping == false) && (vdead == 0)) 
        {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
        animator.SetBool("jump", true);
        }

        if (Input.GetButtonDown("Fire1") && (vdead == 0)) 
        {
            animator.SetBool("crouch", true);
            GetComponent<CapsuleCollider2D>().size = new Vector2(1f, 1f);

            y1 = y1 + 0.245f;
            mf.transform.position = new Vector3(x1 , y1, z);
            gm.transform.position = new Vector3(x1 , y1, z);
            speed = 0f; 
        } else if (Input.GetButtonUp("Fire1")) 
        {
            animator.SetBool("crouch", false);
            GetComponent<CapsuleCollider2D>().size = new Vector2(1f, 1.075f);
            
            y1 = y1 + 0.314f;
            mf.transform.position = new Vector3(x1 , y1, z);
            gm.transform.position = new Vector3(x1 , y1, z);
            speed = 3f; 
        }
    }

    void FixedUpdate()
    {
      DoBasicMovement();
      CorrectMovement();
    }

    void DoBasicMovement ()
    {
      //  float moveHorizontal = Input.GetAxis ("Horizontal");
      //  Vector3 movement = new Vector3 (moveHorizontal, 0, 0);
      //  animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));
      //  rb.AddForce (movement * speed); 

        if(final == 0){
        moveHorizontal = Input.GetAxis ("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f);
        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));
        rb.transform.position += movement * Time.deltaTime * speed;
        } else {
        moveHorizontal = 0;
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f);
        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));
        rb.transform.position += movement * Time.deltaTime * speed;
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

    void OnCollisionEnter2D(Collision2D collision)
    {
       isJumping = false;
       animator.SetBool("jump", false);
    }

    void OnTriggerStay2D(Collider2D collision)
    {  
    if (collision.CompareTag("enemy"))
    { 
     // vdead = 1;
     // speed = 0f;
     // animator.SetBool("death", true); 
     // StartCoroutine(PlayerDead());
     SceneManager.LoadScene("Nivel1"); 
     //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     c = 0;
    }
    if (collision.CompareTag("door"))
    { 
    }
    if (collision.CompareTag("final"))
    { 
      final = 1;
    }
    if (collision.CompareTag("trap"))
    { 
     SceneManager.LoadScene("Nivel1");
     c = 0;
    }
    if (collision.CompareTag("coin"))
    {
     c = c + 1;
     Debug.Log("Score: " + c);
    //textToView.text = "Score: " + c;
     Destroy(collision.gameObject);
    }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isJumping = true;
        animator.SetBool("jump", true);  
    }

   // IEnumerator PlayerDead()
   // {
     // yield return new WaitForSeconds(3f);  

      //yield break;  
   // }

    private void OnLevelWasLoaded(int level) 
    {
      FindStartPos();
      players = GameObject.FindGameObjectsWithTag("player");
      playersn = players.Length;
      if(players.Length > 1 )
      {
        Destroy(players[1]);
      }
    }

    void FindStartPos()
    {
      transform.position = GameObject.FindWithTag("startp").transform.position;
    }
}
