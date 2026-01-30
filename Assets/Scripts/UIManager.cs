using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private List<GameObject> _menusList = new();

    private Dictionary<string, GameObject> _menusDictionary = new();


    private GameObject _currentMenu;
    public GameObject CurrentMenu => _currentMenu;



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
        PrepDictionaries();
    }

    private void PrepDictionaries()
    {
        foreach (var menu in _menusList)
        {
            _menusDictionary.Add(menu.gameObject.name, menu);
        }
    }

    private void Start()
    {

    }

    public void ShowPanel(string name)
    {
        _currentMenu.SetActive(false);
        if (_menusDictionary.TryGetValue(name, out var menu))
        {
            _currentMenu = menu;
            if (_currentMenu) _currentMenu.SetActive(true);
        }
    }

    public void UpdateState()
    {
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenLink(int index)
    {
    }
}
