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

        // �^�C�}�[�����炷
        nowTime -= Time.deltaTime;

        if (nowTime <= 0)
        {
            // �e����
            CreateShotObject(-transform.localEulerAngles.y);

            // �^�C�}�[���Z�b�g
            nowTime = time;
        }
    }

    private void CreateShotObject(float axis)
    {
        // �x�N�g���擾
        var direction = player.transform.position - transform.position;
        direction.y = 0;    // �x�N�g����y��������

        // �������Ƃ�
        var lookRotation = Quaternion.LookRotation(direction, Vector3.up);

        // �e�𐶐�
        GameObject bulletClone =
            Instantiate(bullet, transform.position, Quaternion.identity);

        // EnemyBullet�̃Q�b�g�R���|�[�l���g��ϐ��Ƃ��ĕۑ�
        var bulletObject = bulletClone.GetComponent<EnemyBullet>();

        // �e��ł��o�����I�u�W�F�N�g�̏���n��
        bulletObject.SetCharcterObject(gameObject);

        // �e��ł��o���p�x�����߂�
        bulletObject.SetForwardAxis(lookRotation * Quaternion.AngleAxis(axis, Vector3.up));

    }
}
