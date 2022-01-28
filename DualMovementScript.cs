using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualMovementScript : MonoBehaviour
{

    public Transform playerWhite;
    public Transform playerBlack;

    public float fSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * fSpeed;

        if (Input.GetAxis("Vertical") == 1)
        {
            playerWhite.Translate(Vector3.up * fSpeed * Time.deltaTime);
            playerBlack.Translate(Vector3.up * -fSpeed * Time.deltaTime);
        }
        else if (Input.GetAxis("Vertical") == -1)
        {
            playerWhite.Translate(Vector3.up * -fSpeed * Time.deltaTime, Space.World);
            playerBlack.Translate(Vector3.up * fSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetAxis("Horizontal") == 1)
        {
            playerWhite.Translate(Vector3.right * fSpeed * Time.deltaTime, Space.World);
            playerBlack.Translate(Vector3.right * -fSpeed * Time.deltaTime, Space.World);
        }
        else if (Input.GetAxis("Horizontal") == -1)
        {
            playerWhite.Translate(Vector3.left * fSpeed * Time.deltaTime, Space.World);
            playerBlack.Translate(Vector3.left * -fSpeed * Time.deltaTime, Space.World);
        }
    }
}
