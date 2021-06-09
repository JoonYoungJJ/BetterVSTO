//#define TRY_191017
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Forms = System.Windows.Forms;
using Microsoft.Win32.SafeHandles;

namespace AppHook
{
    public class HookProcedureHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private static bool _closing;
        static HookProcedureHandle()
        {
            Forms.Application.ApplicationExit += (sender, e) => { _closing = true; };
        }

        public HookProcedureHandle(IntPtr _handle)
            : base(true)
        {
            handle = _handle;
        }

        /// <summary>
        /// 파생 클래스에서 재정의된 경우 핸들을 해제하는 데 필요한 코드를 실행합니다.
        /// <para></para>[ Return ] __ 핸들이 성공적으로 해제되면 true이고, 심각한 오류가 발생하면 false입니다. 이러한 경우 releaseHandleFailed 관리 디버깅 도우미가 생성됩니다.
        /// </summary>
        protected override bool ReleaseHandle()
        {
            //NOTE Calling Unhook during processexit causes deley
            if (_closing) return true;
            return WINAPI.User.UnhookWindowsHookEx(handle);
        }
    }
}
