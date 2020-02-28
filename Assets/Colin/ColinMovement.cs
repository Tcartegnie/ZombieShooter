using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColinMovement : MonoBehaviour
{
    public float speed;
    public float dashMult;
    public float recoilForce;
    Rigidbody rigidbody;
    public GameObject prefabBullet;
    public float shootDelay;
    float lastShoot = 0f;
    public Transform weaponTransform;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dir = new Vector3();
        dir.z = Input.GetAxis("Vertical");
        dir.x = Input.GetAxis("Horizontal");
        dir.Normalize();

        float curSpeed = speed;
        if(Input.GetMouseButtonDown(1))
        {
            curSpeed *= dashMult;
        }
    

        dir *= curSpeed;
        
        if(Input.GetMouseButton(0))
        {
            if(TryShoot())
            {
                dir -= transform.forward * recoilForce;
            }
        }
        
        rigidbody.velocity = dir * Time.deltaTime;
        

        
        if(lastShoot > 0f)
        {
            lastShoot -= Time.deltaTime;
        }
    }

    bool TryShoot()
    {
        if(lastShoot <= 0f)
        {
            lastShoot = shootDelay;
            Instantiate(prefabBullet, weaponTransform.transform.position, weaponTransform.rotation);
            return true;
        }
        return false;

    }
}
