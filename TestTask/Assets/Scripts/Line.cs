using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField]
    private LineRenderer renderer;

    public void SetPosition(Vector2 pos)
    {
        if (!CanAppend(pos))
        {
            return;
        }
        renderer.positionCount++;
        renderer.SetPosition(renderer.positionCount - 1, pos);
    }

    private bool CanAppend(Vector2 pos)
    {
        if (renderer.positionCount == 0)
        {
            return true;
        }

        return Vector2.Distance(renderer.GetPosition(renderer.positionCount - 1), pos) > PlayerController.RESOLUTION;
    }
}
