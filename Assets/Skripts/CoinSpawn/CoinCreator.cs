using System;
using System.Collections.Generic;
using UnityEngine;
using BarrierEntity;
using BarriersEntity;
using Spawn;


namespace CoinSpawn
{
    [RequireComponent(typeof(Barriers))]
    public class CoinCreator : Spawner<Coin>
    {
        [SerializeField] Vector3 _offset;

        private Barriers _barriers;
        private Transform _transform;
        private List<Barrier> _barrier;

        private WaitForSeconds _sleep;
        private int _sleepDuration = 2;

        public event Action PlayedSound;

        private void OnEnable()
        {
            foreach (var barrierCollision in _barrier)
            {
                barrierCollision.CreateCoin += On—hargeCoin;
            }
        }

        private void OnDisable()
        {
            foreach (var barrierCollision in _barrier)
            {
                barrierCollision.CreateCoin -= On—hargeCoin;
            }
        }

        private void Awake()
        {
            _transform = transform;
            _barriers = GetComponent<Barriers>();
            _barrier = CollectBarrier();

            _sleep = new WaitForSeconds(_sleepDuration);
        }

        private void On—hargeCoin(int point, Vector3 position)
        {
            Coin coin = Spawn(position + _offset, Quaternion.identity);
            coin.SetText(point.ToString());
            coin.StartAnimation();
            _barriers.AddPoints(point);

            PlayedSound?.Invoke();

            StartCoroutine(Sleep(coin));
        }

        private List<BarrierCollision> CollectBarriersCollision()
        {
            List<BarrierCollision> temp = new List<BarrierCollision>();

            foreach (Transform child in _transform)
            {
                if (child.TryGetComponent(out BarrierCollision barriersPlace))
                {
                    temp.Add(barriersPlace);
                }
            }

            return temp;
        }

        private List<Barrier> CollectBarrier()
        {
            List<Barrier> temp = new List<Barrier>();

            foreach (Transform child in _transform)
            {
                if (child.TryGetComponent(out Barrier barrier))
                {
                    temp.Add(barrier);
                }
            }

            return temp;
        }

        private IEnumerator<WaitForSeconds> Sleep(Coin coin)
        {
            yield return _sleep;

            ReturnToPool(coin);
            coin.ResetFade();
        }
    }
}