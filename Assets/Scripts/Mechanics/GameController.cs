using Platformer.Core;
using Platformer.Model;
using UnityEngine;
using System;
using Kinetic.Sdk;
using Kinetic.Sdk.Interfaces;
using Solana.Unity.Rpc.Types;
using TMPro;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This class exposes the the game model in the inspector, and ticks the
    /// simulation.
    /// </summary> 
    public class GameController : MonoBehaviour
    {
        public static GameController Instance { get; private set; }

        //This model field is public and can be therefore be modified in the 
        //inspector.
        //The reference actually comes from the InstanceRegister, and is shared
        //through the simulation and events. Unity will deserialize over this
        //shared reference when the scene loads, allowing the model to be
        //conveniently configured inside the inspector.
        public PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public TextMeshPro TxtKinetic;
        public string endpoint = "https://sandbox.kinetic.host";
        public string environment = "devnet";
        public int index = 407;
        public static KineticSdk KineticSdk { get; private set; }
        public static Keypair Keypair { get; set; }

        void OnEnable()
        {
            Instance = this;
        }

        void OnDisable()
        {
            if (Instance == this) Instance = null;
        }

        void Update()
        {
            if (Instance == this) Simulation.Tick();
        }


        async void Awake()
        {
            KineticSdk = await KineticSdk.Setup(
                new KineticSdkConfig(
                    index: index,
                    endpoint: endpoint,
                    environment: environment,
                    logger: new Logger(Debug.unityLogger.logHandler)
                )
            );

            if (KineticSdk == null) TxtKinetic.text = "Not connected to Kinetic on Target API 28";
            KineticSdk = await KineticSdk.Setup(
                new KineticSdkConfig(
                    index: index,
                    endpoint: endpoint,
                    environment: environment,
                    logger: new Logger(Debug.unityLogger.logHandler)
                )
            );

            Debug.Log(KineticSdk);
            if (KineticSdk != null) TxtKinetic.text = "Connected to Kinetic!";


        }
    }
}
