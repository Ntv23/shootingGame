using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rbPlayer;
    public float speed = 8f;
    public float jumpForce = 10f;
    private float Move;
    public bool isJumping;

    private Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Move = Input.GetAxis("Horizontal");
        rbPlayer.velocity = new Vector2(speed * Move, rbPlayer.velocity.y);

        // Cập nhật giá trị isWalking trong Animator
        anim.SetBool("walk", Mathf.Abs(Move) > 0.1f);

        if (Input.GetButtonDown("Jump") && !isJumping) //Điều kiện space và đang không nhảy
        {
            // Thêm lực nhảy theo hướng trục Y
            rbPlayer.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true; //Chuyển trạng thái là đang nhảy
            Debug.Log("jump");
        }

        // Xoay nhân vật dựa trên hướng di chuyển
        if (Move > 0) // Di chuyển sang phải
        {
            transform.localScale = new Vector3(2, 2, 1); // Hướng mặt về phía phải
        }
        else if (Move < 0) // Di chuyển sang trái
        {
            transform.localScale = new Vector3(-2, 2, 1); // Hướng mặt về phía trái
        }

        
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Floor"))//object chạm tag floor
        {
            isJumping = false;//Chuyển trạng thái là đang không nhảy (được phép nhảy)
            Debug.Log("no jump");
        }
    }
}
