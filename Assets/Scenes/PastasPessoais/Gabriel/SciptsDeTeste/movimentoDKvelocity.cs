using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoDKvelocity : MonoBehaviour
{

    private float movHorizontal;
    private float movVertical;
    public float movSpeed;
    public float ySpeed;
    public string ySpeedText;

    public Rigidbody rb;
    private Vector3 move;


    void Update()
    {
        movHorizontal = -Input.GetAxisRaw("Horizontal");
        movVertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        move = new Vector3 (0,movVertical,movHorizontal) * movSpeed;
        rb.velocity = new Vector3(0, rb.velocity.y, move.z);

        ySpeed = rb.velocity.y;
        ySpeedText = ySpeed.ToString();

        Debug.Log(ySpeedText);



    }


}
