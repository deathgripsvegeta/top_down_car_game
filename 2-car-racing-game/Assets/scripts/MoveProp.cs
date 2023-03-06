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
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if(transform.position.x < -xStart)
        {
            StartCoroutine(Wait());
            transform.position = new Vector2(xStart, transform.position.y);
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
    }

}
