using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollin : MonoBehaviour
{
    public float speed;
    private void Start()
    {
        Invoke("Destroy", 10f);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

}
