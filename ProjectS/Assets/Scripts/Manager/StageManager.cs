using System.Collections;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private Vector3 _startPos;
    [SerializeField] private int _currentEnemyCount = 0;
    [SerializeField] private int _currentStageEnemyTotalCount = 0;
    [SerializeField] private int _currentStageIndex = 0;
    [SerializeField] private float _enemySpawnInterval = 1;
    [SerializeField] private int _clearThresholdFailCount = 1;
    private int _failCount = 0;

    public int CurrentEnemyCount
    {
        get => _currentEnemyCount;
        private set
        {
            _currentEnemyCount = value;
            if (_currentEnemyCount == 0)
            {
                EndStage();
            }
        }
    }

    public int FailCount
    {
        get => _failCount;
        private set
        {
            _failCount = value;
        }
    }
    
    
    private WaitForSeconds _wait;
    private Coroutine _spawnCoroutine;
    
    private void StartStage()
    {
        _failCount = 0;
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
            SpawnManager.Instance.SpawnEnemy(-1,position:_startPos).GetComponent<Enemy>().SetStageManager(this);
            yield return _wait;
        }
    }

    private void EndStage()
    {
        Debug.Log("끗");
        if (_failCount > _clearThresholdFailCount)
        {
            Debug.Log("스테이지 실패");
        }
        else
        {
            Debug.Log("스테이지 성공");
        }
    }
    public void AddFailCount()
    {
        _failCount++;
    }

    public void DiscountCurrentEnemyCount()
    {
        CurrentEnemyCount--;
    }
    
    public void OnGUI()
    {
        if (GUI.Button(new Rect(20, 70, 300, 200), "StartStage"))
        {
            StartStage();
        }
        
    }
}

