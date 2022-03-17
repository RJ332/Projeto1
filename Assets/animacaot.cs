using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animacaot : MonoBehaviour
{

    private SpriteRenderer mySpriteRenderer;

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
            this.mySpriteRenderer.enabled = true; 
        } else if (Input.GetButtonUp("Fire2") && (playerScript.vdead == 0))
        {
            this.mySpriteRenderer.enabled = false;
        }
    }
}
