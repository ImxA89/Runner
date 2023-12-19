using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(RawImage))]
public class BackGroundMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private RawImage _image;
    private float _imagePositionX;
    private float _imagePositionForReset = 1f;

    private void Start()
    {
        _image = GetComponent<RawImage>();
        _imagePositionX = _image.uvRect.x;
    }

    private void Update()
    {
        _imagePositionX += _speed * Time.deltaTime;
        _image.uvRect = new Rect(_imagePositionX, 0, _image.uvRect.width, _image.uvRect.height);

        if (_imagePositionX > _imagePositionForReset)
            _imagePositionX = 0f;

    }
}
