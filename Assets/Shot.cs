using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject Bullet;
    public int maxShotTimer;
    private int shotTimer;

    // Start is called before the first frame update
    void Start()
    {
        shotTimer = maxShotTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            shotTimer++;
            if (shotTimer >= maxShotTimer)
            {
                Instantiate(Bullet, transform.position, Quaternion.identity);
                shotTimer = 0;
            }
        }
    }
}
