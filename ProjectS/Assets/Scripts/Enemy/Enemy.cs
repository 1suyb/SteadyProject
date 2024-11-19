using UnityEngine;

public class Enemy : MonoBehaviour,IDamagable,ILoadable
{
	[SerializeField] private EnemySO testSO;
	public EnemyStat Stat { get; private set; }
	private StageManager stageManager;

	private Transform nextPoint;
	private int index;
	private Vector3 direction;

	public void Init()
	{
		EnemyMovement movement = this.gameObject.AddUniqueComponent<EnemyMovement>();
	}


	public void SetStageManager(StageManager stageManager)
	{
		this.stageManager = stageManager;
	}

	public void Goal()
	{
		this.gameObject.SetActive(false);
		stageManager.AddFailCount();
	}

	public void Load(int id)
	{
		Init();	
		Stat = new EnemyStat(testSO.enemyData);
		Stat.OnDieEvent += Die;
	}

	private void Die()
	{
		this.gameObject.SetActive(false);
	}

	private void OnDisable()
	{
		stageManager.DiscountCurrentEnemyCount();
	}

	public void TakeDamage(float damage)
	{
		Stat.HP -=(int)( damage - Stat.CurrentStat.Ammor);
	}
}
