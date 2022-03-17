using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement2 : MonoBehaviour
{
    public Vector3 Speed = Vector3.up;
    public Vector3 Rotate = Vector3.up;
    // Start is called before the first frame update
    void Start()
    { 
      transform.Rotate(Rotate);  
    }

    // Update is called once per frame
    void Update()
    {
    transform.Translate(Speed * Time.deltaTime);   
    }

    void OnTriggerExit2D(Collider2D collision)
    {
    if (collision.CompareTag("enemy"))
    {
     Destroy(this.gameObject);
    }
    }
}
