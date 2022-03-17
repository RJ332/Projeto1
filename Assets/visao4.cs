using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visao4 : MonoBehaviour
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
      GameObject thePlayer3 = GameObject.Find("Flying eye");
      FlyingMove playerScript3 = thePlayer3.GetComponent<FlyingMove>();

    if (collision.CompareTag("player") )
    { 
      //Flying
      
      animator.SetBool("attack", true); 
    } else if(playerScript3.vdead == 1) {
      animator.SetBool("attack", false);
      animator.SetBool("dead", true);
    }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
      GameObject thePlayer = GameObject.Find("Flying eye");
      FlyingMove playerScript = thePlayer.GetComponent<FlyingMove>();

    if (collision.CompareTag("player") )
    {
      //Flying
      
      animator.SetBool("attack", false); 
    }  
    }
}
