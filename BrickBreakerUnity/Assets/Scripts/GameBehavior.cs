using UnityEngine;
using TMPro;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;
    

    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private TMP_Text _scoreUI;
    [SerializeField] private TMP_Text _pauseUI;

    private int _score;

    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            _scoreUI.text = "Score:" + _score.ToString();
        }
    }
    private Utilities.GameState _gameMode;
    public Utilities.GameState GameMode
    {
        get => _gameMode;
        set
        {
            _gameMode = value;
            _pauseUI.enabled = _gameMode == Utilities.GameState.Pause;
        }
    }
  private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        Score =0;
        GameMode=Utilities.GameState.Play;
        ServeBall();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameMode = GameMode == Utilities.GameState.Play
                ? Utilities.GameState.Pause
                : Utilities.GameState.Play;
        }
    }

    public void ServeBall()
    {
        Instantiate(_ballPrefab, Vector3.zero, Quaternion.identity);
    }
    
}
