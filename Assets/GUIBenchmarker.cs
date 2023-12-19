using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StinkySteak.Benchmark.LoadAsset
{
    public class GUIBenchmarker : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _button;
        [SerializeField] private Benchmarker _benchmarker;

        private void Start()
        {
            _button.onClick.AddListener(_benchmarker.Benchmark);
            _benchmarker.OnBenchmarkDone += OnBenchmarkDone;
        }

        private void OnBenchmarkDone()
        {
            _text.SetText($"Resources: {_benchmarker.ResourcesMiliseconds}ms\nAddressables: {_benchmarker.AddressablesMiliseconds}ms");
        }
    }
}