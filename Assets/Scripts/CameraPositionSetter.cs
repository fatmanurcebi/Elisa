using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class CameraPositionSetter : MonoBehaviour
{
    public Transform mainCamera; // Ana kamera nesnesi
    public Vector3 targetPosition; // Ayarlanacak hedef konum
    public PlayableDirector director; // Timeline'ý yönetmek için PlayableDirector

    private bool hasReachedTarget = false; // Kamera hedefe ulaþtý mý?

    private void Start()
    {
        // PlayableDirector referansýný al
        director = GetComponent<PlayableDirector>();

        if (director != null)
        {
            // Timeline'da Animation Track tamamlandýðýnda olayý dinle
            director.stopped += OnTimelineStopped;
        }
        else
        {
            Debug.LogWarning("PlayableDirector component not found on this GameObject.");
        }
    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        // Timeline durduðunda ve kamera hedefe ulaþmadýysa kamera konumunu ayarla
        if (!hasReachedTarget)
        {
            mainCamera.position = targetPosition;
            hasReachedTarget = true;
        }
    }

}
