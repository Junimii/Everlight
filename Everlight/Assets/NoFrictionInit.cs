using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoFrictionInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void Awake()
    {
        // สร้าง PhysicsMaterial2D ขึ้นมาใหม่
        PhysicsMaterial2D mat = new PhysicsMaterial2D("NoFric");
        mat.friction = 0f;
        mat.bounciness = 0f;

        // เอาไปใส่ให้ Collider2D ของตัวละคร
        Collider2D col = GetComponent<Collider2D>();
        col.sharedMaterial = mat;
    }
}
