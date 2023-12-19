using NaughtyAttributes;
using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace StinkySteak.Benchmark.LoadAsset
{
    public class Benchmarker : MonoBehaviour
    {
        [SerializeField] private int _count = 10000;
        [SerializeField] private string _addressablePath;

        public event Action OnBenchmarkDone;

        private long _resourcesMiliseconds;
        private long _addressablesMiliseconds;

        public long ResourcesMiliseconds => _resourcesMiliseconds;
        public long AddressablesMiliseconds => _addressablesMiliseconds;

        [Button]
        public void Benchmark()
        {
            LoadResources();
            LoadAddressable();
            OnBenchmarkDone?.Invoke();
        }

        private void LoadResources()
        {
            Stopwatch sw = new();
            sw.Start();

            for (int i = 0; i < _count; i++)
            {
                Resources.Load<DummySO>(nameof(DummySO));
            }

            sw.Stop();
            _resourcesMiliseconds = sw.ElapsedMilliseconds;
            print($"[{nameof(Benchmarker)}]: LoadResources: {_resourcesMiliseconds}");
        }

        private void LoadAddressable()
        {
            Stopwatch sw = new();
            sw.Start();

            for (int i = 0; i < _count; i++)
            {
                Addressables.LoadAsset<DummySO>(nameof(DummySO));
            }

            sw.Stop();
            _addressablesMiliseconds = sw.ElapsedMilliseconds;
            print($"[{nameof(Benchmarker)}]: LoadAddressables: {_addressablesMiliseconds}");
        }

        //private void LoadAddressableAsync()
        //{
        //    Stopwatch sw = new();
        //    sw.Start();

        //    _elapsedTime = new float[_count];
        //    Button b;

        //    b.onClick.AddListener(() => Completed(default));

        //    for (int i = 0; i < _count; i++)
        //    {
        //        var op = Addressables.LoadAssetAsync<DummySO>(nameof(DummySO));
        //        //op.Completed += (default) => Completed(default);
        //    }

        //    sw.Stop();
        //    print($"[{nameof(Benchmarker)}]: LoadResources: {sw.ElapsedMilliseconds}");
        //}

        //private int _indexer;
        //private float[] _elapsedTime;
        //private Stopwatch[] _stopWatches;

        //private void Completed(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<DummySO> obj)
        //{

        //}

        //private void CalculateFinal()
        //{
        //    float total = 0;

        //    foreach (Stopwatch time in _stopWatches)
        //        total += time.ElapsedTicks;

        //    print($"[{nameof(Benchmarker)}]: Time: {total}");
        //}
    }
}