using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public int needUang;
    bool siapUpgrade = false;

    public GameObject upgradeIcon;
    public GameObject menuUpgrade, panel;

    Sprite upgradeMusic, upgradePanggung, upgradeKarpet;

    void Update()
    {
        UpgradeBangunan();
    }

    void UpgradeBangunan(){
        if(Uang.uang >= needUang && !siapUpgrade){
            upgradeIcon.SetActive(true);
            // Vector3 poisisiObjek = transform.position + new Vector3(1f, 1f, 0);
            // Instantiate(upgradeIcon, poisisiObjek, Quaternion.identity);
            siapUpgrade = true;
        }else if(Uang.uang < needUang){
            siapUpgrade = false;
            upgradeIcon.SetActive(false);
        }
    }

    public void MenuUpgrade(){
        Debug.Log("Tag saat ini: " + gameObject.tag);
        panel.SetActive(true);
        menuUpgrade.SetActive(true);
    }

    public void UpgradeItem(){
        Uang.uang = Uang.uang - needUang;
        Debug.Log("Tag saat ini: " + gameObject.tag);

        if(CompareTag("Karpet")){
                UpgradeKarpet();
            }
            
            else if(CompareTag("Panggung")){
                UpgradePanggung();
            }else if(CompareTag("Music")){
                UpgradeMusic();
            }

        panel.SetActive(false);
        menuUpgrade.SetActive(false);
        needUang = needUang + 999999999;
    }

    void UpgradeKarpet()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            upgradeKarpet = Resources.Load<Sprite>("Karpet/karpet_upgrade");
            spriteRenderer.sprite = upgradeKarpet;
            print("Karpet upgraded");
        }else{
            print("Karpet Tidak Di Temukan");
        }
    }

    void UpgradePanggung()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            upgradePanggung = Resources.Load<Sprite>("Panggung/panggung_upgrade");
            spriteRenderer.sprite = upgradePanggung;
            print("Panggung upgraded");
        }else{
            print("Panggung Tidak Di Temukan");
        }
    }

    void UpgradeMusic(){
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            upgradeMusic = Resources.Load<Sprite>("Music/musik_upgrade");
            spriteRenderer.sprite = upgradeMusic;
            print("Music upgraded");
        }else{
            print("Music Tidak Di Temukan");
        }
    }


    public void Close(){
        panel.SetActive(false);
        menuUpgrade.SetActive(false);
    }
}
