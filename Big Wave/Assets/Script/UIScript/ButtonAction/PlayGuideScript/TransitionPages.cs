using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionPages : MonoBehaviour
{
    private List<Image> images;
    private int currentIndex;

    public void SetImages(List<Image> imagesList, int index)//�摜�̃Z�b�g
    {
        images = imagesList;
        currentIndex = index;
    }

    public void ShowImage(int index)//�摜�̕\��
    {
        if (images == null || index < 0 || index >= images.Count) return;
        images[index].gameObject.SetActive(true);
    }

    public void HideImage(int index)//�摜���B��
    {
        if (images == null || index < 0 || index >= images.Count) return;
        images[index].gameObject.SetActive(false);
    }

    public void SetNextImage()//���X�g���̎��̉摜��������
    {
        if (images == null || images.Count == 0) return;

        images[currentIndex].gameObject.SetActive(false);
        currentIndex = (currentIndex + 1) % images.Count;
        images[currentIndex].gameObject.SetActive(true);
    }

    public void SetPreviousImage()//���X�g���̑O�̉摜��������
    {
        if (images == null || images.Count == 0) return;

        images[currentIndex].gameObject.SetActive(false);
        currentIndex = (currentIndex - 1 + images.Count) % images.Count;
        images[currentIndex].gameObject.SetActive(true);
    }
}
