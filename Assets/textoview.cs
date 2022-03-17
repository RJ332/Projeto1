using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textoview : MonoBehaviour
{
    public Text textToViewd;
    public Text textToViewd2;
    private int coins;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision) {
        

        if (collision.CompareTag("player")) {
        GameObject thePlayer1 = GameObject.Find("player");
        CharacterMove playerScript1 = thePlayer1.GetComponent<CharacterMove>();
        coins =  playerScript1.c ;

        textToViewd.text = "Espero que tenha gostado";
        textToViewd2.text = "Score: " + coins;
        }
    }
}
