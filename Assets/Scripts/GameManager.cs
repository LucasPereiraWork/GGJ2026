using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private UnityEvent onCoins;
    [SerializeField] private UnityEvent onLevelReset;

    [Header("GameObjects")]

    [Header("LevelManagement")]
    private int _currentLevel;

    private GameObject _currentSpawnPoint;
    private GameObject interactable;


    public static GameManager Instance { get; private set; }
    public bool IsPaused { get; private set; } = false;

    public int CurrentLevel => _currentLevel;
    public GameObject CurrentSpawnPoint { get => _currentSpawnPoint; set => _currentSpawnPoint = value; }
    public GameObject Interactable => interactable;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadLevel(int index)
    {
        _currentLevel = index;
        StartCoroutine(LoadLevelAsyc(_currentLevel));
    }

    public void PauseGame(bool value)
    {
        IsPaused = value;
        Time.timeScale = IsPaused ? 0.0f : 1.0f;
    }


    private IEnumerator LoadLevelAsyc(int level)
    {
        if (IsPaused)
        {
            Time.timeScale = 1.0f;
        }
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(level);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        if (_currentLevel == 0)
        {
            //AudioManager.Instance.PlayMusic(0);
        }
        else
        {
            //AudioManager.Instance.PlayMusic(1);
        }
    }

    public void LevelReset()
    {
    }

    public void RegisterInteractable(GameObject envInteractable)
    {
        interactable = envInteractable;
    }
}
