using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualMovementScript : MonoBehaviour
{
    // 2D rigidbody held by player 1 (White) and player 2 (Black)
    public Rigidbody2D playerWRB;
    public Rigidbody2D playerBRB;

    // movement speed attribute
    public float fSpeed = 10f;

    // Vector2 to hold horizontal and vertical input methods
    private Vector2 moveVec;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // horizontal and vetical axis scale from -1 (left,backwards) to 1 (Right,Forward)
        moveVec.x = Input.GetAxisRaw("Horizontal");
        moveVec.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        // transform players' rigidbody in the direction held by moveVec, times by speed and timestep
        // white and black sprites' movement are opposites
        playerWRB.MovePosition(playerWRB.position + moveVec * fSpeed * Time.fixedDeltaTime);
        playerBRB.MovePosition(playerBRB.position - moveVec * fSpeed * Time.fixedDeltaTime);

    }
}
