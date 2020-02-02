using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface MouseFocusReceiver
{
    void onMouseFocusGained();
    void onMouseFocusLost();
    void onClick();

    void onDrag(Vector3 newMousePos, bool isDragStart);
}
