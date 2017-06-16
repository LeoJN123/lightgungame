using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Bullet : MonoBehaviour
{
    public float force = 100, lifetime = 5;
    public GameObject bulletHolePrefab;
    public LayerMask bulletHoleMask;
    private Rigidbody _rigidbody;
    private Vector3 velocity;

    void Start ()
    {
        _rigidbody = GetComponent<Rigidbody>();
        velocity = transform.forward * force;

        Destroy(gameObject, lifetime);
	}

    private void FixedUpdate()
    {
        _rigidbody.velocity = velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var other = collision.collider.gameObject;     
        bool hitBalloon = other.GetComponent<Balloon>() != null;

        if (hitBalloon)
        {
            other.SendMessageUpwards("ApplyDamage", SendMessageOptions.DontRequireReceiver);
            //gameObject.SendMessage("HasAppliedDamage", SendMessageOptions.DontRequireReceiver);
        }
        else
        {
            Destroy(gameObject);
        }

        // Player Collision Check (self hit)
        if (Player.instance && other == Player.instance.headCollider)
        {
            Player.instance.PlayerShotSelf();
        }

        //add bullet holes to objects on specific layers
        int layer = 1 << collision.gameObject.layer;
        if (bulletHolePrefab && (bulletHoleMask.value & layer) == layer)
        {
            var bulletHole = Instantiate(bulletHolePrefab).transform;

            bulletHole.position = collision.contacts[0].point + collision.contacts[0].normal * 0.003f;
            bulletHole.rotation = Quaternion.LookRotation(-collision.contacts[0].normal, Vector3.up);
            bulletHole.SetParent(collision.collider.transform, true);
        }
    }
}
