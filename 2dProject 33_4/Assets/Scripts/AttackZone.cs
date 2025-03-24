using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    [SerializeField] private float attackTime = .2f;
    [SerializeField] private BoxCollider2D body;

    private Coroutine attackCoroutine;
    public void Attack()
    {
        body.enabled = true;

        if (attackCoroutine != null )
        {
            StopCoroutine(attackCoroutine);
        }

        attackCoroutine = StartCoroutine(AtackTimer());
    }

    private IEnumerator AtackTimer()
    {
        yield return new WaitForSeconds(attackTime);
        body.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyController>().GetHit();
        }
    }
}
