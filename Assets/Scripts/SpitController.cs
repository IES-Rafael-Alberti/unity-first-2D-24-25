using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class SpitController : MonoBehaviour {
    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start() {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        Debug.Log(_rb);
    }

    private void FixedUpdate()
    {
        Debug.Log(_rb.velocity);
        Vector2 v = _rb.velocity;
        float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Boss"))
            Destroy(gameObject);
    }
}
