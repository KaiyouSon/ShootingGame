using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 1;
    public float time = 2;
    protected Vector3 forward = new Vector3(0, 0, 1);        // 弾の正面ベクトル
    protected Quaternion forwardAxis = Quaternion.identity;  // 打ち出す時の角度
    protected Rigidbody rb;
    protected GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        if (enemy != null)
        {
            forward = enemy.transform.forward;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = forwardAxis * forward * speed;

        // 空中に浮かない処理
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        time -= Time.deltaTime;

        if (time <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerBody")
        {
            Destroy(this.gameObject);
        }
    }

    public void SetCharcterObject(GameObject charcter)
    {
        this.enemy = charcter;
    }

    // 打つ角度を決める
    public void SetForwardAxis(Quaternion axis)
    {
        this.forwardAxis = axis;
    }
}
