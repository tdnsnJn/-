using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Kanban_shikai : MonoBehaviour
{
    Rigidbody kanban;
    public Stage3_perspon stage3;
    public Transform EnemySt;
    NavMeshAgent nav;
    // == �^�[�Q�b�g�ݒ�
    private Transform target;           // �ǐՃ^�[�Q�b�g
    private Vector3 targetDirection;  // �^�[�Q�b�g�̌����x�N�g��
    private float targetDistance;   // �^�[�Q�b�g�̋���
    private float targetAngle;      // �^�[�Q�b�g�̊p�x
    public bool kan;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        kanban = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        kan = stage3.IsVisible();
        if(kan == true)
        {
            nav.speed = 0.0f;
            kanban.velocity = Vector3.zero;
        }
        else
        {
            nav.speed = 12.0f;
        }
    }
    public void Reset()
    {
        transform.position = EnemySt.position;
    }
    public void ChaseMovement(Transform target)
    {
        //��l���̕���
        targetDirection = target.position - transform.position;
        //�G�̑O������̕���
        targetDirection.y = 0;
        targetAngle = Vector3.Angle(transform.forward, targetDirection);
        targetDistance = Vector3.Distance(target.position, this.transform.position);
    }
}
