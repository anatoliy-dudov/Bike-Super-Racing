using BikeSuperRacing.Domain.Profile;
using UnityEngine;

namespace BikeSuperRacing.Infrastructure.Save.CloudStub
{
    public sealed class CloudSaveStubService
    {
        public bool TryPullProfile(out PlayerProfile playerProfile)
        {
            playerProfile = null;
            Debug.Log("CloudSaveStubService: cloud pull is not implemented in MVP.");
            return false;
        }

        public void PushProfile(PlayerProfile playerProfile)
        {
            if (playerProfile == null)
            {
                Debug.LogWarning("CloudSaveStubService: playerProfile is null.");
                return;
            }

            Debug.Log("CloudSaveStubService: cloud push is not implemented in MVP.");
        }
    }
}
