using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase_Enemy : MonoBehaviour
{
    [SerializeField]
    Shikai_Enemy shikai;

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
        //ÉvÉåÉCÉÑÅ[Ç™Ç¢ÇÈÇ»ÇÁÇŒí«Ç¢Ç©ÇØÇÈ
        if (Destination != null) shikai.ChaseMovement( Destination.transform );
    }
}
