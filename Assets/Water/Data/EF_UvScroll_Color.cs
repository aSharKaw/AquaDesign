using UnityEngine;
using System.Collections;


[ExecuteInEditMode]
public class EF_UvScroll_Color : MonoBehaviour {


    ///// <summary>
    ///// 作成者：阿部慶照（ねこかつ）
    ///// 作成日：2017/02/24
    /////
    ///// 使用用途
    ///// ・UVオートスクロール対応
    ///// ・UVタイリング対応
    ///// ・カラー変更対応
    ///// ・UVアニメーション対応
    ///// ・メッシュアニメーション対応
    ///// （アニメーションを使用して制作できます。）
    ///// </summary>

    ////タイリング
    //public Vector2 Tiling = new Vector2(1, 1);

    ////スクロールスピード
    //public Vector2 OffSet = new Vector2(0, 0);
    //public Vector2 AutoScrollSpeed = new Vector2(1, 1);

    ////スクロールスピード定義
    //private Vector2 _AutoScrollSpeed = new Vector2(0, 0);

    ////オートスクロールフラグ
    //public bool AutoUvScroll = true;

    ////カラー
    //public Color color;

    ////エミッションカラー
    //public Color EmissionColor;

    ////歪み数値定義
    //[SerializeField,Range(0,1)]
    //public float HeatTime = 0;
    //[SerializeField, Range(0,4)]
    //public float HeatForce = 0;

    ////レンダー定義
    //private Renderer rend;

    ////オフセット定義
    //float offsetX = 0;
    //float offsetY = 0;



    //起動時
    void Start()
    {
        ////レンダー拾得
        //rend = GetComponent<Renderer>();

        ////オフセット設定
        //rend.sharedMaterial.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));

        ////タイリング設定
        //rend.sharedMaterial.SetTextureScale("_MainTex", new Vector2(Tiling.x, Tiling.y));

        ////色変更設定
        //rend.sharedMaterial.SetColor("_TintColor", color);
        //rend.sharedMaterial.SetColor("_Color", color);
        //rend.sharedMaterial.SetColor("_EmissionColor", EmissionColor);

        ////歪み量設定
        //rend.sharedMaterial.SetFloat("_HeatTime", HeatTime);
        //rend.sharedMaterial.SetFloat("_HeatForce", HeatForce);

    }

    //50FPS固定アップデート
    void FixedUpdate()
    {


        ////UVスクロール
        //if (AutoUvScroll == true)
        //{
        //    //UVオートスクロール
        //    _AutoScrollSpeed.x = Time.fixedDeltaTime * AutoScrollSpeed.x;
        //    _AutoScrollSpeed.y = Time.fixedDeltaTime * AutoScrollSpeed.y;

        //    offsetX += _AutoScrollSpeed.x;
        //    offsetY += _AutoScrollSpeed.y;


        //}
        //else
        //{
        //    //オフセットアニメーション
        //    offsetX = OffSet.x;
        //    offsetY = OffSet.y;

        //}

        ////オフセット設定
        //rend.material.SetTextureOffset( "_MainTex", new Vector2( offsetX, offsetY ) );

        ////タイリング設定
        //rend.material.SetTextureScale( "_MainTex", new Vector2( Tiling.x, Tiling.y ) );

        ////色変更設定
        //rend.material.SetColor( "_TintColor", color );
        //rend.material.SetColor( "_Color", color );
        //rend.material.SetColor( "_EmissionColor", EmissionColor );

        ////歪み量設定
        //rend.material.SetFloat( "_HeatTime", HeatTime );
        //rend.material.SetFloat( "_HeatForce", HeatForce );

    }


    void OnValidate()
    {
        ////オフセット設定
        //rend.sharedMaterial.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));

        ////タイリング設定
        //rend.sharedMaterial.SetTextureScale("_MainTex", new Vector2(Tiling.x, Tiling.y));

        ////色変更設定
        //rend.sharedMaterial.SetColor("_TintColor", color);
        //rend.sharedMaterial.SetColor("_Color", color);
        //rend.sharedMaterial.SetColor("_EmissionColor", EmissionColor);

        ////歪み量設定
        //rend.sharedMaterial.SetFloat("_HeatTime", HeatTime);
        //rend.sharedMaterial.SetFloat("_HeatForce", HeatForce);
    }



}