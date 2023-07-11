using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyMinigame : Minigame
{
    [System.Serializable]
    public struct KeyStruct {
        public Texture2D key;
        public Texture2D shadow;
    }

    public KeyStruct[] keyImages;
    public GameObject keyPrefab;
    public GameObject keyParent;
    public GameObject interactedKeys;

    public GameObject keyLeftBoundSpawn;
    public GameObject keyRightBoundSpawn;
    public GameObject keyBottomBoundSpawn;
    public GameObject keyShadowSpawn;

    public int shadowId;

    protected override void OnMinigameStart()
    {
        generateKeyPrefabs();
        findRandomShadow();
    }

    private void findRandomShadow() {
        int shadowId = Random.Range(0, keyImages.Length);
        this.shadowId = shadowId;
        RawImage shadowImage = keyShadowSpawn.GetComponent<RawImage>();
        shadowImage.texture = keyImages[shadowId].shadow;
        DropArea dropArea = keyShadowSpawn.GetComponent<DropArea>();
    }

    private void generateKeyPrefabs() {
        int[][] angleRanges = new int[2][];
        angleRanges[0] = new int[] {-45, 45};
        angleRanges[1] = new int[] {135, 225};

        float leftSpawnBound = keyLeftBoundSpawn.transform.localPosition.x;
        float rightSpawnBound = keyRightBoundSpawn.transform.localPosition.x;
        float bottomSpawnBound = keyBottomBoundSpawn.transform.localPosition.y;

        for(int i = 0; i < keyImages.Length; i++) {
            GameObject keyObject = Instantiate(keyPrefab, keyParent.transform);

            // rotate
            keyObject.transform.Rotate(new Vector3(0, 0, 90));
            applyRandomRotation(keyObject, angleRanges);

            // move to
            float xPosition = Random.Range(leftSpawnBound, rightSpawnBound);
            float coefficient = bottomSpawnBound / (leftSpawnBound * rightSpawnBound);
            float yPosition = coefficient * (xPosition + leftSpawnBound) * (xPosition + rightSpawnBound);
            keyObject.transform.localPosition = new Vector3(xPosition, yPosition, 0);

            RawImage image = keyObject.GetComponent<RawImage>();
            image.texture = keyImages[i].key;

            keyObject.GetComponent<RectTransform>().sizeDelta = new Vector2(image.texture.width, image.texture.height);
            
            KeyObject key = keyObject.GetComponent<KeyObject>();
            key.setKeyId(i);
        }
    }

    private void applyRandomRotation(GameObject obj, int[][] ranges) {
        int[] angles = new int[ranges.Length];
        for(int i = 0; i < ranges.Length; i++) {
            int[] range = ranges[i];
            int angle = Random.Range(range[0], range[1]);
            angles[i] = angle;
        }
        int randomAngle = angles[Random.Range(0, angles.Length)];
        obj.transform.Rotate(new Vector3(0, 0, randomAngle));
    }
}
