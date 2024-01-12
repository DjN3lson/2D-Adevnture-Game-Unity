using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject enemyBear;
    public Collider2D attackCollider;
    public float attackRange = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        attackCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsPayerNearEnemy())
                Attack();
        }
    }

    bool IsPayerNearEnemy()
    {
        if (enemyBear != null)
        {
            float distance = Vector2.Distance(transform.position, enemyBear.transform.position);
            return distance <= attackRange;
        }
        return false;
    }

    void Attack()
    {
        if (enemyBear != null)
        {
            attackCollider.enabled = true;

            StartCoroutine(DisableColliderAfterDelay());
            EnemyController_BEAR bear = enemyBear.GetComponent<EnemyController_BEAR>();

            if (bear != null)
            {
                bear.Flash();
            }
        }
    }
    IEnumerator DisableColliderAfterDelay()
    {
        yield return new WaitForSeconds(0.5f);
        attackCollider.enabled = false;
    }
}
