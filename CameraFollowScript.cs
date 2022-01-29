using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public GameObject playerObj;
    public Camera thisCam;
    public Vector3 fOffset;

    // Start is called before the first frame update
    void Start()
    {
        thisCam.transform.position = playerObj.transform.position + fOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObj.transform.position.x > thisCam.rect.width / 0.75)
        {
            Debug.Log("!!");
            transform.position += (playerObj.transform.position - transform.position) + fOffset;
        }
    }
}
