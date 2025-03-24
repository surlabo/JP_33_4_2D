using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer character;
    [SerializeField] private AttackZone rightAttackZone;
    [SerializeField] private AttackZone leftAttackZone;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (character.flipX == true)
            {
                leftAttackZone.Attack();
            }
            else
            {
                rightAttackZone.Attack();
            }
        }
    }
}
