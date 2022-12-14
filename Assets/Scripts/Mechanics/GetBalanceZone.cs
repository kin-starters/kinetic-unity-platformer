using System;
using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;
using Kinetic.Sdk;
using Kinetic.Sdk.Interfaces;
using Solana.Unity.Rpc.Types;

namespace Platformer.Mechanics
{
    public class GetBalanceZone : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            GetBalance();
        }

        public async void GetBalance()
        {
            Debug.Log("GetBalance!!!!!!!!!!!");
            Keypair Keypair = Platformer.Mechanics.GameController.Keypair;
            KineticSdk KineticSdk = Platformer.Mechanics.GameController.KineticSdk;
            var balance = await KineticSdk.GetBalance(Keypair.PublicKey);
            Debug.Log("Balance!");
            Debug.Log(balance.Balance);
        }
    }
}