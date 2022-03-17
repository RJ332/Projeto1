using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visao2 : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    { 
      GameObject thePlayer3 = GameObject.Find("Cogumelo");
      CogumeloMove playerScript3 = thePlayer3.GetComponent<CogumeloMove>();

    if (collision.CompareTag("player") && (playerScript3.vdead == 0))
    { 
      //Cogumelo
      GameObject thePlayer1 = GameObject.Find("Cogumelo");
      CogumeloMove playerScript1 = thePlayer1.GetComponent<CogumeloMove>();
      playerScript1.speed = 0f;
      animator.SetBool("attack", true); 
    } else if(playerScript3.vdead == 1) {
      animator.SetBool("attack", false);
      animator.SetBool("dead", true);
    }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
      GameObject thePlayer = GameObject.Find("Cogumelo");
      CogumeloMove playerScript = thePlayer.GetComponent<CogumeloMove>();

    if (collision.CompareTag("player") && (playerScript.vdead == 0))
    {
      //Goblin
      GameObject thePlayer2 = GameObject.Find("Cogumelo");
      CogumeloMove playerScript2 = thePlayer2.GetComponent<CogumeloMove>();
      playerScript2.speed = 0.2f;
      animator.SetBool("attack", false);  
    }   
    }
}
