using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class InputController : MonoBehaviour
    {
        private InputContext _inputContext;
        private float _time;
        private float _offsetX;
        private float _offsetY;
        private Vector2 _clickPos;
        // Use this for initialization
        void Start()
        {
            _inputContext = Contexts.sharedInstance.input;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100);

                if (hit.collider != null)
                {
                    _clickPos = hit.transform.position;
                    _inputContext.ReplaceGameClick((int)_clickPos.x, (int)_clickPos.y);
                }

                _time = 0;
                _offsetX = 0;
                _offsetY = 0;
            }

            if (Input.GetMouseButton(0))
            {
                if (_time < 0.5f)
                {
                    _time += Time.deltaTime;
                    _offsetX += Input.GetAxis("Mouse X");
                    _offsetY += Input.GetAxis("Mouse Y");
                }
                else
                {
                    Slide();
                }
            }

            if (Input.GetMouseButtonUp(0) && _time < 0.5f && _time > 0.2f)
            {
                Slide();
            }
        }

        private void Slide()
        {
            SlideDirection direction = Mathf.Abs(_offsetX) > Mathf.Abs(_offsetY)
                ? _offsetX > 0 ? SlideDirection.RIGHT : SlideDirection.LEFT
                : _offsetY > 0 ? SlideDirection.UP : SlideDirection.DOWN;

            _inputContext.ReplaceGameSlide(new CustomVector2((int)_clickPos.x, (int)_clickPos.y), direction);
        }
    }


}
