using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handScaleControl : MonoBehaviour
{
    public EnemyBehaviour enemyBehaviour;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void FixedUpdate()
    {
        if (enemyBehaviour.playerOnLeftSide)
            Flip();
        if (enemyBehaviour.playerOnRightSide)
            Flip();
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.position;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
    }
}
