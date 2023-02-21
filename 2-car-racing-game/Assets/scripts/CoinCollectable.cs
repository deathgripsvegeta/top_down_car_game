using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectable : MonoBehaviour
{
    [SerializeField] public int _value = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("I've was hit by the player!");

           if(this.gameObject.CompareTag("coin"))
            {
                LevelManager.Instance.UpdateLevelCoinCount(_value);
            }
            Destroy(this.gameObject);
        }
    }
}
