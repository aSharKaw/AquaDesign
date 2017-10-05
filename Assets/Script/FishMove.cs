using AY_Util;
using UnityEngine;

/// <summary>
/// 魚の移動と、魚のアニメーション生魚を同時に制御している。
/// 二つを分離すればもっとシンプルにできる。
/// そのあと、移動はストラテジーかビヘイビアとして分離するべき。
/// </summary>
public class FishMove : MonoBehaviour
{
    /// <summary>
    /// 待機時間の最大？ さらにカウントを増やす処理が後ではいるので断言できない。
    /// </summary>
    private readonly float WAIT_MAX = 4.0f;

    /// <summary>
    /// 待機時間の最小？ さらにカウントを増やす処理が後ではいるので断言できない。
    /// </summary>
    private readonly float WAIT_MIN = 1.0f;

    /// <summary>
    /// 待機時間の係数。
    /// </summary>
    private readonly int WAIT_TIME = 60;

    /// <summary>
    /// アニメーションコンポーネントへのアクセス用変数
    /// </summary>
    private Animator _animation;

    /// <summary>
    /// アニメーション用に、生成されてからのフレームをかぞえている？
    /// </summary>
    private int _count = 0;

    /// <summary>
    /// たぶん床面？
    /// </summary>
    [SerializeField]
    private bool _ground;

    /// <summary>
    /// オブジェクトの移動速度
    /// サイズが小さいため移動速度は0.0001単位とすること。
    /// </summary>
    [SerializeField]
    private float _move_speed;

    /// <summary>
    /// 現在泳いでいるかどうかを判定
    /// </summary>
    private bool _swim_flug = false;

    /// <summary>
    /// 現在移動先として指定している場所
    /// </summary>
    private Vector3 _target_position;

    /// <summary>
    /// 待機時間のフレームをかぞえている。
    /// </summary>
    private int _wait_count = 0;

    /// <summary>
    /// 動く時の処理を行うための関数ポインター。
    /// 擬似的なストラテジーの実装に使っている。
    /// </summary>
    /// <param name="v">移動先の座標</param>
    /// <returns>移動を続けるか否か。続けるならtrueが返る。</returns>
    private delegate bool MoveFunc ( Vector3 v );

    /// <summary>
    /// 水槽内部のランダムな位置を返す
    /// </summary>
    /// <returns>ランダムな位置の座標</returns>
    private Vector3 GetRandomPosition ( )
    {
        GameObject water_pot = GameObject.Find( "WaterPot" );
        GameObject _water = water_pot.transform.FindChild( "Water" ).gameObject;
        Vector3 waterLocal = _water.transform.localScale;
        float bodyY = gameObject.transform.FindChild( "body" ).gameObject.transform.localScale.y;

        return new Vector3( RandUtil.Range( RandUtil.AbsNormal, waterLocal.x / 2 ),
            _ground ? waterLocal.y / 2 + bodyY : RandUtil.Range( RandUtil.AbsNormal, waterLocal.y / 2 ),
            RandUtil.Range( RandUtil.AbsNormal, waterLocal.z / 2 ) );
    }

    /// <summary>
    /// アイドリング時に呼び出される処理
    /// </summary>
    /// <returns></returns>
    private bool Idling ( )
    {
        if (_count > _wait_count * WAIT_TIME)
        {
            _count = 0;
            _wait_count = 0;
            return false;
        }
        if (_count <= 0) _wait_count = FloatUtil.Round( Random.Range( WAIT_MIN, WAIT_MAX ) );

        _count++;
        return true;
    }

    /// <summary>
    /// 床や水槽にめりこんでいたらソコでとまる処理。
    /// めり込んだ状態でランダムに行き先をもとめる。
    /// さきにレイなどを使って衝突地点をもとめておけば、当たらないで済む。
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter ( Collider other )
    {
        bool isHitWall = other.name == "FishTank" || other.name == "Floor";
        if (!isHitWall) return;
        _target_position = GetRandomPosition();
    }

    /// <summary>
    /// めり込みが解除された場合の処理。ランダムに行き先を求める。
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit ( Collider other )
    {
        bool inWater = other.name == "Water";
        if (!inWater) return;
        _target_position = GetRandomPosition();
    }

    /// <summary>
    /// 初期値の設定。
    /// </summary>
    private void Start ( )
    {
        _target_position = GetRandomPosition();
        GameObject child = transform.FindChild( "body" ).gameObject;
        _animation =  child.GetComponent<Animator>();
    }

    /// <summary>
    /// 泳いで移動する処理。
    /// アニメーションの制御もはいっている。
    /// アニメーションの制御部分を分離すればSwimMoveと同じ。
    /// </summary>
    /// <param name="target_position">目標地点</param>
    /// <returns>移動を続けるかどうか。続けるならtrue</returns>
    private bool AnimationSwimMove ( Vector3 target_position )
    {
        Vector3 moveTo = Vector3.MoveTowards( this.transform.position, target_position, _move_speed );
        bool isMoveEnd = target_position == moveTo;
        _animation.SetBool( "swimming", isMoveEnd == false );
        if (isMoveEnd) return false;

        this.transform.position = moveTo;
        this.transform.LookAt( target_position );
        return true;
    }

    /// <summary>
    /// 泳いで移動する処理。
    /// </summary>
    /// <param name="target_position">目標地点</param>
    /// <returns>移動を続けるかどうか。続けるならtrue</returns>
    private bool SwimMove ( Vector3 target_position )
    {
        Vector3 moveTo = Vector3.MoveTowards( this.transform.position, target_position, _move_speed );
        bool isMoveEnd = target_position == moveTo;
        if (isMoveEnd) return false;

        this.transform.position = moveTo;
        this.transform.LookAt( target_position );
        return true;
    }

    /// <summary>
    /// アニメーションの有無に合わせて移動の関数を呼び出している。
    /// </summary>
    private void Update ( )
    {
        MoveFunc useFunc = _animation == null ? (MoveFunc)SwimMove : (MoveFunc)AnimationSwimMove;

        if (_swim_flug)
        {
            // useFuncで二回カウントしているのは仕様ですか？
            useFunc( _target_position );
            if (useFunc( _target_position )) return;
            _swim_flug = false;
            return;
        }

        Idling();
        _target_position = GetRandomPosition();

        // idlingで二回カウントしているのは仕様ですか？
        if (!Idling()) return;
        _swim_flug = true;
    }
}
