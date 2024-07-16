using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Uang : MonoBehaviour
{
    TextMeshProUGUI sisaUang;

    public static int uang = 45000;

    // Start is called before the first frame update
    void Start()
    {
        sisaUang = GetComponent<TextMeshProUGUI>();
    }
    void Update(){
        SisaUang();
    }

    public void SisaUang(){
        sisaUang.text = "Uang : Rp. " + uang;
    }
}
