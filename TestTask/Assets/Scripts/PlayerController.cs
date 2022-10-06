using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private Line linePrefab;
    [SerializeField] private ParticleSystem loseParticle;
    private Line currentLine;
    private GameController gameController;
    public const float RESOLUTION = 0.3f;

    void Update()
    {
        if (Input.touchCount > 0 && !losePanel.activeSelf && !winPanel.activeSelf)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;

            transform.position = touchPosition;
        }


        if (Input.GetMouseButtonDown(0) && !losePanel.activeSelf && !winPanel.activeSelf)
        {
            currentLine = Instantiate(linePrefab, transform.position, Quaternion.identity);
        }

        if (Input.GetMouseButton(0) && !losePanel.activeSelf && !winPanel.activeSelf)
        {
            currentLine.SetPosition(transform.position);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            GameController.score++;
        }

        if (other.gameObject.tag == "Spike")
        {
            loseParticle.Play();
            Destroy(gameObject);
            StartCoroutine(Example());
        }
    }

    IEnumerator Example()
    {
        losePanel.SetActive(true);
        yield return new WaitForSeconds(2);
    }
}
