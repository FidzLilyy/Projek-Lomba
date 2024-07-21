using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Battle : MonoBehaviour
{
    public Animator animator;
    
    public GameObject panel;

    public Button button;

    public string[] animation;
    public TextMeshProUGUI scoreText;
    public float timeLimit;
    public int score, currentArray = 0;
    public bool battle;

    private RectTransform buttonRect;
    private float timer;

    void Start()
    {
        animator.Play(animation[currentArray]);
        buttonRect = button.GetComponent<RectTransform>();
        //RandomizeButtonPosition();
        button.onClick.AddListener(OnButtonClick);
        button.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime >= 1.0f /*|| Input.anyKeyDown*/){
            Time.timeScale = 0.1f;
            panel.SetActive(true);
            battle = true;
            button.gameObject.SetActive(true);
        }

        if(battle){
            timer += Time.deltaTime;
            if(timer >= timeLimit){
                timer = 0;
                TombolAcak();
            }
        }

        if(currentArray >= animation.Length){
            panel.SetActive(true);
        }
    }

    void TombolAcak(){
        RectTransform canvasRect = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        float x = Random.Range(-canvasRect.rect.width / 2 + buttonRect.rect.width / 2,
                                canvasRect.rect.width / 2 - buttonRect.rect.width / 2);
        float y = Random.Range(-canvasRect.rect.height / 2 + buttonRect.rect.height / 2,
                                canvasRect.rect.height / 2 - buttonRect.rect.height / 2);

        // Mengatur posisi acak
        buttonRect.anchoredPosition = new Vector2(x, y);
    }

    void OnButtonClick()
    {
        if (timer <= timeLimit)
        {
            score += 1;
            scoreText.text = "Score =" + score;
            Debug.Log("Button clicked!");
            currentArray++;
            button.gameObject.SetActive(false);
            battle = false;
            panel.SetActive(false);
            Time.timeScale = 1f;
        }
        animator.Play(animation[currentArray]);

        timer = 0;
        TombolAcak();
    }
}
