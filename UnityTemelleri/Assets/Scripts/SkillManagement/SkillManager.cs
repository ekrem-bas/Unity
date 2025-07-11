using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.Enemy;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    // Cursor'ı değiştirmek için kullanılacak
    public CursorManager cursorManager;
    // herhangi bir skill tıklandı mı kontrolü
    public bool skillClicked = false;
    // bu frame'de input consume edildi mi kontrolü
    public bool inputConsumedThisFrame = false;
    // seçilen skill'in indexi
    public int selectedSkill = -1;
    // skillManager singleton örneği
    public static SkillManager instance;
    public PlayerData playerData;
    public GameObject meteorPrefab;
    Meteor meteorScript;
    public GameObject beamPrefab;
    Beam beamScript;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        meteorScript = meteorPrefab.GetComponent<Meteor>();
        beamScript = beamPrefab.GetComponent<Beam>();
    }
    void LateUpdate()
    {
        if (PlayerHealthManager.isPlayerDead)
        {
            // Eğer oyuncu ölmüşse skill seçimini engelle
            skillClicked = false;
            selectedSkill = -1;
            cursorManager.ResetCursor();
            cursorManager.HideAreaIndicator();
            return; // Hiçbir şey yapma
        }
        // Her frame sonunda input consume flag'ini sıfırla
        inputConsumedThisFrame = false;
    }

    public void SelectSkill(int skillIndex)
    {
        // eğer seçilen skill zaten tıklanmışşsa
        // ve yine aynı skill tıklanırsa
        // skill'i resetle
        if (skillClicked && selectedSkill == skillIndex)
        {
            ResetSkill();
        }
        else
        {
            // seçili skill'e göre cursor'ı değiştir
            selectedSkill = skillIndex;
            cursorManager.SetCustomCursor(skillIndex);
            // skill tıklandı olarak işaretle
            skillClicked = true;
        }
    }

    public void ResetSkill()
    {
        // skill'i resetle
        skillClicked = false;
        selectedSkill = -1;
        cursorManager.ResetCursor();
        cursorManager.HideAreaIndicator();
        // Input'u consume et
        inputConsumedThisFrame = true;
    }

    // Meteor düşünce ne olacağının fonksiyonu
    public void OnMeteorAreaSelected(Vector3 position)
    {
        Debug.Log("Meteor düşecek pozisyon: " + position);
        Instantiate(meteorPrefab, position + (Vector3.up * meteorScript.meteorFallStartHeight), Quaternion.identity);
        ResetSkill();
    }

    // Beam skill hedef seçildiğinde ne olacağı
    public void OnBeamTargetSelected(GameObject enemy)
    {
        Debug.Log("Beam hedefi: " + enemy.name);
        // Beam prefab'ını instantiate et
        Instantiate(beamPrefab, enemy.transform.position + Vector3.up * beamScript.beamStartHeight, Quaternion.identity);
        ResetSkill();
    }
}
