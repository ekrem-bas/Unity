using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Scripts.Tower
{
    public class Tower : MonoBehaviour
    {
        private Camera cam;
        [SerializeField] private GameObject towerPrefab; // Yerleştirilecek kule prefab'ı (Inspector'dan atanacak)
                                                         // Start is called before the first frame update
        void Start()
        {
            cam = Camera.main; // Ana kamerayı al
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(1)) // Sağ fare tuşu
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition); // Fare pozisyonundan bir ray oluştur
                RaycastHit hit; // Raycast sonucu için bir değişken
                if (Physics.Raycast(ray, out hit))
                {
                    // Sadece Ground tag'ına sahip yerlere kule yerleştir
                    if (hit.collider.gameObject.CompareTag("Ground"))
                    {
                        Vector3 spawnPosition = hit.point + Vector3.up * 1.507f; // 0.5 birim yukarı
                        Instantiate(towerPrefab, spawnPosition, Quaternion.identity);
                    }
                }
            }
        }
    }
}