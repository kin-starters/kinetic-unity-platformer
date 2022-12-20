using System;
using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;
using Kinetic.Sdk;
using Kinetic.Sdk.Interfaces;
using Solana.Unity.Rpc.Types;
using TMPro;


namespace Platformer.Kinetic
{
    public class GetBalanceZone : MonoBehaviour
    {

        public TextMeshPro TxtBalance;

        void OnTriggerEnter2D(Collider2D collider)
        {
            GetBalance();
        }

        public async void GetBalance()
        {
            Debug.Log("GetBalance!!!!!!!!!");
            TxtBalance.text = "Please wait! Getting your balance from blockchain...";

            Keypair UserKeypair = Platformer.Mechanics.GameController.UserKeypair;
            KineticSdk Kinetic = Platformer.Mechanics.GameController.Kinetic;
            var balance = await Kinetic.GetBalance(UserKeypair.PublicKey);
            Debug.Log("Balance!");
            Debug.Log(balance.Balance);
            TxtBalance.text = $"{balance.Balance} Kin";
        }
    }
}