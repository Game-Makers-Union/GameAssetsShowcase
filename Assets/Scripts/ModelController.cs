using System.Collections;
using UnityEngine;
using TMPro;

public class ModelController : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private Canvas ui;

    [Header("Drop your model here!")]
    [SerializeField] private GameObject model;

    private bool uiEnabled = true;

    private void Start()
    {
        Instantiate(model, Vector3.zero, Quaternion.identity).transform.parent = transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ToggleUI();
    }

    public void ToggleUI()
    {
        ui.gameObject.SetActive(!uiEnabled);
        uiEnabled = !uiEnabled;
    }

    public void TakeScreenshot()
    {
        string modelName = nameText.text;
        ui.gameObject.SetActive(false);
        ScreenCapture.CaptureScreenshot("Screenshots/" + modelName + ".png");
        StartCoroutine(ActivateUI());
    }

    private IEnumerator ActivateUI()
    {
        yield return new WaitForSeconds(0.5f);
        ui.gameObject.SetActive(true);
    }
}
