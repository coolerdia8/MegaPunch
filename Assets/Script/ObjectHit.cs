using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    Attack _Attack;
    //オブジェクトと接触した瞬間に呼び出される
    void OnTriggerEnter(Collider other)
    {
        //攻撃した相手がBlockの場合
        if (other.CompareTag("Block"))
        {
            if(_Attack.BlockWarijudge() == false) { return; }

            HitSound.main.PlaySound(0);
            Destroy(other.gameObject);

        }
    }
}
