using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] private AdMobAdController adMobAdController;
    public GameObject square;

    private void Awake()
    {
        if (GameManager.gameManager == null)
        {
            GameManager.gameManager = this;
        }
        else
        {
            if (GameManager.gameManager != this)
            {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        StartCoroutine(StartGame());
    }

    private void Update()
    {
        if (square != null)
        {
            square.transform.Rotate(Vector3.forward * 10f);
        }
    }

    private IEnumerator StartGame()
    {
        
        this.adMobAdController.InitializeAdController();
        WaitUntil adsInitialization = new WaitUntil(() => !this.adMobAdController.masterAdControllerInitialization);
        yield return adsInitialization;

        Debug.Log("Admob Done");

        SceneManager.LoadScene("AdMob Test Scene");
    }

    public IAdContoller GetAdController()
    {
        return this.adMobAdController;
    }

}
