using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game settings")]
    [SerializeField] private int startingLives = 3;

    [Header("UI (Phase 7)")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private GameObject gameOverPanel;

    private int score;
    private int lives;

    // fem això perquè els altres scripts només o puguin llegir però no modificar aquest valor.
    public bool IsGameOver { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {

        score = 0;
        lives = startingLives;
        IsGameOver = false;
        gameOverPanel.SetActive(false);
        UpdateUI();
       

    }

    // Cridat pel Asteroid quan aquest és destruït.
    public void AddScore(int points)
    {
        // TODO: afegeix punts a la UI i actualitza-la.
        score += points;
        UpdateUI();
    }

    // Cridat pel Ateroid quan impacta amb el player.
    public void LoseLife(int amount)
    {
        // TODO: Resta amount a lives i actualitza la UI.
        //       si lives < 0 GameOver().
        //       Extra: si el joc ja ha terminat no facis res
        lives -= amount;
        UpdateUI();

        if (lives < 0)
        {
            GameOver();
        }

    }

    private void GameOver()
    {
        IsGameOver = true;
        Time.timeScale = 0;

    }

    // Assigna aquest mètode al Restart button: On Click () al Inspector.
    public void RestartGame()
    {
        // TODO:
        //     Time.timeScale = 1   (si no fas això reiniciarà congelat)
        //     fes un reload de l'escena:
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateUI()
    {
        livesText.text = $"Live : {lives}";
        scoreText.text = $"Score : {score}";
        // TODO: escriu les vides i els punts als textos.
        //   Exemple: scoreText.text = "Punts: " + score;
    }
}
