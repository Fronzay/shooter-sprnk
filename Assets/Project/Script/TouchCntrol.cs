using UnityEngine;

public class TouchCntrol : MonoBehaviour
{
    public FixedTouchField touchField;
    public MobileCameraMove MobileCameraMove;

    private void Update()
    {
        MobileCameraMove.lockAxis = touchField.touchDist;
    }
}
