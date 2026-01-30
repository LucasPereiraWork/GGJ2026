using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private List<GameObject> _panelsList = new();

    private MenusBaseState _menusBaseState = null;
    InputAction esc;


    private GameObject _currentMenu;
    private GameObject _previousMenu;



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

    private void Start()
    {
        ShowPanelEnum(menusState.MAINMENU);
    }

    public enum menusState
    {
        MAINMENU,
        PAUSEMENU,
        HUD,
        OPTIONSPAUSE,
        OPTIONSMAINMENU,
        AREYOUSUREPAUSE,
        AREYOUSUREEXIT,
        CREDITSMENU,
        NONE
    }

    private menusState menuState;
    public GameObject CurrentMenu { get => _currentMenu; set => _currentMenu = value; }
    public GameObject PreviousMenu { get => _previousMenu; set => _previousMenu = value; }
    public menusState MenuState => menuState;
    public List<GameObject> PanelsList => _panelsList;

    public void ShowPanelString(string name)
    {
        ShowPanelEnum(Enum.Parse<menusState>(name));
    }

    public void ShowPanelEnum(menusState menusState)
    {
        _menusBaseState = null;
        switch (menusState)
        {
            case menusState.NONE:
                _menusBaseState = new MenuNone();
                break;
            case menusState.MAINMENU:
                _menusBaseState = new MainMenu();
                break;
            case menusState.PAUSEMENU:
                _menusBaseState = new PauseMenu();
                break;
            case menusState.HUD:
                _menusBaseState = new Hud();
                break;
            case menusState.OPTIONSPAUSE:
                _menusBaseState = new OptionsPauseMenu();
                break;
            case menusState.OPTIONSMAINMENU:
                _menusBaseState = new OptionsMainMenu();
                break;
            case menusState.AREYOUSUREPAUSE:
                _menusBaseState = new AreYouSurePause();
                break;
            case menusState.AREYOUSUREEXIT:
                _menusBaseState = new AreYouSureExit();
                break;
            case menusState.CREDITSMENU:
                _menusBaseState = new MenuCredits();
                break;
            default:
                Debug.LogError("No menu by that ID");
                break;
        }
        menuState = menusState;
        _menusBaseState.BeginState(this);
    }

    public void UpdateState()
    {
        _menusBaseState.UpdateState();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenLink(int index)
    {
    }
}
