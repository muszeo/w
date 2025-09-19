//----------------------------------------------------------------------------------------------------------
//
//  (c) , 2025
//
//----------------------------------------------------------------------------------------------------------
using System;

namespace W.Api.Logging
{
    public interface ILogEventListener
    {
        void Debug (int i);
        void Debug (double f);
        void Debug (string message);
        void Debug (Exception __xception);
        void Debug (Action<ILogEventListener> action);
        void Audit (string message);
        void Info (string message);
        void Warning (string message);
        void Error (string message);
        void Error (Exception __xception);
        bool AssertNotNull (object o0);
        bool AssertIsNull (object o0);
        bool AssertEquals (int i0, int i1);
        bool AssertEquals (double d0, double d1);
        bool AssertEquals (string s0, string s1, bool refEquals = false);
    }
}