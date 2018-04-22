using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;

namespace Controlprocesos.Enums {
    public sealed class ODPProcessStatus {

        private readonly String name;
        private readonly int value;

        public int Value { get { return value; } }
        public string Name { get { return name; } }

        public static readonly ODPProcessStatus InProcess = new ODPProcessStatus(1,   "En proceso");
        public static readonly ODPProcessStatus Standby = new ODPProcessStatus(2,     "En espera");
        public static readonly ODPProcessStatus Finished = new ODPProcessStatus(3,    "Finalizado");

        private ODPProcessStatus(int value, String name) {
            this.name = name;
            this.value = value;
        }

        public static List<ODPProcessStatus> GetList() {
            return new List<ODPProcessStatus> { InProcess, Standby, Finished };
        }

        public static ODPProcessStatus GetWithValue(int value) {
            switch (value) {
                case 1: return InProcess;
                case 2: return Standby;
                case 3: return Finished;
                default: return null;
            }
        }

        public override String ToString() {
            return name;
        }

    }
}