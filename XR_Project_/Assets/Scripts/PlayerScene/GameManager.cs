using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // UI �߰� 

public class GameManager : MonoBehaviour
{    public GameManager() { }
    public static GameManager Instance { get; private set; }    //�̱���ȭ
    public PlayerHp playerHp;                   //�÷��̾��� Hp
    public Image playerHpUIImage;               //�÷��̾� Hp UI �̹���
    public Button BtnSample;                    //UI ��ư ����

    private void Start()
    {
        this.BtnSample.onClick.AddListener(() =>        //Listenr �� ��ư ��� 
        {
            Debug.Log("Button Check");
        });
    }

    private void Awake()
    {
        if(Instance)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            transform.parent = null;
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        Init();
    }
    private void Init()
    {
        playerHp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHp>();                     //Tag�� ������Ʈ�� ã�´�.
        playerHpUIImage = GameObject.FindGameObjectWithTag("UIHealthBar").GetComponent<Image>();            //Tag�� UI�� ã�´�.
    }
    private void Update()
    {
        playerHpUIImage.fillAmount = (float)playerHp.Hp / 100.0f;                                            //ü�¿� ����ϰ� �۾�
    }
}
