using Assets.Gamelogic.Utils;
using Improbable.Unity.Visualizer;
using Improbable;
using Improbable.Core;
using UnityEngine;

namespace Assets.Gamelogic.Core
{
    public class TransformSender : MonoBehaviour
    {
        [Require]
        private Position.Writer PositionWriter;
        [Require]
        private Rotation.Writer RotationWriter;

        private void Update()
        {
            var positionUpdate = new Position.Update();
            var rotationUpdate = new Rotation.Update();
            var newPosition = transform.position.ToCoordinates();
            var newRotation = transform.rotation;

            if (PositionNeedsUpdate(newPosition))
            {
                positionUpdate.SetCoords(newPosition);
                PositionWriter.Send(positionUpdate);
            }
            if (RotationNeedsUpdate(newRotation))
            {
                rotationUpdate.SetRotation(MathUtils.ToNativeQuaternion(transform.rotation));
                RotationWriter.Send(rotationUpdate);
            }
        }

        private bool PositionNeedsUpdate(Coordinates newPosition)
        {
            return !MathUtils.ApproximatelyEqual(newPosition.ToUnityVector(), PositionWriter.Data.coords.ToUnityVector());
        }

        private bool RotationNeedsUpdate(UnityEngine.Quaternion newRotation)
        {
            return !MathUtils.ApproximatelyEqual(newRotation, MathUtils.ToUnityQuaternion(RotationWriter.Data.rotation));
        }
    }
}