using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Levels;
    [SerializeField] private FailedScreen failedScreen;
    //[SerializeField] private 
    // Start is called before the first frame update
    void Start()
    {
        EventManager.OnBallFallenIntoBasket += BallGotIntoBasket;
    }

    public void ShowFailedScreen()
    {
        failedScreen.StartShowScreen();
    }
    public void ShowPauseScreen()
    {

    }
    public void ShowMainScreen()
    {

    }
    public static void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
    void BallGotIntoBasket(bool NewBasket, Basket basket)
    {
        if (NewBasket)
        {
            Vector3 newPos = new Vector3(basket.GetParent().position.x * -1, basket.GetParent().position.y + 1.5f, -0.2f); ;
            newPos.x += Random.Range(-0.1f,0.1f);
            newPos.x = Mathf.Clamp(newPos.x, -1.6f,1.6f);
            newPos.y += Random.Range(0, 1.5f);
            Vector3 newAngle = basket.GetParent().eulerAngles;
            if (newPos.x > 0)
            {
                newAngle.z = Random.Range(0, 40f);
            }
            else
            {
                newAngle.z = Random.Range(-40f, 0);
            }
            
            Instantiate(Levels[0], newPos, Quaternion.Euler(newAngle));
        }
    }
    private void OnDisable()
    {
        EventManager.OnBallFallenIntoBasket -= BallGotIntoBasket;
    }
}
