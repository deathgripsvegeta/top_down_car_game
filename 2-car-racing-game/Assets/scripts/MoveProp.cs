using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProp : MonoBehaviour
{
    public float xStart;
    public float speed;
    public GameObject[] Props;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.CompareTag("prop"))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if(transform.position.x < -xStart)
        {
            transform.position = new Vector2(xStart, 0);
        }
    }

}
