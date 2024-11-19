using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Meid_chase : MonoBehaviour
{
    [SerializeField]
    Meid_shikai shikai;

    NavMeshAgent Enemy_nav;
    GameObject Destination;
    // Start is called before the first frame update
    void Start()
    {
        Enemy_nav = GetComponent<NavMeshAgent>();
        Destination = GameObject.Find("Capsule");
    }

    // Update is called once per frame
    void Update()
    {
        Enemy_nav.SetDestination(Destination.transform.position);
        //�v���C���[������Ȃ�Βǂ�������
        if (Destination != null) shikai.ChaseMovement(Destination.transform);
    }
}
