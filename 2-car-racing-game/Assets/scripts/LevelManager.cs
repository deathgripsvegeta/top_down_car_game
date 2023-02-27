using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public GameObject PausePanel;
    public GameObject GameoverPanel;
    public GameObject GameWonPanel;
    public TextMeshProUGUI CoinCountText;
    public TextMeshProUGUI GasCountText;
    public Slider GasMeterSlider;

    public TextMeshProUGUI CountdownText;
    private int _countdownTimer = 3;
    [SerializeField] private float _xRange = 13.59f;
    [SerializeField] public float propSpeed = 10;
    [SerializeField] private int _coinsCollected;
    [SerializeField] private int _gasAmount = 10;
    [SerializeField] private bool _isGameActive;
    [SerializeField] private int _currentGasAmount = 10;
   
    void Awake() 
    {
        Instance = this;
        Time.timeScale = 1;
        MoveProp();
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        CoinCountText.text = _coinsCollected.ToString();
        GasCountText.text = _gasAmount.ToString();
        SetGasFillAmount(_gasAmount);
        StartCoroutine(StartCountdownTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool StartGame()
    {
        //_isGameActive = true;
        return _isGameActive;
    }
    public void Gameover()
    {
        Time.timeScale = 0;
        GameoverPanel.SetActive(true);
    }
    public void GameWon()
    {
        Time.timeScale = 0;
        GameWonPanel.SetActive(true);
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Home()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Pause()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }
    public void Play()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }
    public void UpdateLevelCoinCount(int amount)
    {
        _coinsCollected += amount;
        CoinCountText.text = _coinsCollected.ToString();
    }
    public void SetMaxGasFillAmount(int amount)
    {
        GasMeterSlider.maxValue = amount;
        GasMeterSlider.value = amount;
    }
    public void SetGasFillAmount(int amount) // slider value
    {
        if(_currentGasAmount < _gasAmount)
        {
            _currentGasAmount += amount;
            GasMeterSlider.value = _currentGasAmount;
        }
    }

    public void UpdateGasAmount(int amount) // text value
    {
        if(_currentGasAmount < _gasAmount)
        { 
            _currentGasAmount += amount;
            GasCountText.text = _currentGasAmount.ToString();
        }
        
    }
    public void StartGasMeter()
    {
        StartCoroutine(UpdateGasMeter());
    }
    IEnumerator StartCountdownTimer()
    {
        yield return new WaitForSeconds(0.5f);
        CountdownText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        while(_countdownTimer > 0)
        {
            CountdownText.text = _countdownTimer.ToString();
            yield return new WaitForSeconds(1f);
            _countdownTimer--; //_countdownTimer = _countdownTimer - 1;
        }
        CountdownText.text = "GO!";
        _isGameActive = true;
        yield return new WaitForSeconds(1f);
        CountdownText.gameObject.SetActive(false);
    }
    IEnumerator UpdateGasMeter()
    {
        while(_currentGasAmount > 0)
        {
            yield return new WaitForSeconds(2f);
            _currentGasAmount--;
            GasCountText.text = _currentGasAmount.ToString();
            GasMeterSlider.value = _currentGasAmount;
        }
        Gameover();
    }
    public void MoveProp()
    {
        transform.Translate(Vector3.left * propSpeed * Time.deltaTime);
        if(transform.position.x < -_xRange)
        {
            transform.position = new Vector2(_xRange, 4.34f);
        }
        
        
    }
   
}

