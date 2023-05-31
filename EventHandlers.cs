using Interactables.Interobjects.DoorUtils;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Core.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keycarded_Nuke
{
    public class EventHandlers
    {
        [PluginEvent(PluginAPI.Enums.ServerEventType.PlayerInteractDoor)]
        public bool OnPlayerInteractDoor(Player player, DoorVariant door, bool canOpen)
        {
            //get nametag of interacted door
            var nameTag = door.TryGetComponent(out DoorNametagExtension name) ? name.GetName : null;
            int bracketStart = nameTag.IndexOf('(') - 1;
            bool HasO5 = false;
            bool HasFacilityManager = false;

            if (Plugin.Instance.Config.SurfaceNukeLocked)
            {
                if (bracketStart > 0)
                    nameTag.Remove(bracketStart, nameTag.Length - bracketStart);
                if (nameTag == "SURFACE_NUKE")
                {
                    foreach (var item in player.Items)
                    {
                        //check if player has one of needed keycard.
                        if (item.ItemTypeId == ItemType.KeycardO5)
                        {
                            HasO5 = true;
                        }
                        else if (item.ItemTypeId == ItemType.KeycardFacilityManager)
                        {
                            HasFacilityManager = true;
                        }
                    }
                    //check if bool is true
                    if (HasFacilityManager)
                    {
                        return true;
                    }
                    else if (HasO5)
                    {
                        return true;
                    }
                    else
                    {
                        player.ReceiveHint(Plugin.Instance.Config.HintMessage);
                        return false;
                    }
                }
            }
            return true;
        }

        [PluginEvent(PluginAPI.Enums.ServerEventType.PlayerInteractElevator)]
        public bool OnPlayerInteractElevator(Player player, Interactables.Interobjects.ElevatorChamber elevator)
        {
            bool HasO5 = false;
            bool HasFacilityManager = false;

            if (Plugin.Instance.Config.NukeSiloElevatorLocked)
            {
                if (elevator._assignedGroup == Interactables.Interobjects.ElevatorManager.ElevatorGroup.Nuke)
                {
                    foreach (var item in player.Items)
                    {
                        if (item.ItemTypeId == ItemType.KeycardO5)
                        {
                            HasO5 = true;
                        }
                        else if (item.ItemTypeId == ItemType.KeycardFacilityManager)
                        {
                            HasFacilityManager = true;
                        }
                    }
                    if (HasFacilityManager)
                    {
                        return true;
                    }
                    else if (HasO5)
                    {
                        return true;
                    }
                    else
                    {
                        player.ReceiveHint(Plugin.Instance.Config.HintMessage);
                        return false;
                    }
                }
                else return true;
            }
            else return true;
        }

        [PluginEvent(PluginAPI.Enums.ServerEventType.WarheadStop)]
        public bool OnWarheadStop(Player player)
        {
            bool HasO5 = false;
            bool HasFacilityManager = false;

            if (Plugin.Instance.Config.NukeCancelButtonLocked)
            {
                foreach (var item in player.Items)
                {
                    if (item.ItemTypeId == ItemType.KeycardO5)
                    {
                        HasO5 = true;
                    }
                    else if (item.ItemTypeId == ItemType.KeycardFacilityManager)
                    {
                        HasFacilityManager = true;
                    }
                }
                if (HasFacilityManager)
                {
                    return true;
                }
                else if (HasO5)
                {
                    return true;
                }
                else
                {
                    player.ReceiveHint(Plugin.Instance.Config.HintMessage);
                    return false;
                }
            }
            else return true;
        }
    }
}
