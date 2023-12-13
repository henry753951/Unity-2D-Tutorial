using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bird : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    float jumpForce = 5f;

    [SerializeField]
    GameSystem gameSystem;

    [SerializeField]
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // 在遊戲開始時，獲取附加在同一個遊戲物體上的Rigidbody2D組件
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Jump");
            // 播放音效
            audioSource.Play();

            // method 1
            rb.velocity = Vector2.zero; //因為力量按一次會疊加上去，所以每次跳躍都先歸零速度
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            // method 2
            // rb.velocity = new Vector2(0, jumpForce);
            // method 3
            // rb.velocity = Vector2.up * jumpForce; // Vector2.up = new Vector2(0, 1)
        }

        // 檢測通過水管
        gameSystem.CheckPassPipe(transform.position.x);
    }

    // 碰撞到東西時，遊戲結束
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 使遊戲結束
        gameSystem.GameOver();
    }
}
