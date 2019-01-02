using UnityEngine;

public class BlockHit : MonoBehaviour
{
    //オブジェクトと接触した瞬間に呼び出される
    void OnTriggerEnter(Collider other)
    {
        HitSound.main.PlaySound(0);
        //攻撃した相手がEnemyの場合
        if (other.CompareTag("Block"))
        {

            Destroy(other.gameObject);

        }
    }
}
