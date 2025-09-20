//----------------------------------------------------------------------------------------------------------
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
using System.Collections.Generic;
#endregion

namespace W.Api.Logging
{
    public static class Logger
    {
        #region Private Static Singleton Logger
        private static IList<ILogEventListener> theLoggers = null;
        private static IList<ILogEventListener> Local
        {
            get {
                if (theLoggers == null) {
                    theLoggers = new List<ILogEventListener> ();
                    // Console Logger (only Debug-enabled logger) is in position 0.
                    theLoggers.Add (
                        new ConsoleLogEventListener ()
                    );
                }
                return theLoggers;
            }
        }
        #endregion

        #region Public Static Operations
        public static void RegisterLogEventListener (ILogEventListener listener)
        {
            Local.Add (listener);
        }

        public static void Debug (int i)
        {
#if DEBUG
            foreach (ILogEventListener _l in Local) {
                _l.Debug (i);
            }
#endif
        }

        public static void Debug (double f)
        {
#if DEBUG
            foreach (ILogEventListener _l in Local) {
                _l.Debug (f);
            }
#endif
        }

        public static void Debug (string message)
        {
#if DEBUG
            foreach (ILogEventListener _l in Local) {
                _l.Debug (message);
            }
#endif
        }

        public static void Debug (Exception exception)
        {
#if DEBUG
            foreach (ILogEventListener _l in Local) {
                _l.Debug (exception);
            }
#endif
        }

        public static void Debug (Action<ILogEventListener> action)
        {
#if DEBUG
            foreach (ILogEventListener _l in Local) {
                _l.Debug (action);
            }
#endif
        }

        public static void Audit (string message)
        {
            foreach (ILogEventListener _l in Local) {
                _l.Audit (message);
            }
        }

        public static void Info (string message)
        {
            foreach (ILogEventListener _l in Local) {
                _l.Info (message);
            }
        }

        public static void Warning (string message)
        {
            foreach (ILogEventListener _l in Local) {
                _l.Warning (message);
            }
        }

        public static void Error (string message)
        {
            foreach (ILogEventListener _l in Local) {
                _l.Error (message);
            }
        }

        public static void Error (Exception exception)
        {
            foreach (ILogEventListener _l in Local) {
                _l.Error (exception);
            }
        }
        #endregion

        #region Static Asserts
        public static bool AssertNotNull (object o0)
        {
            return Local [0].AssertNotNull (o0);
        }

        public static bool AssertIsNull (object o0)
        {
            return Local [0].AssertIsNull (o0);
        }

        public static bool AssertEquals (int o0, int o1)
        {
            return Local [0].AssertEquals (o0, o1);
        }

        public static bool AssertEquals (double o0, double o1)
        {
            return Local [0].AssertEquals (o0, o1);
        }

        public static bool AssertEquals (string o0, string o1, bool refEquals = false)
        {
            return Local [0].AssertEquals (o0, o1, refEquals);
        }
        #endregion
    }

    public abstract class AbstractLogEventListener : ILogEventListener
    {
        public abstract void Debug (int i);
        public abstract void Debug (double f);
        public abstract void Debug (string message);
        public abstract void Debug (Exception __xception);
        public abstract void Debug (Action<ILogEventListener> action);
        public abstract void Audit (string message);
        public abstract void Info (string message);
        public abstract void Warning (string message);
        public abstract void Error (string message);
        public abstract void Error (Exception __xception);
        public abstract bool AssertNotNull (object o0);
        public abstract bool AssertIsNull (object o0);
        public abstract bool AssertEquals (int i0, int i1);
        public abstract bool AssertEquals (double d0, double d1);
        public abstract bool AssertEquals (string s0, string s1, bool refEquals = false);
    }
}