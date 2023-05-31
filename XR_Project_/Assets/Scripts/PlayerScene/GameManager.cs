using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // UI �߰� 
using System;                       // �߰� 

public class GameManager : MonoBehaviour
{
    protected SceneChanger SceneChanger => SceneChanger.Instance;
    public enum GameState           //���� ���°� ����
    {
        Start,
        Playing,
        GameOver
    }

    public event Action<GameState> OnGameStateChanged;

    public GameState currentState = GameState.Start;

    public GameState CurrentState
    {
        get { return currentState; }
        private set
        {
            currentState = value;
            OnGameStateChanged?.Invoke(currentState);       //�̺�Ʈ�� null�� �ƴѰ�쿡�� �� �̺�Ʈ�� ȣ�� 
        }
    }

    public void StartGame()
    {   //���� ���� ������ ���⿡ �ۼ�
        CurrentState = GameState.Playing;
    }

    public void GameOver()
    {   //���� ���� ������ ���⿡ �ۼ�
        CurrentState = GameState.GameOver;
        SceneChanger.LoadEndScene();
    }

    public GameManager() { }
    public static GameManager Instance { get; private set; }    //�̱���ȭ
    public PlayerHp playerHp;                   //�÷��̾��� Hp
    public Image playerHpUIImage;               //�÷��̾� Hp UI �̹���
    public Button BtnSample;                    //UI ��ư ����

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
