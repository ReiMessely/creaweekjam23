using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 10;

    [SerializeField] private float _damage = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * _movementSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            return;
        }

        Health targetHealth = other.GetComponentInParent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(_damage);
        }
        Kill();
    }

    void Kill()
    {
        Destroy(gameObject);
    }

    public float GetDamage
    {
        get { return _damage; }
    }
}
