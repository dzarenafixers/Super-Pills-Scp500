using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.API.Features.Pickups;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Server;
using UnityEngine;
// هذا المشروع محمي من قبل حقوق االطبع والنشر MTI , صانعه الاصلي MOCNEF50G 
// ويشرف عليه dzarenafixer لذا نرجو عدم مخالفة القواعد واستشر المالك اذا اردت اخذه وشكرا
namespace SCP500Expanded.Handlers
{
    public class SpawnPillsManager
    {
        private readonly uint[] pillIds = 
        {
            5006,
            5009, 
            5001, 
            5004, 
            5003, 
            50402,
            5009,
            6658, 
            4445, 
            23585, 
            33, 
            222,
            111, 
            525,
            425,
            8686,
            5014,
            22222,
            505050,
            5005,
            5007,
            14,
            5011,

        };

        // Number of pills to spawn during the round
        private const int PillsToSpawn = 25;

        // Called when the round starts
        public void OnRoundStarted()
        {
            Log.Info("Spawning pills randomly across the map...");

            // Get all rooms in the map
            List<Room> rooms = Room.List.ToList();

            // Shuffle the list of rooms
            rooms = rooms.OrderBy(_ => Random.Range(0, rooms.Count)).ToList();

            // Spawn pills in random rooms
            for (int i = 0; i < PillsToSpawn; i++)
            {
                if (rooms.Count == 0) break; // If no rooms remain, stop spawning

                // Select a random room
                Room randomRoom = rooms[Random.Range(0, rooms.Count)];

                // Generate a random position within the room
                Vector3 spawnPosition = randomRoom.Position + new Vector3(
                    Random.Range(-5f, 5f), // Random X offset
                    1f, // Fixed Y offset to avoid ground issues
                    Random.Range(-5f, 5f) // Random Z offset
                );

                // Select a random pill ID
                uint selectedPillId = pillIds[Random.Range(0, pillIds.Length)];

                // Attempt to spawn the pill
                if (CustomItem.TrySpawn(selectedPillId, spawnPosition, out Pickup? spawnedPickup))
                {
                    Log.Debug($"Spawned pill ID {selectedPillId} in room {randomRoom.Type} at {spawnPosition}");
                }
                else
                {
                    Log.Warn($"Failed to spawn pill ID {selectedPillId} in room {randomRoom.Type}");
                }

                // Remove the room from the list to avoid spawning multiple pills in the same room
                rooms.Remove(randomRoom);
            }

            Log.Info("Pills spawned successfully!");
        }
    }
}