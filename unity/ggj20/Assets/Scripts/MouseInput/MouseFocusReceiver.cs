using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface MouseFocusReceiver
{
    void onDragStart();
    void onDragEnd();

    void onDrag(Vector3 newMousePos);
}
