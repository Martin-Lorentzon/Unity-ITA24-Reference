using UnityEngine;

public class MaterialSwapper : MonoBehaviour
{
    public Material newMaterial;

    // Private Variables
    bool isNewMaterialActive = false;
    Material oldMaterial;

    void Start()
    {
        oldMaterial = GetComponent<MeshRenderer>().material;
    }

    public void SwapMaterials()
    {
        isNewMaterialActive = !isNewMaterialActive;

        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        if (isNewMaterialActive)
            meshRenderer.material = newMaterial;
        else
            meshRenderer.material = oldMaterial;
    }
}
