using LavishScriptAPI;
using LavishVMAPI;
using System;

namespace Daedalus
{
    using Behaviours;
    using Functions;
    using Modules;

    public class Daedalus
    {
        // EventHandler for Pulse
        private static event EventHandler<LSEventArgs> Frame;

        // ISXEVE Variables
        public static EVE.ISXEVE.EVE Eve;
		public static EVE.ISXEVE.Me Me;
        public static EVE.ISXEVE.Ship MyShip;
        public static EVE.ISXEVE.Station Station;

        // Pulse Variables
        private static DateTime NextPulse;
        private static int PulseRate = 1;

        // Misc Variables
        public static bool Paused = false;

        public static UI DaedalusUI;

        public Daedalus(UI Arg)
        {
            DaedalusUI = Arg;
            // One time only constructor.
            Frame += new EventHandler<LSEventArgs>(Pulse);
            DaedalusUI.NewConsoleMessage("Daedalus 06/06/2016");
            System.Media.SystemSounds.Asterisk.Play();
            Start();
        }

        public static void Start()
        {
            AttachEvent();
            NextPulse = DateTime.Now.AddSeconds(PulseRate);
        }

        static internal void AttachEvent()
        {
            LavishScript.Events.AttachEventTarget("ISXEVE_OnFrame", Frame);
            DaedalusUI.NewConsoleMessage("Attaching to ISXEVE");
        }

        static internal void AttachEvent(object sender, EventArgs e)
        {
            AttachEvent();
        }
        
        static internal void DetachEvent()
        {
			LavishScript.Events.DetachEventTarget("ISXEVE_OnFrame", Frame);
        }
        
        private static void Pulse(object sender, LSEventArgs e)
        {
            using (new FrameLock(true))
            {
                if (DateTime.Now > NextPulse)
                {
                    NextPulse = DateTime.Now.AddSeconds(PulseRate);
                    Eve = new EVE.ISXEVE.EVE();
                    Me = new EVE.ISXEVE.Me();
                    MyShip = new EVE.ISXEVE.Ship();

                    DaedalusUI.Text = "Daedalus - " + Me.Name + " [" + m_RoutineController.ActiveRoutine.ToString() + "]";
                    if (!Paused) b_Mining.Pulse();
                }
                return;
            }
        }
    }
}
