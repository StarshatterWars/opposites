using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealScript : MonoBehaviour
{
    private bool isReady;
    private float clock;

    // Start is called before the first frame update
    void Start()
    {
        isReady = true;
        clock = 25f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady == false)
        {
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            
            clock -= Time.deltaTime;
        }

        if (clock <= 0f)
        {
            GetComponentInChildren<SpriteRenderer>().enabled = true;
            isReady = true;
            clock = 25f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Check");
        if (other.GetComponentInChildren<HealthBarScript>() != null && isReady == true)
        {
            Debug.Log("Check2");

            other.GetComponentInChildren<HealthBarScript>().AdjustBar(1f);
            isReady = false;
        }
    }

}
