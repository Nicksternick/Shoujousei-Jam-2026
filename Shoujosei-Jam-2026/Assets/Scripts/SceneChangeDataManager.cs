using UnityEngine;

public class SceneChangeDataManager
{
    private static SceneChangeDataManager instance;
    private EnemyData enemyData;
    private Vector3 overWorldPlayerPosition;

    public SceneChangeDataManager()
    {
        overWorldPlayerPosition = Vector3.zero;
    }

    public static SceneChangeDataManager Instance
    {
        get 
        { 
            if (instance == null)
            {
                instance = new SceneChangeDataManager();    
            }
            return instance; 
        }
    }

    public EnemyData EnemyData
    {
        get { return enemyData; }
        set { enemyData = value;}
    }

    public Vector3 OverWorldPlayerPosition
    {
        get { return overWorldPlayerPosition; }
        set { overWorldPlayerPosition = value; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //DontDestroyOnLoad(instance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
