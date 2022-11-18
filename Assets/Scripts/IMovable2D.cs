using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable2D
{
    void Move(float direction);

    void Stop();

    void Jump();
}
