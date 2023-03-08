using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProp : MonoBehaviour
{
    public float xStart;
    public float speed;
    public float trainSpeed;
    public GameObject Train;
    public GameObject PropCar;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        CarMove();
        TrainMove();
    }
    public void CarMove()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if(transform.position.x < -xStart)
        {
        StartCoroutine(Wait());
        transform.position = new Vector2(xStart, transform.position.y);
        }
        //im moving something
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
    }
    
    public void TrainMove()
    {
        transform.Translate(Vector3.left * trainSpeed * Time.deltaTime);
        if(transform.position.x < -xStart)
        {
        StartCoroutine(Wait());
        transform.position = new Vector2(xStart, transform.position.y);
        }
        //im moving something too
    }

}
