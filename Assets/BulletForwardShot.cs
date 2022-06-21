using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForwardShot : MonoBehaviour
{
    private GameObject player;
    public GameObject bullet;
    public float time = 1;
    public float delayTime = 1;
    float nowTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        nowTime = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        // タイマーを減らす
        nowTime -= Time.deltaTime;

        if (nowTime <= 0)
        {
            // 弾生成
            CreateShotObject(-transform.localEulerAngles.y);

            // タイマーリセット
            nowTime = time;
        }
    }

    private void CreateShotObject(float axis)
    {
        // ベクトル取得
        var direction = player.transform.position - transform.position;
        direction.y = 0;    // ベクトルのyを初期化

        // 向きをとる
        var lookRotation = Quaternion.LookRotation(direction, Vector3.up);

        // 弾を生成
        GameObject bulletClone =
            Instantiate(bullet, transform.position, Quaternion.identity);

        // EnemyBulletのゲットコンポーネントを変数として保存
        var bulletObject = bulletClone.GetComponent<EnemyBullet>();

        // 弾を打ち出したオブジェクトの情報を渡す
        bulletObject.SetCharcterObject(gameObject);

        // 弾を打ち出す角度を決める
        bulletObject.SetForwardAxis(lookRotation * Quaternion.AngleAxis(axis, Vector3.up));

    }
}
