using System.Collections.Generic;
using UnityEngine;

namespace GameJam.Interactables
{
    public class ItemsPool : MonoBehaviour
    {
        [SerializeField]
        private ItemConfig[] theItems;

        [SerializeField]
        private int numberOfItems;

        private Queue<GameObject> itemsQueue;
        public bool IsEmpty { get; private set; }

        private Vector3 initialAwayFromView = new Vector3(0f, -50f, 0f);

        void Start()
        {
            IsEmpty = false;
            itemsQueue = new Queue<GameObject>();
            for (int i = 0; i < numberOfItems; i++)
            {
                int rand = Random.Range(0, theItems.Length);
                var item = Instantiate(theItems[rand].ItemPrefab, transform);
                item.transform.localPosition = initialAwayFromView;
                item.gameObject.SetActive(false);
                itemsQueue.Enqueue(item);
            }
        }

        public GameObject GetItemFromPool()
        {
            var item = itemsQueue.Dequeue();
            itemsQueue.Enqueue(item);
            item.SetActive(true);
            item.transform.localPosition = initialAwayFromView;
            item.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
            return item ? item : null;
        }
    }
}