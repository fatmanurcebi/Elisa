using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class CameraPositionSetter : MonoBehaviour
{
    public Transform mainCamera; // Ana kamera nesnesi
    public Vector3 targetPosition; // Ayarlanacak hedef konum
    public PlayableDirector director; // Timeline'� y�netmek i�in PlayableDirector

    private bool hasReachedTarget = false; // Kamera hedefe ula�t� m�?

    private void Start()
    {
        // PlayableDirector referans�n� al
        director = GetComponent<PlayableDirector>();

        if (director != null)
        {
            // Timeline'da Animation Track tamamland���nda olay� dinle
            director.stopped += OnTimelineStopped;
        }
        else
        {
            Debug.LogWarning("PlayableDirector component not found on this GameObject.");
        }
    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        // Timeline durdu�unda ve kamera hedefe ula�mad�ysa kamera konumunu ayarla
        if (!hasReachedTarget)
        {
            mainCamera.position = targetPosition;
            hasReachedTarget = true;
        }
    }

}
