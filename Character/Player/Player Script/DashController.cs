using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashController : MonoBehaviour
{
    private Rigidbody2D rb;

    public DashState dashState;
    public float dashForce;
    public float dashTimer;
    public float maxDash;

    public DashCooldownController cooldownController;

    Animator dashAnim;

    public Vector2 savedVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashAnim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        switch (dashState)
        {
            case DashState.Ready:
                var isDashKeyDown = (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && Input.GetKeyDown(KeyCode.Space);
                if (isDashKeyDown)
                {
                    savedVelocity = rb.velocity;
                    rb.AddForce(new Vector2(rb.velocity.x * dashForce, 0f));
                    dashState = DashState.Dashing;
                    dashAnim.SetBool("isDashing", true);
                }
                break;
            case DashState.Dashing:
                dashTimer += Time.deltaTime * 3;
                cooldownController.IsDashActive();
                if (dashTimer >= maxDash)
                {
                    dashTimer = maxDash;
                    rb.velocity = savedVelocity;
                    dashState = DashState.Cooldown;
                    dashAnim.SetBool("isDashing", false);
                }
                break;
            case DashState.Cooldown:
                dashTimer -= Time.deltaTime;
                cooldownController.IsDashCooldown(dashTimer);
                if (dashTimer <= 0)
                {
                    dashTimer = 0;
                    dashState = DashState.Ready;
                    //dashAnim.SetBool("isDashing", false);
                }
                break;
        }
    }
}

public enum DashState
{
    Ready,
    Dashing,
    Cooldown
}
