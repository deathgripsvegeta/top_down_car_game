using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCollectable : MonoBehaviour
{
    [SerializeField] private int _value = 1;
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
            LevelManager.Instance.UpdateGasAmount(_value);
            LevelManager.Instance.SetGasFillAmount(_value);
          
            Destroy(this.gameObject);
        }
    }
}
