using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] float jumpVelocity;
    [SerializeField] float maxHeight;
    [SerializeField] GameObject sprite;
    
    Rigidbody2D rigid;
    bool isDead;
    public bool IsDead      //이렇게 일반 변수를 끼고 선언하면 내부에서만 변경 가능하고 외부에서는 읽기만 가능해진다.
    {                       //즉, 내부에서는 isDead를 통해 IsDead에 쓰기가 가능하지만 외부에서는 IsDead를 읽기만 가능하다.
        get
        {
            return isDead;
        }
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && transform.position.y < maxHeight)
        {
            if (!isDead && rigid.isKinematic == false)
            {
                Debug.Log("Jump!");
                rigid.velocity = new Vector2(0.0f, jumpVelocity);
            }
        }

        //물고기 회전
        float angle;
        //if (isDead)
        //{
        //    angle = 0f;
        //}
        //else
        //{
        angle = Mathf.Atan2(rigid.velocity.y, 10) * Mathf.Rad2Deg;
        //}
        sprite.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
    }

    public void SetKinematic(bool value)
    {
        rigid.isKinematic = value;
    }
}
