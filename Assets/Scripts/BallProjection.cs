using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallProjection : MonoBehaviour
{
    private Scene simulationScene;
    private PhysicsScene2D physicsScene;
    [SerializeField] private int physicsFramesToCalculate;
    [SerializeField] private float maxScale, minScale;
    [SerializeField] private Transform obstaclesParent;
     private Ball ballCloned;
    [SerializeField] private GameObject ballGameObject;

    [SerializeField] private GameObject PointPrefab;
    List<Transform> PointsToShow = new List<Transform>();
    List<Vector3> AllPoses = new List<Vector3>();

    private void Awake()
    {
        for (int i = 0; i < physicsFramesToCalculate; i++)
        {
            AllPoses.Add(Vector3.zero);
            PointsToShow.Add(Instantiate(PointPrefab.transform));
            PointsToShow[i].localScale *= Mathf.Lerp(minScale,maxScale,(physicsFramesToCalculate-i) / (float)physicsFramesToCalculate);
        }
    }
    void Start()
    {
        CreatePhysicsScen();
    }
    private void Update()
    {
        for (int i = 0; i < physicsFramesToCalculate; i++)
        {
            //Debug.Log(AllPoses[i]);
            float speedForMove = Time.deltaTime * Vector3.Distance(PointsToShow[i].position, AllPoses[i]);
            speedForMove = Mathf.Min(1, speedForMove);
            speedForMove *= 10;
            PointsToShow[i].position = Vector3.MoveTowards(PointsToShow[i].position,AllPoses[i], speedForMove); 
        }
    }
    void CreatePhysicsScen()
    {
        simulationScene = SceneManager.CreateScene("Simulation", new CreateSceneParameters(LocalPhysicsMode.Physics2D));
        physicsScene = simulationScene.GetPhysicsScene2D();

        SceneManager.MoveGameObjectToScene(Instantiate(obstaclesParent.gameObject),simulationScene);
        GameObject ballGameobjectCloned = Instantiate(ballGameObject);
        ballCloned = ballGameobjectCloned.GetComponent<Ball>();
        ballCloned.PrepareToPhysicsScene();
        SceneManager.MoveGameObjectToScene(ballGameobjectCloned, simulationScene);
    }

    public void CalculateProjection(Vector3 pos, Vector3 force)
    {
        ballCloned.Jump(pos, force);
        for (int i = 0; i < physicsFramesToCalculate; i++)
        {
            physicsScene.Simulate(Time.fixedDeltaTime*2);
            physicsScene.Simulate(Time.fixedDeltaTime * 2);
            AllPoses[i] = ballCloned.GetPos();

        }
        ballCloned.DisablePhysics();
    }
    public void StopCalculating()
    {
        if(enabled == true)
        {
            enabled = false;
            for (int i = 0; i < physicsFramesToCalculate; i++)
            {
                PointsToShow[i].gameObject.SetActive(false);
            }
        }
        
    }
    public void ContinueCalculating()
    {
        if (enabled == false)
        {
            enabled = true;
            for (int i = 0; i < physicsFramesToCalculate; i++)
            {
                PointsToShow[i].gameObject.SetActive(true);
            }
            SetAllPointsToStart();
        }
    }
    void SetAllPointsToStart()
    {
        for (int i = 0; i < physicsFramesToCalculate; i++)
        {
            PointsToShow[i].position = AllPoses[i];
        }
    }
}
