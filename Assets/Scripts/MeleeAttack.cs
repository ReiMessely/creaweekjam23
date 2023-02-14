using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    private Enemy _enemyScript;
    private BoxCollider _boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Health playerHealth = other.gameObject.GetComponent<Health>();
            playerHealth.TakeDamage(_enemyScript.Damage);
        }
    }

    public Enemy EnemyScript
    {
        get { return _enemyScript; }
        set { _enemyScript = value; }
    }
}
