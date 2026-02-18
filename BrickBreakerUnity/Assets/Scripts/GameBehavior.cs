using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    [SerializeField] private GameObject _ballPrefab;

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
        ServeBall();
    }

    private void ServeBall()
    {
        Instantiate(_ballPrefab, Vector3.zero, Quaternion.identity);
    }
      public void Score()
    {
         Invoke(nameof(ServeBall), 2.0f);
    }

    
}
