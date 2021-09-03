using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerAnimator _playerAnimator;
        [SerializeField] private Tilemap groundTilemap;
        [SerializeField] private Tilemap collisionTilemap;
        private InputMaster _controls;
        private static readonly float MoveTime = 0.5f;


        public void Start()
        {
            _controls.Player.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
        }

        private void Move(Vector2 direction)
        {
            _playerAnimator.PlayMoveAnim(direction);
            Vector2 endPos = (Vector2) transform.position + direction;
            if (direction.SqrMagnitude() > 1)
                DoMove(endPos, MoveTime * 2, true);
            else
                DoMove(endPos, MoveTime, false);

            // if (CanMove(direction))
            // {
            // }
        }

        private bool CanMove(Vector2 direction)
        {
            Vector3Int gridPos = groundTilemap.WorldToCell(transform.position + (Vector3) direction);
            return groundTilemap.HasTile(gridPos) && !collisionTilemap.HasTile(gridPos);
        }

        private void Awake()
        {
            _controls = new InputMaster();
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        private void DoMove(Vector2 endValue, float duration, bool overshoot)
        {
            transform.DOMoveX(endValue.x, duration);
            if (overshoot) return;
            transform.DOMoveY(endValue.y, duration);
        }
    }
}