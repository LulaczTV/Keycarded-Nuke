using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keycarded_Nuke
{
    public class Config
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        [Description("if true, nuke cancel button requires keycard with nuke perms")]
        public bool NukeCancelButtonLocked { get; set; } = true;
        [Description("if true, nuke elevator requires keycard with nuke perms")]
        public bool NukeSiloElevatorLocked { get; set; } = true;
        [Description("if true, nuke surface door requires keycard with nuke perms")]
        public bool SurfaceNukeLocked { get; set; } = true;
        [Description("Hint message, when player don't have needed keycard")]
        public string HintMessage { get; set; } = "<color=red>ACCESS DENIED:\nREQUIRES WARHEAD ACCESS!</color>";
    }
}
