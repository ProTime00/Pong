using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PartyManager : MonoBehaviour
{
    public int scoreLeft;
    public TextMeshProUGUI endText;
    public int scoreRight;
    public GameObject ballPrefab;
    private int _wait = 150;
    private bool _scoredRight;
    private bool _scoredLeft;
    private BallMovement _ballMovement;
    public GameObject paddleLeft;
    public GameObject paddleRight;
    public Camera test;
    
    private InputAction _restart;
    private Pong _actions;
    
    public static PartyManager Instance;

    private void Awake()
    {
        endText.gameObject.SetActive(false);
        _actions = new Pong();
        Instance = this;
    }

    private void OnEnable()
    {
        _restart = _actions.Player.Restart;
        _restart.Enable();
        _restart.performed += _ => Restart();
    }

    private void OnDisable()
    {
        _restart.Disable();
    }

    private void Start()
    {
        _ballMovement = ballPrefab.GetComponent<BallMovement>();
    }

    private void FixedUpdate()
    {
        if (_scoredLeft)
        {
            _wait--;
            if (_wait == 0)
            {
                _wait = 150;
                _scoredLeft = false;
                _ballMovement.moveDirectionX = 1;
                ballPrefab.gameObject.SetActive(true);
                _ballMovement.StartBis();
                //destroyed = Instantiate(ballPrefab);
            }
        }

        if (_scoredRight)
        {
            _wait--;
            if (_wait == 0)
            {
                _wait = 150;
                _scoredRight = false;
                _ballMovement.moveDirectionX = -1;
                ballPrefab.gameObject.SetActive(true);
                _ballMovement.StartBis();
                //destroyed = Instantiate(ballPrefab);
            }
        }
    }

    public void HandleLeftScore()
    {
        test.backgroundColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        scoreLeft += 1;
        ballPrefab.gameObject.SetActive(false);
        //Destroy(destroyed);
        if (scoreLeft >= 3)
        {
            HandleWinLeft();
            return;
        }
        _scoredLeft = true;
    }

    private void HandleWinLeft()
    {
        endText.gameObject.SetActive(true);
        var materialWin = paddleLeft.GetComponent<Renderer>();
        materialWin.material.color = Color.green;
        var materialLose = paddleRight.GetComponent<Renderer>();
        materialLose.material.color = Color.red;
    }

    public void HandleRightScore()
    {
        test.backgroundColor = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
        scoreRight += 1;
        ballPrefab.gameObject.SetActive(false);
        //Destroy(destroyed);
        if (scoreRight >= 3)
        {
            HandleWinRight();
            return;
        }
        _scoredRight = true;
    }

    private void HandleWinRight()
    {
        endText.gameObject.SetActive(true);
        var materialWin = paddleRight.GetComponent<Renderer>();
        materialWin.material.color = Color.green;
        var materialLose = paddleLeft.GetComponent<Renderer>();
        materialLose.material.color = Color.red;
    }

    private void Restart()
    {
        if (scoreRight >= 3 || scoreLeft >= 3)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
