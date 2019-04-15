public interface IThrowable
{
    void FirstFrameHold();
    void Holding(UnityEngine.Vector3 pickupPos);
    void Throw(UnityEngine.Vector3 dragDir, UnityEngine.Vector3 fwdDir);
}
