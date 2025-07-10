using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    // Cursor'ı değiştirmek için kullanılacak
    public CursorManager cursorManager;
    // herhangi bir skill tıklandı mı kontrolü
    public bool skillClicked = false;
    // seçilen skill'in indexi
    public int selectedSkill = -1;
    // skillManager singleton örneği
    public static SkillManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
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
    }

    // Skill'ler için butonlara tıklandığında çağrılacak fonksiyonlar
    public void MeteorSkill()
    {
        SelectSkill(0);
    }

    public void BeamSkill()
    {
        SelectSkill(1);
    }

    // Meteor düşünce ne olacağının fonksiyonu
    public void OnMeteorAreaSelected(Vector3 position)
    {
        Debug.Log("Meteor düşecek pozisyon: " + position);
        // Meteor instantiate edilmeli
        // Meteor düşünce efekt olmalı
        // düştüğü alandaki düşmanlara hasar vermeli
        ResetSkill();
    }

    // Beam skill hedef seçildiğinde ne olacağı
    public void OnBeamTargetSelected(GameObject enemy)
    {
        Debug.Log("Beam hedefi: " + enemy.name);
        // Beam skill efekti uygulanmalı
        // seçilen düşmana hasar verilmeli
        ResetSkill();
    }
}
