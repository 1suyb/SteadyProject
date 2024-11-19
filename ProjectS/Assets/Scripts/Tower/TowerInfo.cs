using UnityEngine;

[CreateAssetMenu(fileName = "TowerInfo", menuName = "ScriptableObjects/TowerInfo")]
public class TowerInfo : ScriptableObject
{
    public int ID;
    public int ProjectileID;
    public string Name;
    public string Description;
    public float DetectRange;
    public int MultiShoot;
    public float ShootIntervalTime;
    public int MaxUpgrade;
}