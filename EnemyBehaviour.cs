using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SVS.AI;
using Platformer.Mechanics;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed;

    private Transform target;
    public AiPlayerEnterAreaDetector areaDetector;
    public AnimationController animationController;

    public Rigidbody2D rb2d;
    public SpriteRenderer spriteRenderer;
    Animator attackAnim;

    bool facingRight = true;
    public bool playerOnRightSide;
    public bool playerOnLeftSide;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        attackAnim = gameObject.GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyAttack();
        if (areaDetector.PlayerInArea)
        {
            //ChasePlayer();
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if (gameObject.transform.position.x < 0 && !facingRight)
            Flip();
        if (gameObject.transform.position.x > 0 && facingRight)
            Flip();
    }

    /**public void ChasePlayer()
    {
        if (transform.position.x < target.position.x)
        {
            // player on right side
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            //spriteRenderer.flipX = false;
            playerOnRightSide = true;
            playerOnLeftSide = false;
        }
        else
        {
            //player on right side
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            //spriteRenderer.flipX = true;
            playerOnRightSide = false;
            playerOnLeftSide = true;
        }
    }**/

    void EnemyAttack()
    {
        if (Vector2.Distance(transform.position, target.position) <= 3)
        {
            attackAnim.SetBool("targetInAttackRange", true);
        }
        else 
        { 
            attackAnim.SetBool("targetInAttackRange", false);
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
