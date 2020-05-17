using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    enum GameState
    {
        Ready,
        Play,
        End
    }

    [SerializeField] GameState gameState;
    [SerializeField] BoatController boatController;
    [SerializeField] CanvasGroup BlackBord;
    [SerializeField] CanvasGroup TitlePanel;
    [SerializeField] CanvasGroup EndPanel;
    [SerializeField] Text EndTimeBord;

    float _time;

    [Header("カメラ群")]
    [SerializeField] GameObject mainCam;
    [SerializeField] GameObject subCam;
    [SerializeField] GameObject EndCam;

    [Header("チェックポイント")]
    public List<CheckPoint> checkPoints;

    // Start is called before the first frame update
    void Start()
    {
        _time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameState.Ready:

                boatController.enabled = false;

                if (Keyboard.current.spaceKey.isPressed)
                {
                    gameState = GameState.Play;
                    ToStart();
                }

                break;

            case GameState.Play:
                boatController.enabled = true;

                _time += Time.deltaTime;

                if(checkPoints.Count <= 0)
                {
                    gameState = GameState.End;
                    ToEnd();
                }
                break;

            case GameState.End:

                EndTimeBord.text = "航海時間\n" + _time.ToString("00.00");

                if (Keyboard.current.spaceKey.isPressed)
                {
                    SceneManager.LoadScene(0);
                }

                break;
        }
    }

    void ToStart()
    {
        Sequence se = DOTween.Sequence();
        
        se.Append(TitlePanel.DOFade(0f, 0.5f));

        se.Join(BlackBord.DOFade(1f, 0.5f)).AppendCallback(() =>
        {
            mainCam.SetActive(!mainCam.activeSelf);
            subCam.SetActive(!subCam.activeSelf);
        });

        se.Append(BlackBord.DOFade(0f, 0.5f));

        se.Play();
    }



    void ToEnd()
    {
        Sequence se = DOTween.Sequence();

        se.Append(BlackBord.DOFade(1f, 0.5f)).AppendCallback(() =>
        {
            mainCam.SetActive(!mainCam.activeSelf);
            EndCam.SetActive(!subCam.activeSelf);
        });

        se.Append(BlackBord.DOFade(0f, 0.5f));

        se.Append(EndPanel.DOFade(1f, 0.5f));

        se.Play();
    }

    public void NextPoint()
    {
        checkPoints[0].gameObject.SetActive(true);
    }
}
