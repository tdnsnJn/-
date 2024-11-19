using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

public class Meid_shikai : MonoBehaviour
{
    [SerializeField]
    private SphereCollider Search;
    [SerializeField]
    private float searchAnge = 30f;
    [SerializeField]
    private float searchDistance = 20f;
    [SerializeField]
    private float radius = 20f;
    public Transform EnemySt;
    NavMeshAgent nav;
    [SerializeField]
    private Animator anim;
    public AudioClip clip;
    public AudioSource source;
    public GameObject fireprefab;
    private float ftime;
    // == �^�[�Q�b�g�ݒ�
    private Transform target;           // �ǐՃ^�[�Q�b�g
    private Vector3 targetDirection;  // �^�[�Q�b�g�̌����x�N�g��
    private float targetDistance;   // �^�[�Q�b�g�̋���
    private float targetAngle;      // �^�[�Q�b�g�̊p�x
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        //anim = GetComponent<Animator>();
        Search.radius = radius;
    }

    // Update is called once per frame
    void Update()
    {
        ftime += Time.deltaTime;
        if(ftime >= 7)
        {
            nav.speed = 0.0f;
            source.PlayOneShot(clip);
            Instantiate(fireprefab, this.transform.position + this.transform.forward * 8, this.transform.rotation);
            anim.SetTrigger("isFire");
            ftime = 0;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log($"Hits");

            target = other.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {

        }
    }

    public void Reset()
    {
        transform.position = EnemySt.position;
    }
#if UNITY_EDITOR
    //�p�x�\��
    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawSolidArc(transform.position, Vector3.up, Quaternion.Euler(0f, -searchAnge, 0f) * transform.forward, searchAnge * 2f, Search.radius);
    }
#endif
    public void ChaseMovement(Transform target)
    {
        //��l���̕���
        targetDirection = target.position - transform.position;
        //�G�̑O������̕���
        targetDirection.y = 0;
        targetAngle = Vector3.Angle(transform.forward, targetDirection);
        targetDistance = Vector3.Distance(target.position, this.transform.position);

        //Debug.Log($"�T�[�` >> { playerDirection }, { angle }, { searchAnge }, { angle <= searchAnge }, { other.name }");
        //�T�[�`����p�x���������甭��
        if (targetAngle <= searchAnge && targetDistance < searchDistance)
        {
            //Debug.Log("����" + angle);
            nav.speed = 14.0f;
            anim.SetBool("isRunning", true);
            BGM_manager bgm = GameObject.Find("BGM").GetComponent<BGM_manager>();
            bgm.PlayBGM(1);

        }
        else
        {
            nav.speed = 3.5f;
            anim.SetBool("isRunning", false);
            BGM_manager bgm = GameObject.Find("BGM").GetComponent<BGM_manager>();
            bgm.PlayBGM(0);
        }
    }
}
