using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject ballPrefab;
    public GameObject playerPrefab;
    //public GameObject itemPrefab;
    public Text scoreText;
    public Text ballsText;
    public Text levelsText;
    public Text highscoreText;
    public GameObject panelMenu;
    public GameObject panelPlay;
    public GameObject panelLevelCompleted;
    public GameObject panelGameOver;
    public GameObject[] levels;
    
    private GameObject activPlayer;

    public static GameManager Instance {get; private set;}

    public enum State {MENU, INIT, PLAY, LEVELCOMPLETED, LOADLEVEL, GAMEOVER}
    State _state;

    GameObject _currentBall;
    GameObject _currentLevel;
    bool _isSwitchungState;

    private int _score;
    public int Score
    {
        get { return _score; }
        set { _score = value; 
            scoreText.text = "SCORE: " + _score;
        }
    }
    
    private int _level;
    public int Level
    {
        get { return _level; }
        set { _level = value; 
            levelsText.text = "LEVEL: " + _level;
        }
    }

    private int _balls;
    public int Balls
    {
        get { return _balls; }
        set { _balls = value; 
            ballsText.text = "BALLS: " + _balls;
        }
    }
    
    

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        SwitchState(State.MENU);
       // PlayerPrefs.DeleteKey("highscore");
    }

    public void PlayClicked()
    {
        SwitchState(State.INIT);
    }

    // Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            case State.MENU:
                break;
            case State.INIT:
                break;
            case State.PLAY:
                if(_currentBall == null)
                {
                    if(Balls > 0)
                    {
                        _currentBall = Instantiate(ballPrefab);
                    }
                    else
                    {
                        SwitchState(State.GAMEOVER);
                    }

                }
                if(_currentLevel != null && _currentLevel.transform.childCount == 0 && !_isSwitchungState)
                {
                    SwitchState(State.LEVELCOMPLETED);
                }
                break;
            case State.LEVELCOMPLETED:
                break;
            case State.LOADLEVEL:
                break;
            case State.GAMEOVER:
                if(Input.anyKeyDown)
                {
                    SwitchState(State.MENU);
                }
                break;
            
        }
    }

    public void SwitchState(State newState, float delay = 0) 
    {
        StartCoroutine(SwitchDelay(newState, delay));
    }

    IEnumerator SwitchDelay(State newState, float delay)
    {
        _isSwitchungState = true;
        yield return new WaitForSeconds(delay);
        EndState();
        _state = newState;
        BeginState(newState);
        _isSwitchungState = false;
    }

    void BeginState(State newState)
    {
        switch (newState)
        {
            case State.MENU:
                Cursor.visible = true;
                highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore");
                panelMenu.SetActive(true);
                break;
            case State.INIT:
                Cursor.visible = false;
                panelPlay.SetActive(true);
                Score = 0;
                Level = 0;
                Balls = 3;
                if (_currentLevel != null)
                {
                    Destroy(_currentLevel);
                }
                Instantiate(playerPrefab); 
                SwitchState(State.LOADLEVEL);

                activPlayer = GameObject.FindGameObjectWithTag("Player");      
                foreach (Transform child in activPlayer.transform)
                {
                    child.gameObject.SetActive(false);
                } 

                break;
            case State.PLAY:
                break;
            case State.LEVELCOMPLETED:
                Destroy(_currentBall);
                Destroy(_currentLevel);
                Level++;
                panelLevelCompleted.SetActive(true);
                SwitchState(State.LOADLEVEL, 2f);         
                break;
            case State.LOADLEVEL:
                if (Level >= levels.Length)
                {
                    SwitchState(State.GAMEOVER);
                }else
                {
                    _currentLevel = Instantiate(levels[Level]);
                    SwitchState(State.PLAY);
                }
                break;
            case State.GAMEOVER:
                if(Score > PlayerPrefs.GetInt("highscore"))
                {
                    PlayerPrefs.SetInt("highscore", Score);
                }
                panelGameOver.SetActive(true);
                break;
            
        }
    }

    void EndState()
    {
        switch (_state)
        {
            case State.MENU:
            panelMenu.SetActive(false);
                break;
            case State.INIT:
                break;
            case State.PLAY:
                break;
            case State.LEVELCOMPLETED:
                panelLevelCompleted.SetActive(false);
                break;
            case State.LOADLEVEL:
                break;
            case State.GAMEOVER:
                panelPlay.SetActive(false);
                panelGameOver.SetActive(false);
                break;
            
        }
    }
}
