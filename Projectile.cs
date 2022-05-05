using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SVS.AI;

public class Projectile : MonoBehaviour
{
    public float LifeTime;
    public float speed;
    public int damage;
    
    private Transform player;
    private Vector2 targer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        targer = new Vector2(player.position.x, player.position.y-0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targer, speed * Time.deltaTime);

        LifeTime -= Time.deltaTime;

        if(LifeTime <= 0) //|| transform.position.x == targer.x && transform.position.y == targer.y)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealt player = other.GetComponent<PlayerHealt>();
        if(player != null)
        {
            player.TakeDamage(damage);
        }
        /**
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        **/
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
