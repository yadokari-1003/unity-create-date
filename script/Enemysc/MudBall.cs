using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudBall : MonoBehaviour
{
    /*   �}�b�h�{�[���̃X�N���v�g�@*/

    //�v���[���[�X�N���v�g
    test ss;

    //�_���[�W�ϐ�
    int muddamage = 1;�@

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D col)�@//�����蔻��Ǘ�
    {
        if (col.gameObject.tag == "Player")�@//�v���[���̏ꍇ
        {
            Destroy(this.gameObject);
            ss = GameObject.Find("Suraim Player").GetComponent<test>();
            ss.EnemyDamegeCal(muddamage);
        }

        if (col.gameObject.tag == "Suraim Ball")�@//�X���C���{�[���̏ꍇ
        {
            Destroy(this.gameObject);
        }
    }
}
