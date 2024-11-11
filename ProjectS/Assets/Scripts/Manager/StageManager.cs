using System.Collections;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private Vector3 _startPos;
    [SerializeField] private int _currentEnemyCount = 0;
    [SerializeField] private int _currentStageEnemyTotalCount = 0;
    [SerializeField] private int _currentStageIndex = 0;
    [SerializeField] private float _enemySpawnInterval = 1;
    private WaitForSeconds _wait;
    
    private Coroutine _spawnCoroutine;
    
    private void StartStage()
    {
        _wait = new WaitForSeconds(_enemySpawnInterval);
        _spawnCoroutine = StartCoroutine(SpawnStage());
    }

    private IEnumerator SpawnStage()
    {
        int spawnedMonsterCount = 0;
        while (_currentStageEnemyTotalCount >= spawnedMonsterCount)
        {
            spawnedMonsterCount++;
            _currentEnemyCount++;
            SpawnManager.Instance.SpawnEnemy(-1,position:_startPos);
            yield return _wait;
        }
    }

    public void OnGUI()
    {
        if (GUI.Button(new Rect(20, 70, 300, 200), "StartStage"))
        {
            StartStage();
        }
        
    }
}

