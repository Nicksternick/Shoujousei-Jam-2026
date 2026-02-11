using UnityEngine;

public class SceneChangeDataManager
{
    private static SceneChangeDataManager instance;
    private EnemyData enemyData;
    private Vector3 overWorldPlayerPosition;
    private bool miniBossCompelete = false;

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

    public bool MiniBossComplete
    {
        get { return miniBossCompelete; }
        set {  miniBossCompelete = value; }
    }
}
