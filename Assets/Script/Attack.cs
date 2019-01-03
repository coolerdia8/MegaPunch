using UnityEngine;
//using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//クラス名の上に追加してください


public class Attack : MonoBehaviour
{
    string sceneName;
    public float PunchPower = 0f;
    public bool PunchPowerFlag = false;
    float punchbreakValue = 70f;

    //外部読み出し用
    public static Attack main;

    // PowerMeterオブジェクトへの参照
    [SerializeField]
    GameObject powerMeterObject;

    // Sliderコンポーネントへの参照
    public Slider powerMeterSlider;

    // メーターの速さ
    [SerializeField]
    float meterSpeed = 0.2f;

    // メーターが最大値になった時のディレイ
    [SerializeField]
    float delayTime = 0.08f;
    float waitTime = 0f;

    // メーターが増加中か減少中か(trueで増加中)
    bool isMeterIncreasing = true;

    // 加える力の大きさ
    float forceMagnitude = 0f;

    //PlayerのAnimatorコンポーネント保存用
    private Animator animator;

    //左手のコライダー
    private Collider LhandCollider;
    //右手のコライダー
    private Collider RhandCollider;
    //右足のコライダー
    private Collider footCollider;

    // Use this for initialization
    void Start()
    {
        main = this;
        sceneName = SceneManager.GetActiveScene().name;
        //PlayerのAnimatorコンポーネントを取得する
        animator = GetComponent<Animator>();

        powerMeterSlider = powerMeterObject.GetComponent<Slider>();

        //左手のコライダーを取得
        LhandCollider = GameObject.Find("Character1_LeftHand").GetComponent<SphereCollider>();
        //右手のコライダーを取得
        RhandCollider = GameObject.Find("Character1_RightHand").GetComponent<SphereCollider>();
        //右足のコライダーを取得
        footCollider = GameObject.Find("Character1_RightToeBase").GetComponent<SphereCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        // powerMeterを動かす
        MovePowerMeter();
    }

    public bool BlockWarijudge()
    {
        if (PunchPower >= punchbreakValue)
        {
            PunchPowerFlag = true;
        }
        return PunchPowerFlag;
    }

    void MovePowerMeter()
    {
        // 飛行中フラグがfalseの時にメーターを上下させる
        //if (isFlying)
        //{
        //    return;
        //}

        // 境界値の定義
        float boundaryValue = 0f;

        // PunchPowerにmeterSpeedの値を加えていってメーターを上下させる
        if (isMeterIncreasing)
        {
            powerMeterSlider.value += meterSpeed;
            boundaryValue = powerMeterSlider.maxValue;
        }
        else
        {
            powerMeterSlider.value -= meterSpeed;
            boundaryValue = powerMeterSlider.minValue;
        }

        // 境界値になったら少し止めた後にメーターを逆向きに動かす
        if (Mathf.Approximately(powerMeterSlider.value, boundaryValue))
        {
            WaitAtBoundaryValue();
        }

        // スライダーの現在値をforceMagnitudeに格納
        forceMagnitude = powerMeterSlider.value;
    }

    void WaitAtBoundaryValue()
    {
        // 前のフレームが呼ばれて、処理が完了するまでにかかった時間を加算
        waitTime += Time.deltaTime;

        // waitTimeがdelayTimeを超えたら増加フラグの反転
        if (waitTime >= delayTime)
        {
            isMeterIncreasing = !isMeterIncreasing;
            waitTime = 0f;
        }
    }

    public void OnPressedMegaPunchButton()
    {
        PunchPower = forceMagnitude;
        EarthWari();
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void EarthWari()
    {
        animator.SetBool("Land", true);
        //右手コライダーをオンにする
        RhandCollider.enabled = true;

        //一定時間後にコライダーの機能をオフにする
        Invoke("ColliderReset", 1.5f);
    }

    private void ColliderReset()
    {
        LhandCollider.enabled = false;
        RhandCollider.enabled = false;
        footCollider.enabled = false;
    }
}