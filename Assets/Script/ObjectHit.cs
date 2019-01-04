using UnityEngine;

//Character1_RightHand
public class ObjectHit : MonoBehaviour
{
    public GameObject prefab_hitEffect1;
    //オブジェクトと接触した瞬間に呼び出される
    void OnTriggerEnter(Collider other)
    {
        //攻撃した相手がBlockの場合
        if (other.CompareTag("Block"))
        {
            if(Attack.main.BlockWarijudge() == false) { return; }

            Instantiate(prefab_hitEffect1, other.transform.position, Quaternion.identity);
            HitSound.main.PlaySound(0);
            Destroy(other.gameObject);

        }
    }
}
