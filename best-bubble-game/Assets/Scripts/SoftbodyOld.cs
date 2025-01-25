using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class Softbody
{
    #region Constants
    private const float splineOffset = 0.5f;
    #endregion

    #region Fields
    [SerializeField]
    public SpriteShapeController spriteShape;

    [SerializeField]
    public Transform[] points;
    #endregion

    #region MonoBehaviour Callbacks
    private void Awake() 
    {
        UpdateVertices();
    }

    private void Update()
    {
        UpdateVertices();
    }
    #endregion

    #region privateMethods

    private void UpdateVertices()
    {
        for(int i = 0; i < points.Length - 1; i++) 
        {
            Vector2 _vertex = points[i].localPosition;
            Vector2 _towardsCenter = (Vector2.zero - _vertex).normalized;

            float _colliderRadius = points[i].gameObject.GetComponent<CircleCollider2D>().radius;
            try 
            {
                spriteShape.spline.SetPosition(i, (_vertex - _towardsCenter * _colliderRadius));
            }
            catch
            {
                Debug.Log("Spline points are too close. Recalculate");
                spriteShape.spline.SetPosition(i, (_vertex - _towardsCenter * (_colliderRadius + splineOffset)));
            }
            
        }
    }
    #endregion
}
