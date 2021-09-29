using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target = null;
    [SerializeField] float speed = 30f;
    [SerializeField] GameObject impactEffect;
    [SerializeField] float exploisonRadius = 0f;
    public int damage = 50;

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    void Update()
    {

        Move();
    }

    void Move()
    {

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        float movementThisFrame = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, movementThisFrame);
        transform.LookAt(target);

        if (transform.position == target.position)
        {
            GameObject effectInst =(GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectInst, 2f);

            if(exploisonRadius > 0f)
            {
                Explode();
            }
            else
            {
                Damage(target);
            }

            Destroy(gameObject);
            
        }

    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,exploisonRadius);

        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage (Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if(e != null)
        {
            e.TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, exploisonRadius);
    }

}
