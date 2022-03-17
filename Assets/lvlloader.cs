using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvlloader : MonoBehaviour
{
    public int ileveltoload;
    public string sleveltoload;

    public bool useintegertoload = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisiongameObject = collision.gameObject;

        if(collision.CompareTag("player"))
        {
            Loadscene();
        }
    }

    void Loadscene()
    {
        if(useintegertoload)
        {
            SceneManager.LoadScene(ileveltoload);

        }
        else
        {
            SceneManager.LoadScene(sleveltoload);
        }

    }
}
