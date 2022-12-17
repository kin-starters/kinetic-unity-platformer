﻿using System;
using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;
using Kinetic.Sdk;
using Kinetic.Sdk.Interfaces;
using Solana.Unity.Rpc.Types;
using TMPro;


namespace Platformer.Mechanics
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
            Debug.Log("GetBalance!!!!!!!!!!!");
            TxtBalance.text = "Please wait! Getting your balance from blockchain...";

            Keypair Keypair = Platformer.Mechanics.GameController.Keypair;
            KineticSdk KineticSdk = Platformer.Mechanics.GameController.KineticSdk;
            var balance = await KineticSdk.GetBalance(Keypair.PublicKey);
            Debug.Log("Balance!");
            Debug.Log(balance.Balance);
            TxtBalance.text = $"{balance.Balance} Kin";
        }
    }
}