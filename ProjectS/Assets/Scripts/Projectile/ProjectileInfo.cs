using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "Projectile")]
public class ProjectileInfo : ScriptableObject
{
    public int ID;
    public float AttackDamage;
    public string PrefabPath;
    public float Speed;
    // 디버프가 있다면 디버프 테이블의 id
    // 발사시 날아가는 형태가 따로 구현된다면 그것에 대한 정보..

}
