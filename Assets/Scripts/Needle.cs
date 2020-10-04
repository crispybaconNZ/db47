using UnityEngine;

public class Needle : MonoBehaviour {
    // [SerializeField] private float _needleRotSpeed = 0.05f;
    private float _currentPercent = 74f;
    [SerializeField] private float _targetPercent = 74f;
    private Transform _needle;

    private const float MAX_PERCENT_ANGLE = -180;
    private const float ZERO_PERCENT_ANGLE = 0;

    // Start is called before the first frame update
    void Awake() {
        _needle = transform;
        _currentPercent = 0f;
    }

    void Update() {
        _needle.eulerAngles = new Vector3(0, 0, GetPercentRotation());
        _currentPercent = _needle.eulerAngles.z / MAX_PERCENT_ANGLE;
    }   

    private float GetPercentRotation() {
        float totalAngleSize = ZERO_PERCENT_ANGLE - MAX_PERCENT_ANGLE;
        return ZERO_PERCENT_ANGLE - (_targetPercent / 100f) * totalAngleSize;
    }

    public void SetTargetPercent(float percent) => _targetPercent = Mathf.Clamp(percent, 0f, 100f);
}
