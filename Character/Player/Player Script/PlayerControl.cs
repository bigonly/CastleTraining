using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControl : MonoBehaviour // - Вместо «PlayerMove» должно быть имя файла скрипта
{
    //------- Функция/метод, выполняемая при запуске игры ---------

    public Rigidbody2D rb;
    public Animator anim;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    //------- Функция/метод, выполняемая каждый кадр в игре ---------
    void Update()
    {
        
        Walk();
        if (moveVector.x > 0 && !facingRight)
            Flip();
        if (moveVector.x < 0 && facingRight)
            Flip();
    }
    //------- Функция/метод для перемещения персонажа по горизонтали ---------
    public Vector2 moveVector;
    public int speed;
    void Walk()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));

        /*anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        anim.SetBool("AttackChecker", Input.GetMouseButton(0));*/
    }
    //------- Функция/метод для отражения персонажа по горизонтали ---------
    public bool facingRight = true;
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
    //-----------------------------------------------------------------

}