using System;
using UnityEngine;

[Serializable]
public class EnemyData 
{
	[field: SerializeField] public int HP { get; private set; }
	[field: SerializeField] public int Ammor { get; private set; }
	[field: SerializeField] public int Speed { get; private set; }

}
