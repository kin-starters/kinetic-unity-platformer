﻿using System;
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
    public class KeypairZone : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            Debug.Log("Create Keypair!!!!!!!!!!!");
            Keypair Keypair = Keypair.Random();
            Debug.Log(Keypair.PublicKey);
            Debug.Log(Keypair.Mnemonic);
            Platformer.Mechanics.GameController.Keypair = Keypair;
        }
    }
}