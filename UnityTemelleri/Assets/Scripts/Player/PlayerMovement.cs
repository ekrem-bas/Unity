using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

namespace Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        // Oyuncuyu hareket ettirirken kullanilacak olan NavMeshAgent
        [SerializeField] private NavMeshAgent agent;
        public PlayerData playerData;
        private Camera cam;
        private float speed = 5f; // Oyuncunun hareket hızı

        void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        void Start()
        {
            cam = Camera.main; // Ana kamerayı al
            agent.speed = speed; // NavMeshAgent'in hızını ayarla
        }

        // Update is called once per frame
        void Update()
        {
            // Fare sol tusuna basildiginda ve UI elemanlari uzerinde degilse
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                // Fare sol tusuna basildiginda fare konumunu al
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
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
}