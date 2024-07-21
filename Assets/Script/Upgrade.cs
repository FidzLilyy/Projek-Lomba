using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public int needUang;
    bool siapUpgrade = false, sudahUpgrade;

    public GameObject upgradeIcon;
    public GameObject menuUpgrade, panel;

    public Sprite upgradePanggung, upgradeKarpet;

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

        if(CompareTag("Carpet")){
                UpgradeKarpet();
            }
            
            else if(CompareTag("Panggung")){
                UpgradePanggung();
            }else if(CompareTag("Tempat")){
                UpgradeTempat();
            }

        panel.SetActive(false);
        menuUpgrade.SetActive(false);
        needUang = needUang + 999999999;
        sudahUpgrade = true;
    }

    void UpgradeKarpet()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = upgradeKarpet;
            print("Karpet upgraded");
            sudahUpgrade = false;
        }

        // transform.position += new Vector3(-1f, 0, 0);
        // Vector3 posisiObjek = transform.position + new Vector3(1.8f, 0f, 0f);
        // Instantiate(kursi, posisiObjek, Quaternion.identity);
        // sudahUpgrade = false;
    }

    void UpgradePanggung()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = upgradePanggung;
            print("Panggung upgraded");
            sudahUpgrade = false;
        }
    }

    void UpgradeTempat(){
        transform.localScale += new Vector3(1F, 1f, 1f);
    }


    public void Close(){
        panel.SetActive(false);
        menuUpgrade.SetActive(false);
    }
}
