using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    [SerializeField] private AudioManager audioManager;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        this.audioManager.Play();
    }
}