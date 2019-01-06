using UnityEngine;

//Character1_RightHand
public class ObjectHit : MonoBehaviour
{
    //public static ObjectHit main;
    public GameObject prefab_hitEffect1 = null;
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
            //AutoDestoryPartcles.main.;

            //一定時間後にコライダーの機能をオフにする
            //Invoke("AutoDestroyInstant", 1.5f);

        }
    }
}
