using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird: MonoBehaviour
{
    private Vector3 _initialPosition;
    [SerializeField] private float _launchPower = 500;
    private bool _wasBirdLaunched = false;
    private float _timeSettingAround;

    private void Awake()
    {
        _initialPosition = transform.position;
    }

    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        

        if (_wasBirdLaunched &&
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0)
        {
            _timeSettingAround += Time.deltaTime;
        }
        if (transform.position.y > 20 ||
            transform.position.y < -20 ||
            transform.position.x > 20 ||
            transform.position.x < -20 ||
            _timeSettingAround > 2)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

    }
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directiontoInitialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directiontoInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _wasBirdLaunched = true;
        GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y, 0);
    }
}
