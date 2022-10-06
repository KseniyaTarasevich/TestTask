using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private int N;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject spike;
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;

    private float boundY = 3.5f;
    private float boundX = 2.2f;

    public static int score;

    void Start()
    {
        SpawnObjects();
    }

    void Update()
    {
        textScore.text = $"Score: {score}";

        if (score == N)
        {
            winPanel.SetActive(true);
            Destroy(player.gameObject);
        }
    }

    void SpawnObjects()
    {
        for (int i = 0; i < N; i++)
        {
            Instantiate(coin, new Vector3(Random.Range(-boundX, boundX), Random.Range(-boundY, boundY), 0), transform.rotation);
            Instantiate(spike, new Vector3(Random.Range(-boundX, boundX), Random.Range(-boundY, boundY), 0), Quaternion.Euler(0, 0, 90));
        }
    }

    public void LoadLevelAgain()
    {
        SceneManager.LoadScene("MainScene");
        score = 0;
    }

    public void Lose()
    {
        Invoke("LoadLevelAgain", 2f);
    }
}
