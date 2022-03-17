using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawb : MonoBehaviour
{
    public GameObject Bullet1;
    public GameObject Bullet2;
    private SpriteRenderer mySpriteRenderer;
    private float FireRate = 3f;  // The number of bullets fired per second
    private float lastfired = 0f;

    // Start is called before the first frame update
    void Start()
    {
      mySpriteRenderer = GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
      GameObject thePlayer = GameObject.Find("player");
      CharacterMove playerScript = thePlayer.GetComponent<CharacterMove>();

      if (Input.GetKeyDown(KeyCode.D) && (playerScript.vdead == 0))
        {
          this.mySpriteRenderer.flipX = false; 
        }

        if (Input.GetKeyDown(KeyCode.A) && (playerScript.vdead == 0))
        {
          this.mySpriteRenderer.flipX = true;    
        }
        
        if (Input.GetButtonDown("Fire2") && (playerScript.vdead == 0)) 
        {
            if (Time.time - lastfired > 1 / FireRate)
            {
              lastfired = Time.time;  
              if (this.mySpriteRenderer.flipX == false) {
               Instantiate(Bullet1, transform.position, Quaternion.identity); 
              }
              if (this.mySpriteRenderer.flipX == true) {
               Instantiate(Bullet2, transform.position, Quaternion.identity); 
              }     
            }
        } else if (Input.GetButtonUp("Fire2")) {
            
        } 
    }
}
