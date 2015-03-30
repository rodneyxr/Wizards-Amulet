using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Text txt_notification_top;
    public Text txt_notification_middle;
    public Text txt_notification_bottom;

    public static Text textNotificationTop;
    public static Text textNotificationMiddle;
    public static Text textNotificationBottom;

    void Start() {
        textNotificationTop = txt_notification_top;
        textNotificationMiddle = txt_notification_middle;
        textNotificationBottom = txt_notification_bottom;

        // clear all
        textNotificationTop.text = "";
        textNotificationMiddle.text = "";
        textNotificationBottom.text = "";
    }

}
