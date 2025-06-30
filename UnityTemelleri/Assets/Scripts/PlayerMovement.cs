using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerMovement : MonoBehaviour
{
    // Oyuncuyu hareket ettirirken kullanilacak olan NavMeshAgent
    [SerializeField] private NavMeshAgent agent;

    void Awake()
    {
        // NavMeshAgent bileşenini al
        agent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Fare sol tusuna basildiginda fare konumunu al
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // RaycastHit yapisi ile raycast sonucunu tut
            RaycastHit hit;
            // Raycast ile fare konumundaki objeyi kontrol et
            // GroundLayerMask ile sadece "Ground" katmanındaki objelere bak
            if (Physics.Raycast(ray, out hit))
            {
                // NavMeshAgent'i hedef konuma hareket ettir
                agent.SetDestination(hit.point);
            }
        }
    }
}
