﻿using UnityEngine;
using System.Collections;

namespace UnityEngine.UI
{
    [System.Serializable]
    public class LoopScrollPrefabSource
    {
        public GameObject prefab;
        public System.Action<Transform> callback;
        public int poolSize = 5;

        private bool inited = false;
        public virtual GameObject GetObject()
        {
            if (!inited)
            {
                SG.ResourceManager.Instance.InitPool(prefab, poolSize);
                inited = true;
            }
            return SG.ResourceManager.Instance.GetObjectFromPool(prefab);
        }

        public virtual void ReturnObject(Transform go)
        {
            callback?.Invoke(go);
            SG.ResourceManager.Instance.ReturnObjectToPool(go.gameObject);
        }
    }
}
