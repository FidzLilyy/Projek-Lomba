using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour
{
    public Animator animator;
    
    public GameObject panel, panel1, menuBeres;

    public Button button;

    public string animation, animation1;
    public string scene;
    public TextMeshProUGUI scoreText, scoreText1, dapatUang;
    public int score, jmlKlik, totalUang;
    public bool rules = false;

    private RectTransform buttonRect;

    void Start()
    {
        animator.Play(animation);
        buttonRect = button.GetComponent<RectTransform>();
        button.gameObject.SetActive(false);
        panel1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            panel1.SetActive(false);
            rules = true;
        }
        if(rules){
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("BattleAnimation") && stateInfo.normalizedTime >= 5.0f || Input.GetKeyDown(KeyCode.Return)){
                Time.timeScale = 0.1f;
                panel.SetActive(true);
                button.gameObject.SetActive(true);
            }

            if (stateInfo.IsName("Battle1") && stateInfo.normalizedTime >= 3.0f /*|| Input.anyKeyDown*/){
                Time.timeScale = 0.1f;
                scoreText1.text = "Score = " + score;
                totalUang = 1500 * score;
                dapatUang.text = "Dapat Uang = " + totalUang;
                panel.SetActive(true);
                menuBeres.SetActive(true);
                //button.gameObject.SetActive(true);

                jmlKlik = 0;
            }
        }
    }

    void TombolAcak(){
        RectTransform canvasRect = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        float x = Random.Range(-canvasRect.rect.width / 2 + buttonRect.rect.width / 2,
                                canvasRect.rect.width / 2 - buttonRect.rect.width / 2);
        float y = Random.Range(-canvasRect.rect.height / 2 + buttonRect.rect.height / 2,
                                canvasRect.rect.height / 2 - buttonRect.rect.height / 2);

        buttonRect.anchoredPosition = new Vector3(x, y, 0);
    }

    public void ButtonKlik()
    {
        jmlKlik = jmlKlik + 1;
        score += 2;
        scoreText.text = "Score = " + score;
        Debug.Log(jmlKlik);
        if(jmlKlik < 5){
            TombolAcak();
        }else{
            button.gameObject.SetActive(false);
            panel.SetActive(false);
            Time.timeScale = 1f;
            animator.Play(animation1);
        }
    }

    public void Next(){
        Uang.uang = Uang.uang + totalUang;
        score = 0;
        totalUang = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
    }
}
