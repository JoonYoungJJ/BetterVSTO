using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;

using HANDLE = System.IntPtr;

using HDC = System.IntPtr;

using HWND = System.IntPtr;

namespace WINAPI
{
    /*◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇
     * 2019/11/3 수정된내용
     - Originally picked for 16-bit operating systems (L=32-bits, W=16-bits), 
     migrated to 32-bit without changing the name (W=32-bits), we're at 64-bit today (L=W=64-bits).
     L means LRESULT, W means WRESULT.
     - 'Ex' of some functions name means 'Extended'.
    ◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇◆◇*/
    /// <summary>
    /// An application-defined callback function used with the EnumChildWindows function. It receives the child window handles. The WNDENUMPROC type defines a pointer to this callback function. EnumChildProc is a placeholder for the application-defined function name.
    /// <para></para>[Return] To continue enumeration, the callback function must return TRUE; to stop enumeration, it must return FALSE.
    /// </summary>
    /// <param name="hwnd">A handle to a child window of the parent window specified in EnumChildWindows.</param>
    /// <param name="lParam">The application-defined value given in EnumChildWindows.</param>
    /// <returns>To continue enumeration, the callback function must return TRUE; to stop enumeration, it must return FALSE.</returns>
    public delegate bool Win32Callback(IntPtr hwnd, IntPtr lParam);
    /// <summary>
    /// If a window subscribe a hook or more, after(or before) the corresponding hook procedure is done, send message(notification) to the procedure(IntPtr).
    /// <para></para>[ Important Featrue ] Developer can detects actions by installing appropriate code to this delegate.
    /// <para></para>Ex> Whenever the nCode is sent, call some function.
    /// <para></para>[Returns 0/1 For operation or prevention]
    /// For operations corresponding to the following CBT hook codes, the return value must be 0 to allow the operation, or 1 to prevent it
    /// <para></para>HCBT_ACTIVATE,
    /// HCBT_CREATEWND,
    /// HCBT_DESTROYWND,
    /// HCBT_MINMAX,
    /// HCBT_MOVESIZE,
    /// HCBT_SETFOCUS,
    /// HCBT_SYSCOMMAND
    /// <para></para>[Returns Ignored] For operations corresponding to the following CBT hook codes, the return value is ignored.
    /// <para></para>
    /// HCBT_CLICKSKIPPED, 
    /// HCBT_KEYSKIPPED, 
    /// HCBT_QS
    /// </summary>
    /// <param name="nCode">If nCode is less than zero, the hook procedure must pass the message to the CallNextHookEx function without further processing and should return the value returned by CallNextHookEx.</param>
    /// <param name="wParam"></param>
    /// <param name="lParam"></param>
    /// <returns>
    /// For operations corresponding to the following CBT hook codes, the return value must be 0 to allow the operation, or 1 to prevent it
    /// <para></para>HCBT_ACTIVATE,
    /// HCBT_CREATEWND,
    /// HCBT_DESTROYWND,
    /// HCBT_MINMAX,
    /// HCBT_MOVESIZE,
    /// HCBT_SETFOCUS,
    /// HCBT_SYSCOMMAND
    /// </returns>
    public delegate IntPtr CBTProc(CBT_CodeMap nCode, IntPtr wParam, IntPtr lParam);
    /// <summary>
    /// If a window subscribe a hook or more, after(or before) the corresponding hook procedure is done, send message(notification) to the procedure(IntPtr).
    /// <para></para>[ Important Featrue ] Developer can detects actions by installing appropriate code to this delegate.
    /// <para></para>Ex> Whenever the nCode is sent, call some function.
    /// <para></para>[Returns 0/1 For operation or prevention]
    /// For operations corresponding to the following CBT hook codes, the return value must be 0 to allow the operation, or 1 to prevent it
    /// <para></para>HCBT_ACTIVATE,
    /// HCBT_CREATEWND,
    /// HCBT_DESTROYWND,
    /// HCBT_MINMAX,
    /// HCBT_MOVESIZE,
    /// HCBT_SETFOCUS,
    /// HCBT_SYSCOMMAND
    /// <para></para>[Returns Ignored] For operations corresponding to the following CBT hook codes, the return value is ignored.
    /// <para></para>
    /// HCBT_CLICKSKIPPED, 
    /// HCBT_KEYSKIPPED, 
    /// HCBT_QS
    /// </summary>
    /// <param name="nCode">If nCode is less than zero, the hook procedure must pass the message to the CallNextHookEx function without further processing and should return the value returned by CallNextHookEx.</param>
    /// <param name="wParam"></param>
    /// <param name="lParam"></param>
    /// <returns>
    /// For operations corresponding to the following CBT hook codes, the return value must be 0 to allow the operation, or 1 to prevent it
    /// <para></para>HCBT_ACTIVATE,
    /// HCBT_CREATEWND,
    /// HCBT_DESTROYWND,
    /// HCBT_MINMAX,
    /// HCBT_MOVESIZE,
    /// HCBT_SETFOCUS,
    /// HCBT_SYSCOMMAND
    /// </returns>
    public delegate IntPtr CBTProc_Hook(User.WindowHook nCode, IntPtr wParam, IntPtr lParam);
    
    /// <summary>
    /// Windows Messages
    /// Defined in winuser.h from Windows SDK v6.1
    /// Documentation pulled from MSDN.
    /// </summary>
    public enum WM : uint
    {
        /// <summary>
        /// The WM_NULL message performs no operation. An application sends the WM_NULL message if it wants to post a message that the recipient window will ignore.
        /// </summary>
        NULL = 0x0000,
        /// <summary>
        /// The WM_CREATE message is sent when an application requests that a window be created by calling the CreateWindowEx or CreateWindow function. (The message is sent before the function returns.) The window procedure of the new window receives this message after the window is created, but before the window becomes visible.
        /// </summary>
        CREATE = 0x0001,
        /// <summary>
        /// The WM_DESTROY message is sent when a window is being destroyed. It is sent to the window procedure of the window being destroyed after the window is removed from the screen. 
        /// This message is sent first to the window being destroyed and then to the child windows (if any) as they are destroyed. During the processing of the message, it can be assumed that all child windows still exist.
        /// /// </summary>
        DESTROY = 0x0002,
        /// <summary>
        /// The WM_MOVE message is sent after a window has been moved. 
        /// </summary>
        MOVE = 0x0003,
        /// <summary>
        /// The WM_SIZE message is sent to a window after its size has changed.
        /// </summary>
        SIZE = 0x0005,
        /// <summary>
        /// The WM_ACTIVATE message is sent to both the window being activated and the window being deactivated. If the windows use the same input queue, the message is sent synchronously, first to the window procedure of the top-level window being deactivated, then to the window procedure of the top-level window being activated. If the windows use different input queues, the message is sent asynchronously, so the window is activated immediately. 
        /// </summary>
        ACTIVATE = 0x0006,
        /// <summary>
        /// The WM_SETFOCUS message is sent to a window after it has gained the keyboard focus. 
        /// </summary>
        SETFOCUS = 0x0007,
        /// <summary>
        /// The WM_KILLFOCUS message is sent to a window immediately before it loses the keyboard focus. 
        /// </summary>
        KILLFOCUS = 0x0008,
        /// <summary>
        /// The WM_ENABLE message is sent when an application changes the enabled state of a window. It is sent to the window whose enabled state is changing. This message is sent before the EnableWindow function returns, but after the enabled state (WS_DISABLED style bit) of the window has changed. 
        /// </summary>
        ENABLE = 0x000A,
        /// <summary>
        /// An application sends the WM_SETREDRAW message to a window to allow changes in that window to be redrawn or to prevent changes in that window from being redrawn. 
        /// </summary>
        SETREDRAW = 0x000B,
        /// <summary>
        /// An application sends a WM_SETTEXT message to set the text of a window. 
        /// </summary>
        SETTEXT = 0x000C,
        /// <summary>
        /// An application sends a WM_GETTEXT message to copy the text that corresponds to a window into a buffer provided by the caller. 
        /// </summary>
        GETTEXT = 0x000D,
        /// <summary>
        /// An application sends a WM_GETTEXTLENGTH message to determine the length, in characters, of the text associated with a window. 
        /// </summary>
        GETTEXTLENGTH = 0x000E,
        /// <summary>
        /// The WM_PAINT message is sent when the system or another application makes a request to paint a portion of an application's window. The message is sent when the UpdateWindow or RedrawWindow function is called, or by the DispatchMessage function when the application obtains a WM_PAINT message by using the GetMessage or PeekMessage function. 
        /// </summary>
        PAINT = 0x000F,
        /// <summary>
        /// The WM_CLOSE message is sent as a signal that a window or an application should terminate.
        /// </summary>
        CLOSE = 0x0010,
        /// <summary>
        /// The WM_QUERYENDSESSION message is sent when the user chooses to end the session or when an application calls one of the system shutdown functions. If any application returns zero, the session is not ended. The system stops sending WM_QUERYENDSESSION messages as soon as one application returns zero.
        /// After processing this message, the system sends the WM_ENDSESSION message with the wParam parameter set to the results of the WM_QUERYENDSESSION message.
        /// </summary>
        QUERYENDSESSION = 0x0011,
        /// <summary>
        /// The WM_QUERYOPEN message is sent to an icon when the user requests that the window be restored to its previous size and position.
        /// </summary>
        QUERYOPEN = 0x0013,
        /// <summary>
        /// The WM_ENDSESSION message is sent to an application after the system processes the results of the WM_QUERYENDSESSION message. The WM_ENDSESSION message informs the application whether the session is ending.
        /// </summary>
        ENDSESSION = 0x0016,
        /// <summary>
        /// The WM_QUIT message indicates a request to terminate an application and is generated when the application calls the PostQuitMessage function. It causes the GetMessage function to return zero.
        /// </summary>
        QUIT = 0x0012,
        /// <summary>
        /// The WM_ERASEBKGND message is sent when the window background must be erased (for example, when a window is resized). The message is sent to prepare an invalidated portion of a window for painting. 
        /// </summary>
        ERASEBKGND = 0x0014,
        /// <summary>
        /// This message is sent to all top-level windows when a change is made to a system color setting. 
        /// </summary>
        SYSCOLORCHANGE = 0x0015,
        /// <summary>
        /// The WM_SHOWWINDOW message is sent to a window when the window is about to be hidden or shown.
        /// </summary>
        SHOWWINDOW = 0x0018,
        /// <summary>
        /// An application sends the WM_WININICHANGE message to all top-level windows after making a change to the WIN.INI file. The SystemParametersInfo function sends this message after an application uses the function to change a setting in WIN.INI.
        /// Note  The WM_WININICHANGE message is provided only for compatibility with earlier versions of the system. Applications should use the WM_SETTINGCHANGE message.
        /// </summary>
        WININICHANGE = 0x001A,
        /// <summary>
        /// An application sends the WM_WININICHANGE message to all top-level windows after making a change to the WIN.INI file. The SystemParametersInfo function sends this message after an application uses the function to change a setting in WIN.INI.
        /// Note  The WM_WININICHANGE message is provided only for compatibility with earlier versions of the system. Applications should use the WM_SETTINGCHANGE message.
        /// </summary>
        SETTINGCHANGE = WININICHANGE,
        /// <summary>
        /// The WM_DEVMODECHANGE message is sent to all top-level windows whenever the user changes device-mode settings. 
        /// </summary>
        DEVMODECHANGE = 0x001B,
        /// <summary>
        /// The WM_ACTIVATEAPP message is sent when a window belonging to a different application than the active window is about to be activated. The message is sent to the application whose window is being activated and to the application whose window is being deactivated.
        /// </summary>
        ACTIVATEAPP = 0x001C,
        /// <summary>
        /// An application sends the WM_FONTCHANGE message to all top-level windows in the system after changing the pool of font resources. 
        /// </summary>
        FONTCHANGE = 0x001D,
        /// <summary>
        /// A message that is sent whenever there is a change in the system time.
        /// </summary>
        TIMECHANGE = 0x001E,
        /// <summary>
        /// The WM_CANCELMODE message is sent to cancel certain modes, such as mouse capture. For example, the system sends this message to the active window when a dialog box or message box is displayed. Certain functions also send this message explicitly to the specified window regardless of whether it is the active window. For example, the EnableWindow function sends this message when disabling the specified window.
        /// </summary>
        CANCELMODE = 0x001F,
        /// <summary>
        /// The WM_SETCURSOR message is sent to a window if the mouse causes the cursor to move within a window and mouse input is not captured. 
        /// </summary>
        SETCURSOR = 0x0020,
        /// <summary>
        /// The WM_MOUSEACTIVATE message is sent when the cursor is in an inactive window and the user presses a mouse button. The parent window receives this message only if the child window passes it to the DefWindowProc function.
        /// <para></para> [Form] WndProc에서 사용시, 마우스 클릭(우/좌)을 감지할 수 있음
        /// </summary>
        MOUSEACTIVATE = 0x0021,
        /// <summary>
        /// The WM_CHILDACTIVATE message is sent to a child window when the user clicks the window's title bar or when the window is activated, moved, or sized.
        /// </summary>
        CHILDACTIVATE = 0x0022,
        /// <summary>
        /// The WM_QUEUESYNC message is sent by a computer-based training (CBT) application to separate user-input messages from other messages sent through the WH_JOURNALPLAYBACK Hook procedure. 
        /// </summary>
        QUEUESYNC = 0x0023,
        /// <summary>
        /// The WM_GETMINMAXINFO message is sent to a window when the size or position of the window is about to change. An application can use this message to override the window's default maximized size and position, or its default minimum or maximum tracking size. 
        /// </summary>
        GETMINMAXINFO = 0x0024,
        /// <summary>
        /// Windows NT 3.51 and earlier: The WM_PAINTICON message is sent to a minimized window when the icon is to be painted. This message is not sent by newer versions of Microsoft Windows, except in unusual circumstances explained in the Remarks.
        /// </summary>
        PAINTICON = 0x0026,
        /// <summary>
        /// Windows NT 3.51 and earlier: The WM_ICONERASEBKGND message is sent to a minimized window when the background of the icon must be filled before painting the icon. A window receives this message only if a class icon is defined for the window; otherwise, WM_ERASEBKGND is sent. This message is not sent by newer versions of Windows.
        /// </summary>
        ICONERASEBKGND = 0x0027,
        /// <summary>
        /// The WM_NEXTDLGCTL message is sent to a dialog box procedure to set the keyboard focus to a different control in the dialog box. 
        /// </summary>
        NEXTDLGCTL = 0x0028,
        /// <summary>
        /// The WM_SPOOLERSTATUS message is sent from Print Manager whenever a job is added to or removed from the Print Manager queue. 
        /// </summary>
        SPOOLERSTATUS = 0x002A,
        /// <summary>
        /// The WM_DRAWITEM message is sent to the parent window of an owner-drawn button, combo box, list box, or menu when a visual aspect of the button, combo box, list box, or menu has changed.
        /// </summary>
        DRAWITEM = 0x002B,
        /// <summary>
        /// The WM_MEASUREITEM message is sent to the owner window of a combo box, list box, list view control, or menu item when the control or menu is created.
        /// </summary>
        MEASUREITEM = 0x002C,
        /// <summary>
        /// Sent to the owner of a list box or combo box when the list box or combo box is destroyed or when items are removed by the LB_DELETESTRING, LB_RESETCONTENT, CB_DELETESTRING, or CB_RESETCONTENT message. The system sends a WM_DELETEITEM message for each deleted item. The system sends the WM_DELETEITEM message for any deleted list box or combo box item with nonzero item data.
        /// </summary>
        DELETEITEM = 0x002D,
        /// <summary>
        /// Sent by a list box with the LBS_WANTKEYBOARDINPUT style to its owner in response to a WM_KEYDOWN message. 
        /// </summary>
        VKEYTOITEM = 0x002E,
        /// <summary>
        /// Sent by a list box with the LBS_WANTKEYBOARDINPUT style to its owner in response to a WM_CHAR message. 
        /// </summary>
        CHARTOITEM = 0x002F,
        /// <summary>
        /// An application sends a WM_SETFONT message to specify the font that a control is to use when drawing text. 
        /// </summary>
        SETFONT = 0x0030,
        /// <summary>
        /// An application sends a WM_GETFONT message to a control to retrieve the font with which the control is currently drawing its text. 
        /// </summary>
        GETFONT = 0x0031,
        /// <summary>
        /// An application sends a WM_SETHOTKEY message to a window to associate a hot key with the window. When the user presses the hot key, the system activates the window. 
        /// </summary>
        SETHOTKEY = 0x0032,
        /// <summary>
        /// An application sends a WM_GETHOTKEY message to determine the hot key associated with a window. 
        /// </summary>
        GETHOTKEY = 0x0033,
        /// <summary>
        /// The WM_QUERYDRAGICON message is sent to a minimized (iconic) window. The window is about to be dragged by the user but does not have an icon defined for its class. An application can return a handle to an icon or cursor. The system displays this cursor or icon while the user drags the icon.
        /// </summary>
        QUERYDRAGICON = 0x0037,
        /// <summary>
        /// The system sends the WM_COMPAREITEM message to determine the relative position of a new item in the sorted list of an owner-drawn combo box or list box. Whenever the application adds a new item, the system sends this message to the owner of a combo box or list box created with the CBS_SORT or LBS_SORT style. 
        /// </summary>
        COMPAREITEM = 0x0039,
        /// <summary>
        /// Active Accessibility sends the WM_GETOBJECT message to obtain information about an accessible object contained in a server application. 
        /// Applications never send this message directly. It is sent only by Active Accessibility in response to calls to AccessibleObjectFromPoint, AccessibleObjectFromEvent, or AccessibleObjectFromWindow. However, server applications handle this message. 
        /// </summary>
        GETOBJECT = 0x003D,
        /// <summary>
        /// The WM_COMPACTING message is sent to all top-level windows when the system detects more than 12.5 percent of system time over a 30- to 60-second interval is being spent compacting memory. This indicates that system memory is low.
        /// </summary>
        COMPACTING = 0x0041,
        /// <summary>
        /// WM_COMMNOTIFY is Obsolete for Win32-Based Applications
        /// </summary>
        [Obsolete]
        COMMNOTIFY = 0x0044,
        /// <summary>
        /// The WM_WINDOWPOSCHANGING message is sent to a window whose size, position, or place in the Z order is about to change as a result of a call to the SetWindowPos function or another window-management function.
        /// </summary>
        WINDOWPOSCHANGING = 0x0046,
        /// <summary>
        /// The WM_WINDOWPOSCHANGED message is sent to a window whose size, position, or place in the Z order has changed as a result of a call to the SetWindowPos function or another window-management function.
        /// </summary>
        WINDOWPOSCHANGED = 0x0047,
        /// <summary>
        /// Notifies applications that the system, typically a battery-powered personal computer, is about to enter a suspended mode.
        /// Use: POWERBROADCAST
        /// </summary>
        [Obsolete]
        POWER = 0x0048,
        /// <summary>
        /// An application sends the WM_COPYDATA message to pass data to another application. 
        /// </summary>
        COPYDATA = 0x004A,
        /// <summary>
        /// The WM_CANCELJOURNAL message is posted to an application when a user cancels the application's journaling activities. The message is posted with a NULL window handle. 
        /// </summary>
        CANCELJOURNAL = 0x004B,
        /// <summary>
        /// Sent by a common control to its parent window when an event has occurred or the control requires some information. 
        /// </summary>
        NOTIFY = 0x004E,
        /// <summary>
        /// The WM_INPUTLANGCHANGEREQUEST message is posted to the window with the focus when the user chooses a new input language, either with the hotkey (specified in the Keyboard control panel application) or from the indicator on the system taskbar. An application can accept the change by passing the message to the DefWindowProc function or reject the change (and prevent it from taking place) by returning immediately. 
        /// </summary>
        INPUTLANGCHANGEREQUEST = 0x0050,
        /// <summary>
        /// The WM_INPUTLANGCHANGE message is sent to the topmost affected window after an application's input language has been changed. You should make any application-specific settings and pass the message to the DefWindowProc function, which passes the message to all first-level child windows. These child windows can pass the message to DefWindowProc to have it pass the message to their child windows, and so on. 
        /// </summary>
        INPUTLANGCHANGE = 0x0051,
        /// <summary>
        /// Sent to an application that has initiated a training card with Microsoft Windows Help. The message informs the application when the user clicks an authorable button. An application initiates a training card by specifying the HELP_TCARD command in a call to the WinHelp function.
        /// </summary>
        TCARD = 0x0052,
        /// <summary>
        /// Indicates that the user pressed the F1 key. If a menu is active when F1 is pressed, WM_HELP is sent to the window associated with the menu; otherwise, WM_HELP is sent to the window that has the keyboard focus. If no window has the keyboard focus, WM_HELP is sent to the currently active window. 
        /// </summary>
        HELP = 0x0053,
        /// <summary>
        /// The WM_USERCHANGED message is sent to all windows after the user has logged on or off. When the user logs on or off, the system updates the user-specific settings. The system sends this message immediately after updating the settings.
        /// </summary>
        USERCHANGED = 0x0054,
        /// <summary>
        /// Determines if a window accepts ANSI or Unicode structures in the WM_NOTIFY notification message. WM_NOTIFYFORMAT messages are sent from a common control to its parent window and from the parent window to the common control.
        /// </summary>
        NOTIFYFORMAT = 0x0055,
        /// <summary>
        /// The WM_CONTEXTMENU message notifies a window that the user clicked the right mouse button (right-clicked) in the window.
        /// </summary>
        CONTEXTMENU = 0x007B,
        /// <summary>
        /// The WM_STYLECHANGING message is sent to a window when the SetWindowLong function is about to change one or more of the window's styles.
        /// </summary>
        STYLECHANGING = 0x007C,
        /// <summary>
        /// The WM_STYLECHANGED message is sent to a window after the SetWindowLong function has changed one or more of the window's styles
        /// </summary>
        STYLECHANGED = 0x007D,
        /// <summary>
        /// The WM_DISPLAYCHANGE message is sent to all windows when the display resolution has changed.
        /// </summary>
        DISPLAYCHANGE = 0x007E,
        /// <summary>
        /// The WM_GETICON message is sent to a window to retrieve a handle to the large or small icon associated with a window. The system displays the large icon in the ALT+TAB dialog, and the small icon in the window caption. 
        /// </summary>
        GETICON = 0x007F,
        /// <summary>
        /// An application sends the WM_SETICON message to associate a new large or small icon with a window. The system displays the large icon in the ALT+TAB dialog box, and the small icon in the window caption. 
        /// </summary>
        SETICON = 0x0080,
        /// <summary>
        /// The WM_NCCREATE message is sent prior to the WM_CREATE message when a window is first created.
        /// </summary>
        NCCREATE = 0x0081,
        /// <summary>
        /// The WM_NCDESTROY message informs a window that its nonclient area is being destroyed. The DestroyWindow function sends the WM_NCDESTROY message to the window following the WM_DESTROY message. WM_DESTROY is used to free the allocated memory object associated with the window. 
        /// The WM_NCDESTROY message is sent after the child windows have been destroyed. In contrast, WM_DESTROY is sent before the child windows are destroyed.
        /// </summary>
        NCDESTROY = 0x0082,
        /// <summary>
        /// The WM_NCCALCSIZE message is sent when the size and position of a window's client area must be calculated. By processing this message, an application can control the content of the window's client area when the size or position of the window changes.
        /// </summary>
        NCCALCSIZE = 0x0083,
        /// <summary>
        /// The WM_NCHITTEST message is sent to a window when the cursor moves, or when a mouse button is pressed or released. If the mouse is not captured, the message is sent to the window beneath the cursor. Otherwise, the message is sent to the window that has captured the mouse.
        /// </summary>
        NCHITTEST = 0x0084,
        /// <summary>
        /// The WM_NCPAINT message is sent to a window when its frame must be painted. 
        /// </summary>
        NCPAINT = 0x0085,
        /// <summary>
        /// The WM_NCACTIVATE message is sent to a window when its nonclient area needs to be changed to indicate an active or inactive state.
        /// </summary>
        NCACTIVATE = 0x0086,
        /// <summary>
        /// The WM_GETDLGCODE message is sent to the window procedure associated with a control. By default, the system handles all keyboard input to the control; the system interprets certain types of keyboard input as dialog box navigation keys. To override this default behavior, the control can respond to the WM_GETDLGCODE message to indicate the types of input it wants to process itself.
        /// </summary>
        GETDLGCODE = 0x0087,
        /// <summary>
        /// The WM_SYNCPAINT message is used to synchronize painting while avoiding linking independent GUI threads.
        /// </summary>
        SYNCPAINT = 0x0088,
        /// <summary>
        /// The WM_NCMOUSEMOVE message is posted to a window when the cursor is moved within the nonclient area of the window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        NCMOUSEMOVE = 0x00A0,
        /// <summary>
        /// The WM_NCLBUTTONDOWN message is posted when the user presses the left mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        NCLBUTTONDOWN = 0x00A1,
        /// <summary>
        /// The WM_NCLBUTTONUP message is posted when the user releases the left mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        NCLBUTTONUP = 0x00A2,
        /// <summary>
        /// The WM_NCLBUTTONDBLCLK message is posted when the user double-clicks the left mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        NCLBUTTONDBLCLK = 0x00A3,
        /// <summary>
        /// The WM_NCRBUTTONDOWN message is posted when the user presses the right mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        NCRBUTTONDOWN = 0x00A4,
        /// <summary>
        /// The WM_NCRBUTTONUP message is posted when the user releases the right mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        NCRBUTTONUP = 0x00A5,
        /// <summary>
        /// The WM_NCRBUTTONDBLCLK message is posted when the user double-clicks the right mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        NCRBUTTONDBLCLK = 0x00A6,
        /// <summary>
        /// The WM_NCMBUTTONDOWN message is posted when the user presses the middle mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        NCMBUTTONDOWN = 0x00A7,
        /// <summary>
        /// The WM_NCMBUTTONUP message is posted when the user releases the middle mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        NCMBUTTONUP = 0x00A8,
        /// <summary>
        /// The WM_NCMBUTTONDBLCLK message is posted when the user double-clicks the middle mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        NCMBUTTONDBLCLK = 0x00A9,
        /// <summary>
        /// The WM_NCXBUTTONDOWN message is posted when the user presses the first or second X button while the cursor is in the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        NCXBUTTONDOWN = 0x00AB,
        /// <summary>
        /// The WM_NCXBUTTONUP message is posted when the user releases the first or second X button while the cursor is in the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        NCXBUTTONUP = 0x00AC,
        /// <summary>
        /// The WM_NCXBUTTONDBLCLK message is posted when the user double-clicks the first or second X button while the cursor is in the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        NCXBUTTONDBLCLK = 0x00AD,
        /// <summary>
        /// The WM_INPUT_DEVICE_CHANGE message is sent to the window that registered to receive raw input. A window receives this message through its WindowProc function.
        /// </summary>
        INPUT_DEVICE_CHANGE = 0x00FE,
        /// <summary>
        /// The WM_INPUT message is sent to the window that is getting raw input. 
        /// </summary>
        INPUT = 0x00FF,
        /// <summary>
        /// This message filters for keyboard messages.
        /// </summary>
        KEYFIRST = 0x0100,
        /// <summary>
        /// The WM_KEYDOWN message is posted to the window with the keyboard focus when a nonsystem key is pressed. A nonsystem key is a key that is pressed when the ALT key is not pressed. 
        /// </summary>
        KEYDOWN = 0x0100,
        /// <summary>
        /// The WM_KEYUP message is posted to the window with the keyboard focus when a nonsystem key is released. A nonsystem key is a key that is pressed when the ALT key is not pressed, or a keyboard key that is pressed when a window has the keyboard focus. 
        /// </summary>
        KEYUP = 0x0101,
        /// <summary>
        /// The WM_CHAR message is posted to the window with the keyboard focus when a WM_KEYDOWN message is translated by the TranslateMessage function. The WM_CHAR message contains the character code of the key that was pressed. 
        /// </summary>
        CHAR = 0x0102,
        /// <summary>
        /// The WM_DEADCHAR message is posted to the window with the keyboard focus when a WM_KEYUP message is translated by the TranslateMessage function. WM_DEADCHAR specifies a character code generated by a dead key. A dead key is a key that generates a character, such as the umlaut (double-dot), that is combined with another character to form a composite character. For example, the umlaut-O character (Ö) is generated by typing the dead key for the umlaut character, and then typing the O key. 
        /// </summary>
        DEADCHAR = 0x0103,
        /// <summary>
        /// The WM_SYSKEYDOWN message is posted to the window with the keyboard focus when the user presses the F10 key (which activates the menu bar) or holds down the ALT key and then presses another key. It also occurs when no window currently has the keyboard focus; in this case, the WM_SYSKEYDOWN message is sent to the active window. The window that receives the message can distinguish between these two contexts by checking the context code in the lParam parameter. 
        /// </summary>
        SYSKEYDOWN = 0x0104,
        /// <summary>
        /// The WM_SYSKEYUP message is posted to the window with the keyboard focus when the user releases a key that was pressed while the ALT key was held down. It also occurs when no window currently has the keyboard focus; in this case, the WM_SYSKEYUP message is sent to the active window. The window that receives the message can distinguish between these two contexts by checking the context code in the lParam parameter. 
        /// </summary>
        SYSKEYUP = 0x0105,
        /// <summary>
        /// The WM_SYSCHAR message is posted to the window with the keyboard focus when a WM_SYSKEYDOWN message is translated by the TranslateMessage function. It specifies the character code of a system character key — that is, a character key that is pressed while the ALT key is down. 
        /// </summary>
        SYSCHAR = 0x0106,
        /// <summary>
        /// The WM_SYSDEADCHAR message is sent to the window with the keyboard focus when a WM_SYSKEYDOWN message is translated by the TranslateMessage function. WM_SYSDEADCHAR specifies the character code of a system dead key — that is, a dead key that is pressed while holding down the ALT key. 
        /// </summary>
        SYSDEADCHAR = 0x0107,
        /// <summary>
        /// The WM_UNICHAR message is posted to the window with the keyboard focus when a WM_KEYDOWN message is translated by the TranslateMessage function. The WM_UNICHAR message contains the character code of the key that was pressed. 
        /// The WM_UNICHAR message is equivalent to WM_CHAR, but it uses Unicode Transformation Format (UTF)-32, whereas WM_CHAR uses UTF-16. It is designed to send or post Unicode characters to ANSI windows and it can can handle Unicode Supplementary Plane characters.
        /// </summary>
        UNICHAR = 0x0109,
        /// <summary>
        /// This message filters for keyboard messages.
        /// </summary>
        KEYLAST = 0x0108,
        /// <summary>
        /// Sent immediately before the IME generates the composition string as a result of a keystroke. A window receives this message through its WindowProc function. 
        /// </summary>
        IME_STARTCOMPOSITION = 0x010D,
        /// <summary>
        /// Sent to an application when the IME ends composition. A window receives this message through its WindowProc function. 
        /// </summary>
        IME_ENDCOMPOSITION = 0x010E,
        /// <summary>
        /// Sent to an application when the IME changes composition status as a result of a keystroke. A window receives this message through its WindowProc function. 
        /// </summary>
        IME_COMPOSITION = 0x010F,
        IME_KEYLAST = 0x010F,
        /// <summary>
        /// The WM_INITDIALOG message is sent to the dialog box procedure immediately before a dialog box is displayed. Dialog box procedures typically use this message to initialize controls and carry out any other initialization tasks that affect the appearance of the dialog box. 
        /// </summary>
        INITDIALOG = 0x0110,
        /// <summary>
        /// The WM_COMMAND message is sent when the user selects a command item from a menu, when a control sends a notification message to its parent window, or when an accelerator keystroke is translated. 
        /// </summary>
        COMMAND = 0x0111,
        /// <summary>
        /// A window receives this message when the user chooses a command from the Window menu, clicks the maximize button, minimize button, restore button, close button, or moves the form. You can stop the form from moving by filtering this out.
        /// </summary>
        SYSCOMMAND = 0x0112,
        /// <summary>
        /// The WM_TIMER message is posted to the installing thread's message queue when a timer expires. The message is posted by the GetMessage or PeekMessage function. 
        /// </summary>
        TIMER = 0x0113,
        /// <summary>
        /// The WM_HSCROLL message is sent to a window when a scroll event occurs in the window's standard horizontal scroll bar. This message is also sent to the owner of a horizontal scroll bar control when a scroll event occurs in the control. 
        /// </summary>
        HSCROLL = 0x0114,
        /// <summary>
        /// The WM_VSCROLL message is sent to a window when a scroll event occurs in the window's standard vertical scroll bar. This message is also sent to the owner of a vertical scroll bar control when a scroll event occurs in the control. 
        /// </summary>
        VSCROLL = 0x0115,
        /// <summary>
        /// The WM_INITMENU message is sent when a menu is about to become active. It occurs when the user clicks an item on the menu bar or presses a menu key. This allows the application to modify the menu before it is displayed. 
        /// </summary>
        INITMENU = 0x0116,
        /// <summary>
        /// The WM_INITMENUPOPUP message is sent when a drop-down menu or submenu is about to become active. This allows an application to modify the menu before it is displayed, without changing the entire menu. 
        /// </summary>
        INITMENUPOPUP = 0x0117,
        /// <summary>
        /// The WM_MENUSELECT message is sent to a menu's owner window when the user selects a menu item. 
        /// </summary>
        MENUSELECT = 0x011F,
        /// <summary>
        /// The WM_MENUCHAR message is sent when a menu is active and the user presses a key that does not correspond to any mnemonic or accelerator key. This message is sent to the window that owns the menu. 
        /// </summary>
        MENUCHAR = 0x0120,
        /// <summary>
        /// The WM_ENTERIDLE message is sent to the owner window of a modal dialog box or menu that is entering an idle state. A modal dialog box or menu enters an idle state when no messages are waiting in its queue after it has processed one or more previous messages. 
        /// </summary>
        ENTERIDLE = 0x0121,
        /// <summary>
        /// The WM_MENURBUTTONUP message is sent when the user releases the right mouse button while the cursor is on a menu item. 
        /// </summary>
        MENURBUTTONUP = 0x0122,
        /// <summary>
        /// The WM_MENUDRAG message is sent to the owner of a drag-and-drop menu when the user drags a menu item. 
        /// </summary>
        MENUDRAG = 0x0123,
        /// <summary>
        /// The WM_MENUGETOBJECT message is sent to the owner of a drag-and-drop menu when the mouse cursor enters a menu item or moves from the center of the item to the top or bottom of the item. 
        /// </summary>
        MENUGETOBJECT = 0x0124,
        /// <summary>
        /// The WM_UNINITMENUPOPUP message is sent when a drop-down menu or submenu has been destroyed. 
        /// </summary>
        UNINITMENUPOPUP = 0x0125,
        /// <summary>
        /// The WM_MENUCOMMAND message is sent when the user makes a selection from a menu. 
        /// </summary>
        MENUCOMMAND = 0x0126,
        /// <summary>
        /// An application sends the WM_CHANGEUISTATE message to indicate that the user interface (UI) state should be changed.
        /// </summary>
        CHANGEUISTATE = 0x0127,
        /// <summary>
        /// An application sends the WM_UPDATEUISTATE message to change the user interface (UI) state for the specified window and all its child windows.
        /// </summary>
        UPDATEUISTATE = 0x0128,
        /// <summary>
        /// An application sends the WM_QUERYUISTATE message to retrieve the user interface (UI) state for a window.
        /// </summary>
        QUERYUISTATE = 0x0129,
        /// <summary>
        /// The WM_CTLCOLORMSGBOX message is sent to the owner window of a message box before Windows draws the message box. By responding to this message, the owner window can set the text and background colors of the message box by using the given display device context handle. 
        /// </summary>
        CTLCOLORMSGBOX = 0x0132,
        /// <summary>
        /// An edit control that is not read-only or disabled sends the WM_CTLCOLOREDIT message to its parent window when the control is about to be drawn. By responding to this message, the parent window can use the specified device context handle to set the text and background colors of the edit control. 
        /// </summary>
        CTLCOLOREDIT = 0x0133,
        /// <summary>
        /// Sent to the parent window of a list box before the system draws the list box. By responding to this message, the parent window can set the text and background colors of the list box by using the specified display device context handle. 
        /// </summary>
        CTLCOLORLISTBOX = 0x0134,
        /// <summary>
        /// The WM_CTLCOLORBTN message is sent to the parent window of a button before drawing the button. The parent window can change the button's text and background colors. However, only owner-drawn buttons respond to the parent window processing this message. 
        /// </summary>
        CTLCOLORBTN = 0x0135,
        /// <summary>
        /// The WM_CTLCOLORDLG message is sent to a dialog box before the system draws the dialog box. By responding to this message, the dialog box can set its text and background colors using the specified display device context handle. 
        /// </summary>
        CTLCOLORDLG = 0x0136,
        /// <summary>
        /// The WM_CTLCOLORSCROLLBAR message is sent to the parent window of a scroll bar control when the control is about to be drawn. By responding to this message, the parent window can use the display context handle to set the background color of the scroll bar control. 
        /// </summary>
        CTLCOLORSCROLLBAR = 0x0137,
        /// <summary>
        /// A static control, or an edit control that is read-only or disabled, sends the WM_CTLCOLORSTATIC message to its parent window when the control is about to be drawn. By responding to this message, the parent window can use the specified device context handle to set the text and background colors of the static control. 
        /// </summary>
        CTLCOLORSTATIC = 0x0138,
        /// <summary>
        /// Use WM_MOUSEFIRST to specify the first mouse message. Use the PeekMessage() Function.
        /// </summary>
        MOUSEFIRST = 0x0200,
        /// <summary>
        /// The WM_MOUSEMOVE message is posted to a window when the cursor moves. If the mouse is not captured, the message is posted to the window that contains the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        MOUSEMOVE = 0x0200,
        /// <summary>
        /// The WM_LBUTTONDOWN message is posted when the user presses the left mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        LBUTTONDOWN = 0x0201,
        /// <summary>
        /// The WM_LBUTTONUP message is posted when the user releases the left mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        LBUTTONUP = 0x0202,
        /// <summary>
        /// The WM_LBUTTONDBLCLK message is posted when the user double-clicks the left mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        LBUTTONDBLCLK = 0x0203,
        /// <summary>
        /// The WM_RBUTTONDOWN message is posted when the user presses the right mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        RBUTTONDOWN = 0x0204,
        /// <summary>
        /// The WM_RBUTTONUP message is posted when the user releases the right mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        RBUTTONUP = 0x0205,
        /// <summary>
        /// The WM_RBUTTONDBLCLK message is posted when the user double-clicks the right mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        RBUTTONDBLCLK = 0x0206,
        /// <summary>
        /// The WM_MBUTTONDOWN message is posted when the user presses the middle mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        MBUTTONDOWN = 0x0207,
        /// <summary>
        /// The WM_MBUTTONUP message is posted when the user releases the middle mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        MBUTTONUP = 0x0208,
        /// <summary>
        /// The WM_MBUTTONDBLCLK message is posted when the user double-clicks the middle mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        MBUTTONDBLCLK = 0x0209,
        /// <summary>
        /// The WM_MOUSEWHEEL message is sent to the focus window when the mouse wheel is rotated. The DefWindowProc function propagates the message to the window's parent. There should be no internal forwarding of the message, since DefWindowProc propagates it up the parent chain until it finds a window that processes it.
        /// </summary>
        MOUSEWHEEL = 0x020A,
        /// <summary>
        /// The WM_XBUTTONDOWN message is posted when the user presses the first or second X button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse. 
        /// </summary>
        XBUTTONDOWN = 0x020B,
        /// <summary>
        /// The WM_XBUTTONUP message is posted when the user releases the first or second X button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        XBUTTONUP = 0x020C,
        /// <summary>
        /// The WM_XBUTTONDBLCLK message is posted when the user double-clicks the first or second X button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        XBUTTONDBLCLK = 0x020D,
        /// <summary>
        /// The WM_MOUSEHWHEEL message is sent to the focus window when the mouse's horizontal scroll wheel is tilted or rotated. The DefWindowProc function propagates the message to the window's parent. There should be no internal forwarding of the message, since DefWindowProc propagates it up the parent chain until it finds a window that processes it.
        /// </summary>
        MOUSEHWHEEL = 0x020E,
        /// <summary>
        /// Use WM_MOUSELAST to specify the last mouse message. Used with PeekMessage() Function.
        /// </summary>
        MOUSELAST = 0x020E,
        /// <summary>
        /// The WM_PARENTNOTIFY message is sent to the parent of a child window when the child window is created or destroyed, or when the user clicks a mouse button while the cursor is over the child window. When the child window is being created, the system sends WM_PARENTNOTIFY just before the CreateWindow or CreateWindowEx function that creates the window returns. When the child window is being destroyed, the system sends the message before any processing to destroy the window takes place.
        /// </summary>
        PARENTNOTIFY = 0x0210,
        /// <summary>
        /// The WM_ENTERMENULOOP message informs an application's main window procedure that a menu modal loop has been entered. 
        /// </summary>
        ENTERMENULOOP = 0x0211,
        /// <summary>
        /// The WM_EXITMENULOOP message informs an application's main window procedure that a menu modal loop has been exited. 
        /// </summary>
        EXITMENULOOP = 0x0212,
        /// <summary>
        /// The WM_NEXTMENU message is sent to an application when the right or left arrow key is used to switch between the menu bar and the system menu. 
        /// </summary>
        NEXTMENU = 0x0213,
        /// <summary>
        /// The WM_SIZING message is sent to a window that the user is resizing. By processing this message, an application can monitor the size and position of the drag rectangle and, if needed, change its size or position. 
        /// </summary>
        SIZING = 0x0214,
        /// <summary>
        /// The WM_CAPTURECHANGED message is sent to the window that is losing the mouse capture.
        /// </summary>
        CAPTURECHANGED = 0x0215,
        /// <summary>
        /// The WM_MOVING message is sent to a window that the user is moving. By processing this message, an application can monitor the position of the drag rectangle and, if needed, change its position.
        /// </summary>
        MOVING = 0x0216,
        /// <summary>
        /// Notifies applications that a power-management event has occurred.
        /// </summary>
        POWERBROADCAST = 0x0218,
        /// <summary>
        /// Notifies an application of a change to the hardware configuration of a device or the computer.
        /// </summary>
        DEVICECHANGE = 0x0219,
        /// <summary>
        /// An application sends the WM_MDICREATE message to a multiple-document interface (MDI) client window to create an MDI child window. 
        /// </summary>
        MDICREATE = 0x0220,
        /// <summary>
        /// An application sends the WM_MDIDESTROY message to a multiple-document interface (MDI) client window to close an MDI child window. 
        /// </summary>
        MDIDESTROY = 0x0221,
        /// <summary>
        /// An application sends the WM_MDIACTIVATE message to a multiple-document interface (MDI) client window to instruct the client window to activate a different MDI child window. 
        /// </summary>
        MDIACTIVATE = 0x0222,
        /// <summary>
        /// An application sends the WM_MDIRESTORE message to a multiple-document interface (MDI) client window to restore an MDI child window from maximized or minimized size. 
        /// </summary>
        MDIRESTORE = 0x0223,
        /// <summary>
        /// An application sends the WM_MDINEXT message to a multiple-document interface (MDI) client window to activate the next or previous child window. 
        /// </summary>
        MDINEXT = 0x0224,
        /// <summary>
        /// An application sends the WM_MDIMAXIMIZE message to a multiple-document interface (MDI) client window to maximize an MDI child window. The system resizes the child window to make its client area fill the client window. The system places the child window's window menu icon in the rightmost position of the frame window's menu bar, and places the child window's restore icon in the leftmost position. The system also appends the title bar text of the child window to that of the frame window. 
        /// </summary>
        MDIMAXIMIZE = 0x0225,
        /// <summary>
        /// An application sends the WM_MDITILE message to a multiple-document interface (MDI) client window to arrange all of its MDI child windows in a tile format. 
        /// </summary>
        MDITILE = 0x0226,
        /// <summary>
        /// An application sends the WM_MDICASCADE message to a multiple-document interface (MDI) client window to arrange all its child windows in a cascade format. 
        /// </summary>
        MDICASCADE = 0x0227,
        /// <summary>
        /// An application sends the WM_MDIICONARRANGE message to a multiple-document interface (MDI) client window to arrange all minimized MDI child windows. It does not affect child windows that are not minimized. 
        /// </summary>
        MDIICONARRANGE = 0x0228,
        /// <summary>
        /// An application sends the WM_MDIGETACTIVE message to a multiple-document interface (MDI) client window to retrieve the handle to the active MDI child window. 
        /// </summary>
        MDIGETACTIVE = 0x0229,
        /// <summary>
        /// An application sends the WM_MDISETMENU message to a multiple-document interface (MDI) client window to replace the entire menu of an MDI frame window, to replace the window menu of the frame window, or both. 
        /// </summary>
        MDISETMENU = 0x0230,
        /// <summary>
        /// The WM_ENTERSIZEMOVE message is sent one time to a window after it enters the moving or sizing modal loop. The window enters the moving or sizing modal loop when the user clicks the window's title bar or sizing border, or when the window passes the WM_SYSCOMMAND message to the DefWindowProc function and the wParam parameter of the message specifies the SC_MOVE or SC_SIZE value. The operation is complete when DefWindowProc returns. 
        /// The system sends the WM_ENTERSIZEMOVE message regardless of whether the dragging of full windows is enabled.
        /// </summary>
        ENTERSIZEMOVE = 0x0231,
        /// <summary>
        /// The WM_EXITSIZEMOVE message is sent one time to a window, after it has exited the moving or sizing modal loop. The window enters the moving or sizing modal loop when the user clicks the window's title bar or sizing border, or when the window passes the WM_SYSCOMMAND message to the DefWindowProc function and the wParam parameter of the message specifies the SC_MOVE or SC_SIZE value. The operation is complete when DefWindowProc returns. 
        /// </summary>
        EXITSIZEMOVE = 0x0232,
        /// <summary>
        /// Sent when the user drops a file on the window of an application that has registered itself as a recipient of dropped files.
        /// </summary>
        DROPFILES = 0x0233,
        /// <summary>
        /// An application sends the WM_MDIREFRESHMENU message to a multiple-document interface (MDI) client window to refresh the window menu of the MDI frame window. 
        /// </summary>
        MDIREFRESHMENU = 0x0234,
        /// <summary>
        /// Sent to an application when a window is activated. A window receives this message through its WindowProc function. 
        /// </summary>
        IME_SETCONTEXT = 0x0281,
        /// <summary>
        /// Sent to an application to notify it of changes to the IME window. A window receives this message through its WindowProc function. 
        /// </summary>
        IME_NOTIFY = 0x0282,
        /// <summary>
        /// Sent by an application to direct the IME window to carry out the requested command. The application uses this message to control the IME window that it has created. To send this message, the application calls the SendMessage function with the following parameters.
        /// </summary>
        IME_CONTROL = 0x0283,
        /// <summary>
        /// Sent to an application when the IME window finds no space to extend the area for the composition window. A window receives this message through its WindowProc function. 
        /// </summary>
        IME_COMPOSITIONFULL = 0x0284,
        /// <summary>
        /// Sent to an application when the operating system is about to change the current IME. A window receives this message through its WindowProc function. 
        /// </summary>
        IME_SELECT = 0x0285,
        /// <summary>
        /// Sent to an application when the IME gets a character of the conversion result. A window receives this message through its WindowProc function. 
        /// </summary>
        IME_CHAR = 0x0286,
        /// <summary>
        /// Sent to an application to provide commands and request information. A window receives this message through its WindowProc function. 
        /// </summary>
        IME_REQUEST = 0x0288,
        /// <summary>
        /// Sent to an application by the IME to notify the application of a key press and to keep message order. A window receives this message through its WindowProc function. 
        /// </summary>
        IME_KEYDOWN = 0x0290,
        /// <summary>
        /// Sent to an application by the IME to notify the application of a key release and to keep message order. A window receives this message through its WindowProc function. 
        /// </summary>
        IME_KEYUP = 0x0291,
        /// <summary>
        /// The WM_MOUSEHOVER message is posted to a window when the cursor hovers over the client area of the window for the period of time specified in a prior call to TrackMouseEvent.
        /// </summary>
        MOUSEHOVER = 0x02A1,
        /// <summary>
        /// The WM_MOUSELEAVE message is posted to a window when the cursor leaves the client area of the window specified in a prior call to TrackMouseEvent.
        /// </summary>
        MOUSELEAVE = 0x02A3,
        /// <summary>
        /// The WM_NCMOUSEHOVER message is posted to a window when the cursor hovers over the nonclient area of the window for the period of time specified in a prior call to TrackMouseEvent.
        /// </summary>
        NCMOUSEHOVER = 0x02A0,
        /// <summary>
        /// The WM_NCMOUSELEAVE message is posted to a window when the cursor leaves the nonclient area of the window specified in a prior call to TrackMouseEvent.
        /// </summary>
        NCMOUSELEAVE = 0x02A2,
        /// <summary>
        /// The WM_WTSSESSION_CHANGE message notifies applications of changes in session state.
        /// </summary>
        WTSSESSION_CHANGE = 0x02B1,
        TABLET_FIRST = 0x02c0,
        TABLET_LAST = 0x02df,
        /// <summary>
        /// An application sends a WM_CUT message to an edit control or combo box to delete (cut) the current selection, if any, in the edit control and copy the deleted text to the clipboard in CF_TEXT format. 
        /// </summary>
        CUT = 0x0300,
        /// <summary>
        /// An application sends the WM_COPY message to an edit control or combo box to copy the current selection to the clipboard in CF_TEXT format. 
        /// </summary>
        COPY = 0x0301,
        /// <summary>
        /// An application sends a WM_PASTE message to an edit control or combo box to copy the current content of the clipboard to the edit control at the current caret position. Data is inserted only if the clipboard contains data in CF_TEXT format. 
        /// </summary>
        PASTE = 0x0302,
        /// <summary>
        /// An application sends a WM_CLEAR message to an edit control or combo box to delete (clear) the current selection, if any, from the edit control. 
        /// </summary>
        CLEAR = 0x0303,
        /// <summary>
        /// An application sends a WM_UNDO message to an edit control to undo the last operation. When this message is sent to an edit control, the previously deleted text is restored or the previously added text is deleted.
        /// </summary>
        UNDO = 0x0304,
        /// <summary>
        /// The WM_RENDERFORMAT message is sent to the clipboard owner if it has delayed rendering a specific clipboard format and if an application has requested data in that format. The clipboard owner must render data in the specified format and place it on the clipboard by calling the SetClipboardData function. 
        /// </summary>
        RENDERFORMAT = 0x0305,
        /// <summary>
        /// The WM_RENDERALLFORMATS message is sent to the clipboard owner before it is destroyed, if the clipboard owner has delayed rendering one or more clipboard formats. For the content of the clipboard to remain available to other applications, the clipboard owner must render data in all the formats it is capable of generating, and place the data on the clipboard by calling the SetClipboardData function. 
        /// </summary>
        RENDERALLFORMATS = 0x0306,
        /// <summary>
        /// The WM_DESTROYCLIPBOARD message is sent to the clipboard owner when a call to the EmptyClipboard function empties the clipboard. 
        /// </summary>
        DESTROYCLIPBOARD = 0x0307,
        /// <summary>
        /// The WM_DRAWCLIPBOARD message is sent to the first window in the clipboard viewer chain when the content of the clipboard changes. This enables a clipboard viewer window to display the new content of the clipboard. 
        /// </summary>
        DRAWCLIPBOARD = 0x0308,
        /// <summary>
        /// The WM_PAINTCLIPBOARD message is sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the CF_OWNERDISPLAY format and the clipboard viewer's client area needs repainting. 
        /// </summary>
        PAINTCLIPBOARD = 0x0309,
        /// <summary>
        /// The WM_VSCROLLCLIPBOARD message is sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the CF_OWNERDISPLAY format and an event occurs in the clipboard viewer's vertical scroll bar. The owner should scroll the clipboard image and update the scroll bar values. 
        /// </summary>
        VSCROLLCLIPBOARD = 0x030A,
        /// <summary>
        /// The WM_SIZECLIPBOARD message is sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the CF_OWNERDISPLAY format and the clipboard viewer's client area has changed size. 
        /// </summary>
        SIZECLIPBOARD = 0x030B,
        /// <summary>
        /// The WM_ASKCBFORMATNAME message is sent to the clipboard owner by a clipboard viewer window to request the name of a CF_OWNERDISPLAY clipboard format.
        /// </summary>
        ASKCBFORMATNAME = 0x030C,
        /// <summary>
        /// The WM_CHANGECBCHAIN message is sent to the first window in the clipboard viewer chain when a window is being removed from the chain. 
        /// </summary>
        CHANGECBCHAIN = 0x030D,
        /// <summary>
        /// The WM_HSCROLLCLIPBOARD message is sent to the clipboard owner by a clipboard viewer window. This occurs when the clipboard contains data in the CF_OWNERDISPLAY format and an event occurs in the clipboard viewer's horizontal scroll bar. The owner should scroll the clipboard image and update the scroll bar values. 
        /// </summary>
        HSCROLLCLIPBOARD = 0x030E,
        /// <summary>
        /// This message informs a window that it is about to receive the keyboard focus, giving the window the opportunity to realize its logical palette when it receives the focus. 
        /// </summary>
        QUERYNEWPALETTE = 0x030F,
        /// <summary>
        /// The WM_PALETTEISCHANGING message informs applications that an application is going to realize its logical palette. 
        /// </summary>
        PALETTEISCHANGING = 0x0310,
        /// <summary>
        /// This message is sent by the OS to all top-level and overlapped windows after the window with the keyboard focus realizes its logical palette. 
        /// This message enables windows that do not have the keyboard focus to realize their logical palettes and update their client areas.
        /// </summary>
        PALETTECHANGED = 0x0311,
        /// <summary>
        /// The WM_HOTKEY message is posted when the user presses a hot key registered by the RegisterHotKey function. The message is placed at the top of the message queue associated with the thread that registered the hot key. 
        /// </summary>
        HOTKEY = 0x0312,
        /// <summary>
        /// The WM_PRINT message is sent to a window to request that it draw itself in the specified device context, most commonly in a printer device context.
        /// </summary>
        PRINT = 0x0317,
        /// <summary>
        /// The WM_PRINTCLIENT message is sent to a window to request that it draw its client area in the specified device context, most commonly in a printer device context.
        /// </summary>
        PRINTCLIENT = 0x0318,
        /// <summary>
        /// The WM_APPCOMMAND message notifies a window that the user generated an application command event, for example, by clicking an application command button using the mouse or typing an application command key on the keyboard.
        /// </summary>
        APPCOMMAND = 0x0319,
        /// <summary>
        /// The WM_THEMECHANGED message is broadcast to every window following a theme change event. Examples of theme change events are the activation of a theme, the deactivation of a theme, or a transition from one theme to another.
        /// </summary>
        THEMECHANGED = 0x031A,
        /// <summary>
        /// Sent when the contents of the clipboard have changed.
        /// </summary>
        CLIPBOARDUPDATE = 0x031D,
        /// <summary>
        /// The system will send a window the WM_DWMCOMPOSITIONCHANGED message to indicate that the availability of desktop composition has changed.
        /// </summary>
        DWMCOMPOSITIONCHANGED = 0x031E,
        /// <summary>
        /// WM_DWMNCRENDERINGCHANGED is called when the non-client area rendering status of a window has changed. Only windows that have set the flag DWM_BLURBEHIND.fTransitionOnMaximized to true will get this message. 
        /// </summary>
        DWMNCRENDERINGCHANGED = 0x031F,
        /// <summary>
        /// Sent to all top-level windows when the colorization color has changed. 
        /// </summary>
        DWMCOLORIZATIONCOLORCHANGED = 0x0320,
        /// <summary>
        /// WM_DWMWINDOWMAXIMIZEDCHANGE will let you know when a DWM composed window is maximized. You also have to register for this message as well. You'd have other windowd go opaque when this message is sent.
        /// </summary>
        DWMWINDOWMAXIMIZEDCHANGE = 0x0321,
        /// <summary>
        /// Sent to request extended title bar information. A window receives this message through its WindowProc function.
        /// </summary>
        GETTITLEBARINFOEX = 0x033F,
        HANDHELDFIRST = 0x0358,
        HANDHELDLAST = 0x035F,
        AFXFIRST = 0x0360,
        AFXLAST = 0x037F,
        PENWINFIRST = 0x0380,
        PENWINLAST = 0x038F,
        /// <summary>
        /// The WM_APP constant is used by applications to help define private messages, usually of the form WM_APP+X, where X is an integer value. 
        /// </summary>
        APP = 0x8000,
        /// <summary>
        /// The WM_USER constant is used by applications to help define private messages for use by private window classes, usually of the form WM_USER+X, where X is an integer value. 
        /// </summary>
        USER = 0x0400,

        /// <summary>
        /// An application sends the WM_CPL_LAUNCH message to Windows Control Panel to request that a Control Panel application be started. 
        /// </summary>
        CPL_LAUNCH = USER + 0x1000,
        /// <summary>
        /// The WM_CPL_LAUNCHED message is sent when a Control Panel application, started by the WM_CPL_LAUNCH message, has closed. The WM_CPL_LAUNCHED message is sent to the window identified by the wParam parameter of the WM_CPL_LAUNCH message that started the application. 
        /// </summary>
        CPL_LAUNCHED = USER + 0x1001,
        /// <summary>
        /// WM_SYSTIMER is a well-known yet still undocumented message. Windows uses WM_SYSTIMER for internal actions like scrolling.
        /// </summary>
        SYSTIMER = 0x118,

        /// <summary>
        /// The accessibility state has changed.
        /// </summary>
        HSHELL_ACCESSIBILITYSTATE = 11,
        /// <summary>
        /// The shell should activate its main window.
        /// </summary>
        HSHELL_ACTIVATESHELLWINDOW = 3,
        /// <summary>
        /// The user completed an input event (for example, pressed an application command button on the mouse or an application command key on the keyboard), and the application did not handle the WM_APPCOMMAND message generated by that input.
        /// If the Shell procedure handles the WM_COMMAND message, it should not call CallNextHookEx. See the Return Value section for more information.
        /// </summary>
        HSHELL_APPCOMMAND = 12,
        /// <summary>
        /// A window is being minimized or maximized. The system needs the coordinates of the minimized rectangle for the window.
        /// </summary>
        HSHELL_GETMINRECT = 5,
        /// <summary>
        /// Keyboard language was changed or a new keyboard layout was loaded.
        /// </summary>
        HSHELL_LANGUAGE = 8,
        /// <summary>
        /// The title of a window in the task bar has been redrawn.
        /// </summary>
        HSHELL_REDRAW = 6,
        /// <summary>
        /// The user has selected the task list. A shell application that provides a task list should return TRUE to prevent Windows from starting its task list.
        /// </summary>
        HSHELL_TASKMAN = 7,
        /// <summary>
        /// A top-level, unowned window has been created. The window exists when the system calls this hook.
        /// </summary>
        HSHELL_WINDOWCREATED = 1,
        /// <summary>
        /// A top-level, unowned window is about to be destroyed. The window still exists when the system calls this hook.
        /// </summary>
        HSHELL_WINDOWDESTROYED = 2,
        /// <summary>
        /// The activation has changed to a different top-level, unowned window.
        /// </summary>
        HSHELL_WINDOWACTIVATED = 4,
        /// <summary>
        /// A top-level window is being replaced. The window exists when the system calls this hook.
        /// </summary>
        HSHELL_WINDOWREPLACED = 13
    }
    /// <summary>
    /// Specific action to detect
    /// </summary>
    public enum CBT_CodeMap
    {
        /// <summary>
        /// The system is about to activate a window.
        /// <para>{ wParam : Specifies the handle to the window about to be activated. }</para>
        /// <para>{ lParam : Specifies a long pointer to a CBTACTIVATESTRUCT structure containing the handle to the active window and specifies whether the activation is changing because of a mouse click. }</para>
        /// </summary>
        HCBT_ACTIVATE = 5,
        /// <summary>
        /// The system has removed a mouse message from the system message queue. Upon receiving this hook code, a CBT application must install a WH_JOURNALPLAYBACK hook procedure in response to the mouse message.
        /// </summary>
        HCBT_CLICKSKIPPED = 6,
        /// <summary>
        /// At the time of the HCBT_CREATEWND notification, the window has been created, but its final size and position may not have been determined and its parent window may not have been established. It is possible to send messages to the newly created window, although it has not yet received WM_NCCREATE or WM_CREATE messages. It is also possible to change the position in the z-order of the newly created window by modifying the hwndInsertAfter member of the CBT_CREATEWND structure.
        /// <para>[ Important ] Detect New Window</para>
        /// <para>Ex> TaskPane in Excel</para>
        /// <para>{ wParam : Specifies the handle to the new window. }</para>
        /// <para>{ lParam : Specifies a long pointer to a CBT_CREATEWND structure containing initialization parameters for the window. The parameters include the coordinates and dimensions of the window. By changing these parameters, a CBTProc hook procedure can set the initial size and position of the window. }</para>
        /// </summary>
        HCBT_CREATEWND = 3,
        /// <summary>
        /// A window is about to be destroyed.
        /// <para>{ wParam : Specifies the handle to the window about to be destroyed. }</para>
        /// <para>{ lParam : Is undefined and must be set to zero. }</para>
        /// </summary>
        HCBT_DESTROYWND = 4,
        /// <summary>
        /// The system has removed a keyboard message from the system message queue. Upon receiving this hook code, a CBT application must install a WH_JOURNALPLAYBACK hook procedure in response to the keyboard message.
        /// </summary>
        HCBT_KEYSKIPPED = 7,
        /// <summary>
        /// A window is about to be minimized or maximized.
        /// <para>{ wParam : Specifies the handle to the window being minimized or maximized. }</para>
        /// <para>{ lParam : Specifies, in the low-order word, a show-window value (SW_) specifying the operation. For a list of show-window values, see the ShowWindow. The high-order word is undefined. }</para>
        /// </summary>
        HCBT_MINMAX = 1,
        /// <summary>
        /// A window is about to be moved or sized.
        /// <para>[ Important ] Detect sizechanged event</para>
        /// <para>{ wParam : Specifies the handle to the window to be moved or sized. }</para>
        /// <para>{ lParam : Specifies a long pointer to a RECT structure containing the coordinates of the window. 
        /// By changing the values in the structure, a CBTProc hook procedure can set the final coordinates of the window. }</para>
        /// </summary>
        HCBT_MOVESIZE = 0,
        /// <summary>
        /// The system has retrieved a WM_QUEUESYNC message from the system message queue.
        /// </summary>
        HCBT_QS = 2,
        /// <summary>
        /// The system has retrieved a WM_QUEUESYNC message from the system message queue.
        /// <para>[ Important ] How to insert a key into particular window</para>
        /// <para>{ wParam : Specifies the handle to the window gaining the keyboard focus. }</para>
        /// <para>{ lParam : Specifies the handle to the window losing the keyboard focus. }</para>
        /// </summary>
        HCBT_SETFOCUS = 9,
        /// <summary>
        /// A system command is about to be carried out. This allows a CBT application to prevent task switching by means of hot keys.
        /// </summary>
        HCBT_SYSCOMMAND = 8
    }


    

    public enum Proc_Code
    {
        /// <summary>
        /// The wParam and lParam parameters contain information about a mouse message.
        /// </summary>
        HC_ACTION = 0,
        /// <summary>
        /// The wParam and lParam parameters contain information about a mouse message, and the mouse message has not been removed from the message queue. (An application called the PeekMessage function, specifying the PM_NOREMOVE flag.)
        /// </summary>
        HC_NOREMOVE = 3
    }

    /// <summary>
    /// An application-defined or library-defined callback function used with the SetWindowsHookEx function. The system calls this function whenever an application calls the GetMessage or PeekMessage function and there is a mouse message to be processed.
    /// <para></para>The HOOKPROC type defines a pointer to this callback function. MouseProc is a placeholder for the application-defined or library-defined function name.
    /// </summary>
    /// <param name="nCode">A code that the hook procedure uses to determine how to process the message. If nCode is less than zero, the hook procedure must pass the message to the CallNextHookEx function without further processing and should return the value returned by CallNextHookEx. This parameter can be one of the following values.</param>
    /// <param name="wParam">The identifier of the mouse message.</param>
    /// <param name="lParam">A pointer to a MOUSEHOOKSTRUCT structure.</param>
    /// <returns>
    /// If nCode is less than zero, the hook procedure must return the value returned by CallNextHookEx.
    /// <para></para>If nCode is greater than or equal to zero, and the hook procedure did not process the message, it is highly recommended that you call CallNextHookEx and return the value it returns; otherwise, other applications that have installed WH_MOUSE hooks will not receive hook notifications and may behave incorrectly as a result. If the hook procedure processed the message, it may return a nonzero value to prevent the system from passing the message to the target window procedure.
    /// </returns>
    public delegate IntPtr MouseProc(Proc_Code nCode, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// An application-defined or library-defined callback function used with the SetWindowsHookEx function. The system calls this function whenever an application calls the GetMessage or PeekMessage function and there is a keyboard message (WM_KEYUP or WM_KEYDOWN) to be processed.
    /// <para></para>The HOOKPROC type defines a pointer to this callback function. KeyboardProc is a placeholder for the application-defined or library-defined function name.
    /// <para></para>[Return] If code is less than zero, the hook procedure must return the value returned by CallNextHookEx.
    /// If code is greater than or equal to zero, and the hook procedure did not process the message, it is highly recommended that you call CallNextHookEx and return the value it returns; otherwise, other applications that have installed WH_KEYBOARD hooks will not receive hook notifications and may behave incorrectly as a result. If the hook procedure processed the message, it may return a nonzero value to prevent the system from passing the message to the rest of the hook chain or the target window procedure.
    /// </summary>
    /// <param name="nCode">A code the hook procedure uses to determine how to process the message. If code is less than zero, the hook procedure must pass the message to the CallNextHookEx function without further processing and should return the value returned by CallNextHookEx. This parameter can be one of the following values.</param>
    /// <param name="wParam">The virtual-key code of the key that generated the keystroke message.</param>
    /// <param name="lParam">The repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag. For more information about the lParam parameter, see Keystroke Message Flags. The following table describes the bits of this value.</param>
    /// <returns>
    /// If code is less than zero, the hook procedure must return the value returned by CallNextHookEx.
    /// <para></para>If code is greater than or equal to zero, and the hook procedure did not process the message, it is highly recommended that you call CallNextHookEx and return the value it returns; otherwise, other applications that have installed WH_KEYBOARD hooks will not receive hook notifications and may behave incorrectly as a result. If the hook procedure processed the message, it may return a nonzero value to prevent the system from passing the message to the rest of the hook chain or the target window procedure.
    /// </returns>
    public delegate IntPtr KeyBoardProc(Proc_Code nCode, User.VK_Keys wParam, int lParam);


    /// <summary>
    /// GetWindowLong Value
    /// </summary>
    public enum GWL_Value 
    {
        /// <summary>
        /// Sets a new extended window style. 
        /// </summary>
        GWL_EXSTYLE = -20,
        /// <summary>
        /// Sets a new application instance handle. 
        /// </summary>
        GWL_HINSTANCE = -6,
        /// <summary>
        /// Sets a new identifier of the child window. The window cannot be a top-level window. 
        /// </summary>
        GWL_ID = -12,
        /// <summary>
        /// Sets a new window style. 
        /// </summary>
        GWL_STYLE = -16,
        /// <summary>
        /// Sets the user data associated with the window. This data is intended for use by the application that created the window. Its value is initially zero. 
        /// </summary>
        GWL_USERDATA = -21,
        /// <summary>
        /// Sets a new address for the window procedure. 
        /// You cannot change this attribute if the window does not belong to the same process as the calling thread.
        /// </summary>
        GWL_WNDPROC = -4
    }

    public struct CBTACTIVATESTRUCT 
	{
		public int fMouse;
		public HWND hwndActive;
	}
	public struct EVENTMSG 
	{
		public int message;
		public int paramL;
		public int paramH;
		public int time;
		public HWND hwnd;
	}
	public struct CWPSTRUCT 
	{
		public int lParam;
		public int wParam;
		public int message;
		public HWND hwnd;
	}
	public struct DEBUGHOOKINFO 
	{
		public HANDLE hModuleHook;
		public int Reserved;
		public int lParam;
		public int wParam;
		public int code;
	}
    [StructLayout(LayoutKind.Sequential)]
	public struct MOUSEHOOKSTRUCT 
	{
        /// <summary>
        /// The x- and y-coordinates of the cursor, in screen coordinates.
        /// </summary>
		public POINT pt;
        /// <summary>
        /// A handle to the window that will receive the mouse message corresponding to the mouse event.
        /// </summary>
        public IntPtr hwnd;
        /// <summary>
        /// The hit-test value. For a list of hit-test values, see the description of the WM_NCHITTEST message.
        /// </summary>
		public uint wHitTestCode;
        /// <summary>
        /// Additional information associated with the message.
        /// </summary>
        public IntPtr dwExtraInfo;
	}

    /// <summary>
    /// Contains information about a mouse event passed to a WH_MOUSE hook procedure, MouseProc.
    /// <seealso cref="MOUSEHOOKSTRUCT"/>
    /// </summary>
    public struct MOUSEHOOKSTRUCTEX
    {
        /// <summary>
        /// If the message is WM_MOUSEWHEEL, the HIWORD of this member is the wheel delta. The LOWORD is undefined and reserved. A positive value indicates that the wheel was rotated forward, away from the user; a negative value indicates that the wheel was rotated backward, toward the user. One wheel click is defined as WHEEL_DELTA, which is 120.
        /// <para></para>If the message is WM_XBUTTONDOWN, WM_XBUTTONUP, WM_XBUTTONDBLCLK, WM_NCXBUTTONDOWN, WM_NCXBUTTONUP, or WM_NCXBUTTONDBLCLK, the HIWORD of mouseData specifies which X button was pressed or released, and the LOWORD is undefined and reserved. This member can be one or more of the following values. Otherwise, mouseData is not used.
        /// </summary>
        public uint mouseData;

        /// <summary>
        /// 현재 저장된 구조체의 WheelDelta 값을 받아온다.
        /// </summary>
        /// <returns>
        /// 양수 : Wheel Up Counts
        /// <para></para>
        /// 음수 : Wheel Down Counts
        /// </returns>
        public int Get_WheelDelta()
        {
            return (int)((mouseData & 0xFFFF0000) >> 4);
        }
    }

    public struct MINMAXINFO 
	{
		public POINT ptReserved;
		public POINT ptMaxSize;
		public POINT ptMaxPosition;
		public POINT ptMinTrackSize;
		public POINT ptMaxTrackSize;
	}
	public struct COPYDATASTRUCT 
	{
		public int dwData;
		public int cbData;
		public int lpData;
	}
	public struct WINDOWPOS 
	{
		public HWND hwnd;
		public HWND hwndInsertAfter;
		public int x;
		public int y;
		public int cx;
		public int cy;
		public int flags;
	}
	public struct ACCEL 
	{
		public byte fVirt;
		public short key;
		public short cmd;
	}
	public struct PAINTSTRUCT 
	{
		public HDC hdc;
		public int fErase;
		public RECT rcPaint;
		public int fRestore;
		public int fIncUpdate;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=32)] public byte rgbReserved;
	}
	public struct CREATESTRUCT 
	{
		public int lpCreateParams;
		public HANDLE hInstance;
		public HANDLE hMenu;
		public HWND hwndParent;
		public int cy;
		public int cx;
		public int y;
		public int x;
		public int style;
		public string lpszName;
		public string lpszClass;
		public int ExStyle;
	}
	public struct CBT_CREATEWND 
	{
		public CREATESTRUCT lpcs;
		public HWND hwndInsertAfter;
	}
	public struct WINDOWPLACEMENT 
	{
        public WINDOWPLACEMENT(WINDOWPLACEMENT_Flags _flags, WINDOWPLACEMENT_showCmd _showCmd,
            POINT _ptMinPosition, POINT _ptMaxPosition, RECT _rcNormalPosition, RECT _rcDevice)
        {
            Length = 0;
            flags = _flags;
            showCmd = _showCmd;
            ptMinPosition = _ptMinPosition;
            ptMaxPosition = _ptMaxPosition;
            rcNormalPosition = _rcNormalPosition;
            rcDevice = _rcDevice;
        }
        /// <summary>
        /// The length of the structure, in bytes. Before calling the GetWindowPlacement or SetWindowPlacement functions, set this member to sizeof(WINDOWPLACEMENT)
        /// </summary>
        public uint Length;
        /// <summary>
        /// The flags that control the position of the minimized window and the method by which the window is restored. 
        /// </summary>
		public WINDOWPLACEMENT_Flags flags;
        /// <summary>
        /// The current show state of the window.
        /// </summary>
		public WINDOWPLACEMENT_showCmd showCmd;
        /// <summary>
        /// The coordinates of the window's upper-left corner when the window is minimized.
        /// </summary>
		public POINT ptMinPosition;
        /// <summary>
        /// The coordinates of the window's upper-left corner when the window is maximized.
        /// </summary>
		public POINT ptMaxPosition;
        /// <summary>
        /// The window's coordinates when the window is in the restored position.
        /// </summary>
		public RECT rcNormalPosition;
        /// <summary>
        /// Need to find out. This might be a parent window's RECT.
        /// </summary>
        public RECT rcDevice;
    }

    public enum WINDOWPLACEMENT_Flags
    {
        /// <summary>
        /// If the calling thread and the thread that owns the window are attached to different input queues, the system posts the request to the thread that owns the window. This prevents the calling thread from blocking its execution while other threads process the request. 
        /// </summary>
        WPF_ASYNCWINDOWPLACEMENT = 0x0004,
        /// <summary>
        /// The restored window will be maximized, regardless of whether it was maximized before it was minimized. This setting is only valid the next time the window is restored. It does not change the default restoration behavior. 
        /// <para>[Restrict] This flag is only valid when the SW_SHOWMINIMIZED value is specified for the showCmd member.</para>
        /// </summary>
        WPF_RESTORETOMAXIMIZED = 0x0002,
        /// <summary>
        /// The coordinates of the minimized window may be specified. 
        /// <para></para>[Restrict] This flag must be specified if the coordinates are set in the ptMinPosition member.
        /// </summary>
        WPF_SETMINPOSITION = 0x0001
    }

    public enum WINDOWPLACEMENT_showCmd
    {
        /// <summary>
        /// Hides the window and activates another window. 
        /// </summary>
        SW_HIDE = 0,
        /// <summary>
        /// Maximizes the specified window. 
        /// </summary>
        SW_MAXIMIZE = 3,
        /// <summary>
        /// Minimizes the specified window and activates the next top-level window in the z-order. 
        /// </summary>
        SW_MINIMIZE = 6,
        /// <summary>
        /// Activates and displays the window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when restoring a minimized window.
        /// </summary>
        SW_RESTORE = 9,
        /// <summary>
        /// Activates the window and displays it in its current size and position. 
        /// </summary>
        SW_SHOW = 5,
        //SW_SHOWMAXIMIZED = 3, //SW_MAXIMIZE와 동일하므로 생략
        /// <summary>
        /// Activates the window and displays it as a minimized window. 
        /// </summary>
        SW_SHOWMINIMIZED = 2,
        /// <summary>
        /// Displays the window as a minimized window. 
        /// <para></para>This value is similar to SW_SHOWMINIMIZED, except the window is not activated.
        /// </summary>
        SW_SHOWMINNOACTIVE = 7,
        /// <summary>
        /// Displays the window in its current size and position. 
        /// <para></para>This value is similar to SW_SHOW, except the window is not activated.
        /// </summary>
        SW_SHOWNA = 8,
        /// <summary>
        /// Displays a window in its most recent size and position. 
        /// <para></para>This value is similar to SW_SHOWNORMAL, except the window is not activated.
        /// </summary>
        SW_SHOWNOACTIVATE = 4,
        /// <summary>
        /// Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time. 
        /// </summary>
        SW_SHOWNORMAL = 1
    }

    public struct MEASUREITEMSTRUCT 
	{
		public int CtlType;
		public int CtlID;
		public int itemID;
		public int itemWidth;
		public int itemHeight;
		public int itemData;
	}
	public struct DRAWITEMSTRUCT 
	{
		public int CtlType;
		public int CtlID;
		public int itemID;
		public int itemAction;
		public int itemState;
		public HWND hwndItem;
		public HDC hdc;
		public RECT rcItem;
		public int itemData;
	}
	public struct DELETEITEMSTRUCT 
	{
		public int CtlType;
		public int CtlID;
		public int itemID;
		public HWND hwndItem;
		public int itemData;
	}
	public struct COMPAREITEMSTRUCT 
	{
		public int CtlType;
		public int CtlID;
		public HWND hwndItem;
		public int itemID1;
		public int itemData1;
		public int itemID2;
		public int itemData2;
	}
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
	public struct MSG 
	{
		public HWND hwnd;
		public WM message;
		public int wParam;
		public int lParam;
		public int time;
		public POINT pt;

        public MSG(MSG Ref)
        {
            hwnd = Ref.hwnd;
            message = Ref.message;
            wParam = Ref.wParam;
            lParam = Ref.lParam;
            time = Ref.time;
            pt = Ref.pt;
        }
	}

    /// <summary>
    /// PeekMessage/GetMessage 사용시 message가 SYSKEYDOWN일 때 사용된다.
    /// <para></para>SYSKEYDOWN : ALT키가 선택되면 SYSKEYDOWN으로 설정된다.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Meesage_Lparam
    {
        /// <summary>
        /// The repeat count for the current message. The value is the number of times the keystroke is autorepeated as a result of the user holding down the key. If the keystroke is held long enough, multiple messages are sent. However, the repeat count is not cumulative.
        /// </summary>
        public int RepeatedCount;
        /// <summary>
        /// The scan code. The value depends on the OEM.
        /// </summary>
        public User.ScanCodeShort ScanCode;
        /// <summary>
        /// Indicates whether the key is an extended key, such as the right-hand ALT and CTRL keys that appear on an enhanced 101- or 102-key keyboard. The value is 1 if it is an extended key; otherwise, it is 0.
        /// </summary>
        public bool IsExtendedKey;
        /// <summary>
        /// Reserved; do not use.
        /// </summary>
        public int NotUsed;
        /// <summary>
        /// The context code. The value is 1 if the ALT key is down while the key is pressed; it is 0 if the WM_SYSKEYDOWN message is posted to the active window because no window has the keyboard focus.
        /// </summary>
        public bool IsAltPressed;
        /// <summary>
        /// The previous key state. The value is 1 if the key is down before the message is sent, or it is 0 if the key is up.
        /// </summary>
        public bool PreviousKeystate;
        /// <summary>
        /// The transition state. The value is always 0 for a WM_SYSKEYDOWN message.
        /// <para></para> KEYUP : 1
        /// <para></para> KEYDOWN : 1
        /// </summary>
        public int TransitionState;
        public Meesage_Lparam(int LPARAM)
        {
            RepeatedCount = LPARAM & 0xFFFF;
            ScanCode = (User.ScanCodeShort)((LPARAM & 0xFF0000) >> 16);
            IsExtendedKey = ((LPARAM & 0x1000000) >> 24) == 1;
            NotUsed = (LPARAM & 0x2000000) >> 25;
            IsAltPressed = ((LPARAM & 0x20000000) >> 29) == 1;
            PreviousKeystate = ((LPARAM & 0x40000000) >> 30) == 1;
            TransitionState = (int)((LPARAM & 0x80000000) >> 31);
        }
    }

    public struct WNDCLASS 
	{
		public int style;
		public int lpfnwndproc;
		public int cbClsextra;
		public int cbWndExtra2;
		public HANDLE hInstance;
		public HANDLE hIcon;
		public HANDLE hCursor;
		public HANDLE hbrBackground;
		public string lpszMenuName;
		public string lpszClassName;
	}
	public struct DLGTEMPLATE 
	{
		public int style;
		public int dwExtendedStyle;
		public short cdit;
		public short x;
		public short y;
		public short cx;
		public short cy;
	}
	public struct DLGITEMTEMPLATE 
	{
		public int style;
		public int dwExtendedStyle;
		public short x;
		public short y;
		public short cx;
		public short cy;
		public short id;
	}
	public struct MENUITEMTEMPLATEHEADER 
	{
		public short versionNumber;
		public short offset;
	}
	public struct MENUITEMTEMPLATE 
	{
		public short mtOption;
		public short mtID;
		public byte mtString;
	}
	public struct ICONINFO 
	{
		public int fIcon;
		public int xHotspot;
		public int yHotspot;
		public HANDLE hbmMask;
		public HANDLE hbmColor;
	}
	public struct MDICREATESTRUCT 
	{
		public string szClass;
		public string szTitle;
		public HWND hOwner;
		public int x;
		public int y;
		public int cx;
		public int cy;
		public int style;
		public int lParam;
	}
	public struct CLIENTCREATESTRUCT 
	{
		public HANDLE hWindowMenu;
		public int idFirstChild;
	}
	public struct MULTIKEYHELP 
	{
		public int mkSize;
		public byte mkKeylist;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst=253)] public string szKeyphrase; 
	}
	public struct HELPWININFO 
	{
		public int wStructSize;
		public int x;
		public int y;
		public int dx;
		public int dy;
		public int wMax;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst=2)] public string rgchMember;
	}
	public struct DDEACK 
	{
		public short bAppReturnCode;
		public short Reserved;
		public short fbusy;
		public short fack;
	}
	public struct DDEADVISE 
	{
		public short Reserved;
		public short fDeferUpd;
		public short fAckReq;
		public short cfFormat;
	}
	public struct DDEDATA 
	{
		public short unused;
		public short fresponse;
		public short fRelease;
		public short Reserved;
		public short fAckReq;
		public short cfFormat;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=1)] public byte Value;
	}
	public struct DDEPOKE 
	{
		public short unused;
		public short fRelease;
		public short fReserved;
		public short cfFormat;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=1)] public byte Value;
	}
	public struct DDELN 
	{
		public short unused;
		public short fRelease;
		public short fDeferUpd;
		public short fAckReq;
		public short cfFormat;
	}
	public struct DDEUP 
	{
		public short unused;
		public short fAck;
		public short fRelease;
		public short fReserved;
		public short fAckReq;
		public short cfFormat;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=1)] public byte rgb;
	}
	public struct HSZPAIR 
	{
		public HANDLE hszSvc;
		public HANDLE hszTopic;
	}
	public struct SECURITY_QUALITY_OF_SERVICE 
	{
		public int Length;
		public short Impersonationlevel;
		public short ContextTrackingMode;
		public int EffectiveOnly;
	}
	public struct CONVCONTEXT 
	{
		public int cb;
		public int wFlags;
		public int wCountryID;
		public int iCodePage;
		public int dwLangID;
		public int dwSecurity;
		public SECURITY_QUALITY_OF_SERVICE qos;
	}
	public struct CONVINFO 
	{
		public int cb;
		public HANDLE hUser;
		public HANDLE hConvPartner;
		public HANDLE hszSvcPartner;
		public HANDLE hszServiceReq;
		public HANDLE hszTopic;
		public HANDLE hszItem;
		public int wFmt;
		public int wType;
		public int wStatus;
		public int wConvst;
		public int wLastError;
		public HANDLE hConvList;
		public CONVCONTEXT ConvCtxt;
		public HWND hwnd;
		public HWND hwndPartner;
	}
	public struct DDEML_MSG_HOOK_DATA 
	{ 
		public int uiLo; 
		public int uiHi;
		public int cbData; 
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=8)] public int Data; 
	}
	public struct MONMSGSTRUCT 
	{
		public int cb;
		public HWND hwndTo;
		public int dwTime;
		public HANDLE htask;
		public int wMsg;
		public int wParam;
		public int lParam;
		public DDEML_MSG_HOOK_DATA dmhd; 
	}
	public struct MONCBSTRUCT 
	{
		public int cb;
		public int dwTime;
		public HANDLE htask;
		public int dwRet;
		public int wType;
		public int wFmt;
		public HANDLE hConv;
		public HANDLE hsz1;
		public HANDLE hsz2;
		public HANDLE hData;
		public int dwData1;
		public int dwData2;
		public CONVCONTEXT cc; 
		public int cbData; 
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=8)] public int Data; 
	}
	public struct MONHSZSTRUCT 
	{
		public int cb;
		public int fsAction; 
		public int dwTime;
		public HANDLE hsz;
		public HANDLE htask;
		public byte str;
	}
	public struct MONERRSTRUCT 
	{
		public int cb;
		public int wLastError;
		public int dwTime;
		public HANDLE htask;
	}
	public struct MONLINKSTRUCT 
	{
		public int cb;
		public int dwTime;
		public HANDLE htask;
		public int fEstablished;
		public int fNoData;
		public HANDLE hszSvc;
		public HANDLE hszTopic;
		public HANDLE hszItem;
		public int wFmt;
		public int fServer;
		public HANDLE hConvServer;
		public HANDLE hConvClient;
	}
	public struct MONCONVSTRUCT 
	{
		public int cb;
		public int fConnect;
		public int dwTime;
		public HANDLE htask;
		public HANDLE hszSvc;
		public HANDLE hszTopic;
		public HANDLE hConvClient; 
		public HANDLE hConvServer; 
	}
	public struct DRAWTEXTPARAMS 
	{
		public int cbSize;
		public int iTabLength;
		public int iLeftMargin;
		public int iRightMargin;
		public int uiLengthDrawn;
	}
	public struct MENUITEMINFO 
	{
		public int cbSize;
		public int fMask;
		public int fType;
		public int fState;
		public int wID;
		public HANDLE hSubMenu;
		public HANDLE hbmpChecked;
		public HANDLE hbmpUnchecked;
		public int dwItemData;
		public string dwTypeData;
		public int cch;
	}
	public struct SCROLLINFO 
	{
		public int cbSize;
		public int fMask;
		public int nMin;
		public int nMax;
		public int nPage;
		public int nPos;
		public int nTrackPos;
	}
	public struct MSGBOXPARAMS 
	{
		public int cbSize;
		public HWND hwndOwner;
		public HANDLE hInstance;
		public string lpszText;
		public string lpszCaption;
		public int dwStyle;
		public string lpszIcon;
		public int dwContextHelpId;
		public int lpfnMsgBoxCallback;
		public int dwLanguageId;
	}
	public struct WNDCLASSEX 
	{
		public int cbSize;
		public int style;
		public int lpfnWndProc;
		public int cbClsExtra;
		public int cbWndExtra;
		public HANDLE hInstance;
		public HANDLE hIcon;
		public HANDLE hCursor;
		public HANDLE hbrBackground;
		public string lpszMenuName;
		public string lpszClassName;
		public HANDLE hIconSm;
	}
	public struct TPMPARAMS 
	{
		public int cbSize;
		public RECT rcExclude;
	}
	public struct BROWSEINFO 
	{
		public HWND hwndOwner;
		public int pIDLRoot;
		public int pszDisplayName;
		public int lpszTitle;
		public int ulFlags;
		public int lpfnCallback;
		public int lParam;
		public int iImage;
	}

	public abstract class ComCtl
	{
		[DllImport("COMCTL32")] public static extern int ImageList_AddIcon(HANDLE himl, HANDLE hIcon);
		[DllImport("COMCTL32")] public static extern int ImageList_Create(int MinCx, int MinCy, int flags, int cInitial, int cGrow);
		[DllImport("COMCTL32")] public static extern int ImageList_Draw(HANDLE hIMAGELIST, int ImgIndex, HWND hdcDest, int xDest, int yDest, int lStyle);
		[DllImport("COMCTL32")] public static extern int ImageList_GetIcon(HANDLE hIMAGELIST, int ImgIndex, HANDLE hbmMask);
		[DllImport("COMCTL32")] public static extern int InitCommonControls();
	}

	public abstract class Ole
	{
		[DllImport("ole32")] public static extern int OleInitialize(IntPtr vbNullString);
		[DllImport("ole32")] public static extern void CoTaskMemFree(HANDLE hMem);
		[DllImport("ole32")] public static extern void OleUninitialize();
	}
	
	public class User
	{
        public static IntPtr StrToPointer(object _Structure)
        {
            IntPtr Str_Handle = Marshal.AllocHGlobal(Marshal.SizeOf(_Structure));
            Marshal.StructureToPtr(_Structure, Str_Handle, true);
            return Str_Handle;
        }
		[DllImport("advapi32")] public static extern int SetServiceBits(HANDLE hServiceStatus, int dwServiceBits, int bSetBitsOn, int bUpdateImmediately);
		[DllImport("kernel32")] public static extern int SetSystemTimeAdjustment(int dwTimeAdjustment, int bTimeAdjustmentDisabled);
		[DllImport("mpr")] public static extern int WNetGetUniversalName(string lpLocalPath, int dwInfoLevel, StringBuilder lpBuffer, ref int lpBufferSize);
		[DllImport("user32")] public static extern int ActivateKeyboardLayout(HANDLE hKL, int flags);
        /// <summary>
        /// Calculates the required size of the window rectangle, based on the desired client-rectangle size. The window rectangle can then be passed to the CreateWindow function to create a window whose client area is the desired size.
        /// <para></para>To specify an extended window style, use the AdjustWindowRectEx function.
        /// </summary>
        /// <param name="lpRect">A pointer to a RECT structure that contains the coordinates of the top-left and bottom-right corners of the desired client area. When the function returns, the structure contains the coordinates of the top-left and bottom-right corners of the window to accommodate the desired client area.</param>
        /// <param name="dwStyle">The window style of the window whose required size is to be calculated. Note that you cannot specify the WS_OVERLAPPED style.</param>
        /// <param name="bMenu">Indicates whether the window has a menu.</param>
        /// <returns>
        /// If the function succeeds, the return value is true.
        /// If the function fails, the return value is false. To get extended error information, call GetLastError.
        /// </returns>
		[return : MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32")] 
        public static extern bool AdjustWindowRect(ref RECT lpRect, Window_Styles dwStyle, bool bMenu);
        /// <summary>
        /// Calculates the required size of the window rectangle, based on the desired size of the client rectangle. The window rectangle can then be passed to the CreateWindowEx function to create a window whose client area is the desired size.
        /// </summary>
        /// <param name="lpRect">A pointer to a RECT structure that contains the coordinates of the top-left and bottom-right corners of the desired client area. When the function returns, the structure contains the coordinates of the top-left and bottom-right corners of the window to accommodate the desired client area.</param>
        /// <param name="dsStyle">The window style of the window whose required size is to be calculated. Note that you cannot specify the WS_OVERLAPPED style.</param>
        /// <param name="bMenu">Indicates whether the window has a menu.</param>
        /// <param name="dwEsStyle">The extended window style of the window whose required size is to be calculated.</param>
        /// <returns>
        /// If the function succeeds, the return value is true.
        /// If the function fails, the return value is false. To get extended error information, call GetLastError.
        /// </returns>
		[return : MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32")] 
        public static extern bool AdjustWindowRectEx(ref RECT lpRect, Window_Styles dsStyle, bool bMenu, Extended_Window_Styles dwEsStyle);
		[DllImport("user32")] public static extern int AnyPopup();
        /// <summary>
        /// Appends a new item to the end of the specified menu bar, drop-down menu, submenu, or shortcut menu. You can use this function to specify the content, appearance, and behavior of the menu item. 
        /// </summary>
        /// <param name="hMenu">A handle to the menu bar, drop-down menu, submenu, or shortcut menu to be changed. </param>
        /// <param name="uFlags">Controls the appearance and behavior of the new menu item. This parameter can be a combination of the following values.</param>
        /// <param name="uIDNewItem">The identifier of the new menu item or, if the uFlags parameter is set to MF_POPUP, a handle to the drop-down menu or submenu. </param>
        /// <param name="lpNewItem">The content of the new menu item. The interpretation of lpNewItem depends on whether the uFlags parameter includes the following values. </param>
        /// <returns>
        /// If the function succeeds, the return value is true.
        /// If the function fails, the return value is false. To get extended error information, call GetLastError.
        /// </returns>
		[return : MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32")] 
        public static extern bool AppendMenu(HANDLE hMenu, MenuFeatures uFlags, int uIDNewItem, IntPtr lpNewItem);

        public enum MenuFeatures
        {
            /// <summary>
            /// Uses a bitmap as the menu item. The lpNewItem parameter contains a handle to the bitmap.
            /// </summary>
            MF_BITMAP = 0x00000004,
            /// <summary>
            /// Places a check mark next to the menu item. If the application provides check-mark bitmaps (see SetMenuItemBitmaps, this flag displays the check-mark bitmap next to the menu item.
            /// </summary>
            MF_CHECKED = 0x00000008,
            /// <summary>
            /// Disables the menu item so that it cannot be selected, but the flag does not gray it.
            /// </summary>
            MF_DISABLED = 0x00000002,
            /// <summary>
            /// Enables the menu item so that it can be selected, and restores it from its grayed state.
            /// </summary>
            MF_ENABLED = 0x00000000,
            /// <summary>
            /// Disables the menu item and grays it so that it cannot be selected.
            /// </summary>
            MF_GRAYED = 0x00000001,
            /// <summary>
            /// Functions the same as the MF_MENUBREAK flag for a menu bar. For a drop-down menu, submenu, or shortcut menu, the new column is separated from the old column by a vertical line.
            /// </summary>
            MF_MENUBARBREAK = 0x00000020,
            /// <summary>
            /// Places the item on a new line (for a menu bar) or in a new column (for a drop-down menu, submenu, or shortcut menu) without separating columns.
            /// </summary>
            MF_MENUBREAK = 0x00000040,
            /// <summary>
            /// Specifies that the item is an owner-drawn item. Before the menu is displayed for the first time, the window that owns the menu receives a WM_MEASUREITEM message to retrieve the width and height of the menu item. The WM_DRAWITEM message is then sent to the window procedure of the owner window whenever the appearance of the menu item must be updated.
            /// </summary>
            MF_OWNERDRAW = 0x00000100,
            /// <summary>
            /// Specifies that the menu item opens a drop-down menu or submenu. The uIDNewItem parameter specifies a handle to the drop-down menu or submenu. This flag is used to add a menu name to a menu bar, or a menu item that opens a submenu to a drop-down menu, submenu, or shortcut menu.
            /// </summary>
            MF_POPUP = 0x00000010,
            /// <summary>
            /// Draws a horizontal dividing line. This flag is used only in a drop-down menu, submenu, or shortcut menu. The line cannot be grayed, disabled, or highlighted. The lpNewItem and uIDNewItem parameters are ignored.
            /// </summary>
            MF_SEPARATOR = 0x00000800,
            /// <summary>
            /// Specifies that the menu item is a text string; the lpNewItem parameter is a pointer to the string.
            /// </summary>
            MF_STRING = 0x00000000,
            /// <summary>
            /// Does not place a check mark next to the item (default). If the application supplies check-mark bitmaps (see SetMenuItemBitmaps), this flag displays the clear bitmap next to the menu item. 
            /// </summary>
            MF_UNCHECKED = 0x00000000
        }

        [DllImport("user32")] public static extern int ArrangeIconicWindows(HWND hwnd);
		[DllImport("user32")] public static extern int AttachThreadInput(int idAttach, int idAttachTo, int fAttach);
		[DllImport("user32")] public static extern int BeginDeferWindowPos(int nNumWindows);
		[DllImport("user32")] public static extern int BeginPaint(HWND hwnd, ref PAINTSTRUCT lpPaint);
        /// <summary>
        /// Brings the specified window to the top of the Z order. If the window is a top-level window, it is activated. If the window is a child window, the top-level parent window associated with the child window is activated.
        /// </summary>
        /// <param name="hwnd">A handle to the window to bring to the top of the Z order.</param>
        /// <returns>
        /// If the function succeeds, the return value is true.
        /// If the function fails, the return value is false. To get extended error information, call GetLastError.
        /// </returns>
		[return : MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32")] 
        public static extern bool BringWindowToTop(HWND hwnd);
		[DllImport("user32")] public static extern int BroadcastSystemMessage(int dw, ref int pdw, int un, int wParam, int lParam);
		[DllImport("user32")] public static extern int CallMsgFilter(ref MSG lpMsg, int ncode);
        /// <summary>
        /// Passes the hook information to the next hook procedure in the current hook chain. A hook procedure can call this function either before or after processing the hook information.
        /// <para></para>[ Return ] __ This value is returned by the next hook procedure in the chain. The current hook procedure must also return this value. The meaning of the return value depends on the hook type. For more information, see the descriptions of the individual hook procedures.
        /// </summary>
        /// <param name="hHook">This parameter is ignored</param>
        /// <param name="ncode">The hook code passed to the current hook procedure. The next hook procedure uses this code to determine how to process the hook information</param>
        /// <param name="wParam">The wParam value passed to the current hook procedure. The meaning of this parameter depends on the type of hook associated with the current hook chain</param>
        /// <param name="lParam">The lParam value passed to the current hook procedure. The meaning of this parameter depends on the type of hook associated with the current hook chain</param>
        /// <returns>This value is returned by the next hook procedure in the chain. The current hook procedure must also return this value. The meaning of the return value depends on the hook type. For more information, see the descriptions of the individual hook procedures.</returns>
		[DllImport("user32")] public static extern IntPtr CallNextHookEx(HANDLE hHook, CBT_CodeMap ncode, IntPtr wParam, IntPtr lParam);
        /// <summary>
        /// Passes the hook information to the next hook procedure in the current hook chain. A hook procedure can call this function either before or after processing the hook information.
        /// <para></para>[ Return ] __ This value is returned by the next hook procedure in the chain. The current hook procedure must also return this value. The meaning of the return value depends on the hook type. For more information, see the descriptions of the individual hook procedures.
        /// </summary>
        /// <param name="hHook">This parameter is ignored</param>
        /// <param name="ncode">The hook code passed to the current hook procedure. The next hook procedure uses this code to determine how to process the hook information</param>
        /// <param name="wParam">The wParam value passed to the current hook procedure. The meaning of this parameter depends on the type of hook associated with the current hook chain</param>
        /// <param name="lParam">The lParam value passed to the current hook procedure. The meaning of this parameter depends on the type of hook associated with the current hook chain</param>
        /// <returns>This value is returned by the next hook procedure in the chain. The current hook procedure must also return this value. The meaning of the return value depends on the hook type. For more information, see the descriptions of the individual hook procedures.</returns>
        [DllImport("user32")] public static extern IntPtr CallNextHookEx(HANDLE hHook, WindowHook ncode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32")] public static extern int CallWindowProc(int lpPrevWndFunc, HWND hwnd, int Msg, int wParam, int lParam);
		[DllImport("user32")] public static extern int ChangeClipboardChain(HWND hwnd, HWND hwndNext);
		[DllImport("user32")] public static extern int ChangeMenu(HANDLE hMenu, int cmd, string lpszNewItem, int cmdInsert, int flags);
		[DllImport("user32")] public static extern int CharLowerBuff(string lpsz, int cchLength);
		[DllImport("user32")] public static extern int CharToOem(string lpszSrc, string lpszDst);
		[DllImport("user32")] public static extern int CharToOemBuff(string lpszSrc, string lpszDst, int cchDstLength);
		[DllImport("user32")] public static extern int CharUpperBuff(string lpsz, int cchLength);
		[DllImport("user32")] public static extern int CheckDlgButton(HANDLE hDlg, int nIDButton, int wCheck);
		[DllImport("user32")] public static extern int CheckMenuItem(HANDLE hMenu, int wIDCheckItem, int wCheck);
		[DllImport("user32")] public static extern int CheckMenuRadioItem(HANDLE hMenu, int un1, int un2, int un3, int un4);
		[DllImport("user32")] public static extern int CheckRadioButton(HANDLE hDlg, int nIDFirstButton, int nIDLastButton, int nIDCheckButton);
        /// <summary>
        /// Determines which, if any, of the child windows belonging to a parent window contains the specified point. The search is restricted to immediate child windows. Grandchildren, and deeper descendant windows are not searched.
        /// <para></para>To skip certain child windows, use the ChildWindowFromPointEx function.
        /// <para></para>[Return] The return value is a handle to the child window that contains the point, even if the child window is hidden or disabled. If the point lies outside the parent window, the return value is NULL. If the point is within the parent window but not within any child window, the return value is a handle to the parent window.
        /// </summary>
        /// <param name="hwndParent">A handle to the parent window.</param>
        /// <param name="Point">A structure that defines the client coordinates, relative to hWndParent, of the point to be checked.</param>
        /// <returns></returns>
        [DllImport("user32")] public static extern IntPtr ChildWindowFromPoint(HWND hwndParent, POINT Point);
        /// <summary>
        /// Determines which, if any, of the child windows belonging to the specified parent window contains the specified point. The function can ignore invisible, disabled, and transparent child windows. The search is restricted to immediate child windows. Grandchildren and deeper descendants are not searched.
        /// <para></para>[Return] The return value is a handle to the first child window that contains the point and meets the criteria specified by uFlags. If the point is within the parent window but not within any child window that meets the criteria, the return value is a handle to the parent window. If the point lies outside the parent window or if the function fails, the return value is NULL.
        /// </summary>
        /// <param name="hwnd">A handle to the parent window.</param>
        /// <param name="pt">A structure that defines the client coordinates (relative to hwndParent) of the point to be checked.</param>
        /// <param name="un">The child windows to be skipped.</param>
        /// <returns></returns>
        [DllImport("user32")] public static extern IntPtr ChildWindowFromPointEx(HWND hwnd, WINAPI.POINT pt, ChildWindowConstants un);

        public enum  ChildWindowConstants
        {
            /// <summary>
            /// Does not skip any child windows 
            /// </summary>
            CWP_ALL = 0x0000,
            /// <summary>
            /// Skips disabled child windows 
            /// </summary>
            CWP_SKIPDISABLED = 0x0002,
            /// <summary>
            /// Skips invisible child windows 
            /// </summary>
            CWP_SKIPINVISIBLE = 0x0001,
            /// <summary>
            /// Skips transparent child windows 
            /// </summary>
            CWP_SKIPTRANSPARENT = 0x0004
        }
        /// <summary>
        /// The ClientToScreen function converts the client-area coordinates of a specified point to screen coordinates.
        /// [Important] 항상 열려있는 미니 팝업창을 만들 때 유용할 듯
        /// </summary>
        /// <param name="hwnd">A handle to the window whose client area is used for the conversion.</param>
        /// <param name="lpPoint">A pointer to a POINT structure that contains the client coordinates to be converted. The new screen coordinates are copied into this structure if the function succeeds.</param>
        /// <returns>
        /// If the function succeeds, the return value is true.
        /// If the function fails, the return value is false. To get extended error information, call GetLastError.
        /// </returns>
        [return : MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32")] 
        public static extern bool ClientToScreen(HWND hwnd, ref POINT lpPoint);
		[DllImport("user32")] public static extern int ClipCursor(ref RECT lpRect);
		[DllImport("user32")] public static extern int CloseClipboard();
		[DllImport("user32")] public static extern int CloseDesktop(HANDLE hDesktop);
        /// <summary>
        /// Minimize Window (Not destroyed)
        /// </summary>
        /// <param name="hwnd">Window Handle</param>
        /// <returns></returns>
		[DllImport("user32")] public static extern int CloseWindow(HWND hwnd);
		[DllImport("user32")] public static extern int CloseWindowStation(HANDLE hWinSta);
		[DllImport("user32")] public static extern int CopyAcceleratorTable(HANDLE hAccelSrc, ACCEL[] lpAccelDst, int cAccelEntries);
		[DllImport("user32")] public static extern int CopyCursor(HANDLE hcur);
		[DllImport("user32")] public static extern int CopyIcon(HANDLE hIcon);
		[DllImport("user32")] public static extern int CopyImage(HANDLE handle, int un1, int n1, int n2, int un2);
		[DllImport("user32")] public static extern int CopyRect(ref RECT lpDestRect, ref RECT lpSourceRect);
		[DllImport("user32")] public static extern int CountClipboardFormats();
		[DllImport("user32")] public static extern int CreateAcceleratorTable(ref ACCEL lpaccl, int cEntries);
		[DllImport("user32")] public static extern int CreateCaret(HWND hwnd, HANDLE hBitmap, int nWidth, int nHeight);
		[DllImport("user32")] public static extern int CreateCursor(HANDLE hInstance, int nXhotspot, int nYhotspot, int nWidth, int nHeight, IntPtr lpANDbitPlane, IntPtr lpXORbitPlane);
		[DllImport("user32")] public static extern int CreateDesktop(string lpszDesktop, string lpszDevice, ref DEVMODE pDevmode, int dwFlags, int dwDesiredAccess, ref SECURITY_ATTRIBUTES lpsa);
		[DllImport("user32")] public static extern int CreateDialogIndirectParam(HANDLE hInstance, ref DLGTEMPLATE lpTemplate, HWND hwndParent, ref int lpDialogFunc, int dwInitParam);
		[DllImport("user32")] public static extern int CreateDialogParam(HANDLE hInstance, string lpName, HWND hwndParent, ref int lpDialogFunc, int lParamInit);
		[DllImport("user32")] public static extern int CreateIcon(HANDLE hInstance, int nWidth, int nHeight, Byte nPlanes, Byte nBitsPixel, Byte lpANDbits, Byte lpXORbits);
		[DllImport("user32")] public static extern int CreateIconFromResource(Byte presbits, int dwResSize, int fIcon, int dwVer);
		[DllImport("user32")] public static extern int CreateIconIndirect(ref ICONINFO piconinfo);
        /// <summary>
        /// Creates a multiple-document interface (MDI) child window.
        /// <para></para>[설명] 다중 윈도우 환경을 만들기 위해서 사용된다.
        /// <para></para>[반환]  If the function succeeds, the return value is the handle to the created window. If the function fails, the return value is NULL.
        /// </summary>
        /// <param name="lpClassName">The window class of the MDI child window. The class name must have been registered by a call to the RegisterClassEx function.</param>
        /// <param name="lpWindowName">The window name. The system displays the name in the title bar of the child window.</param>
        /// <param name="dwStyle">The style of the MDI child window. If the MDI client window is created with the MDIS_ALLCHILDSTYLES window style, this parameter can be any combination of the window styles listed in the Window Styles page. Otherwise, this parameter is limited to one or more of the following values.</param>
        /// <param name="x">The initial horizontal position, in client coordinates, of the MDI child window. If this parameter is CW_USEDEFAULT ((int)0x80000000), the MDI child window is assigned the default horizontal position.</param>
        /// <param name="y">The initial vertical position, in client coordinates, of the MDI child window. If this parameter is CW_USEDEFAULT, the MDI child window is assigned the default vertical position.</param>
        /// <param name="nWidth">The initial width, in device units, of the MDI child window. If this parameter is CW_USEDEFAULT, the MDI child window is assigned the default width.</param>
        /// <param name="nHeight">The initial height, in device units, of the MDI child window. If this parameter is set to CW_USEDEFAULT, the MDI child window is assigned the default height.</param>
        /// <param name="hwndParent">A handle to the MDI client window that will be the parent of the new MDI child window.</param>
        /// <param name="hInstance">A handle to the instance of the application creating the MDI child window.</param>
        /// <param name="lParam">An application-defined value.</param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the created window.
        /// If the function fails, the return value is NULL.
        /// </returns>
        [DllImport("user32")]
        public static extern IntPtr CreateMDIWindow(string lpClassName, string lpWindowName, WindowStyles_MDI dwStyle,
            int x, int y, int nWidth, int nHeight, HWND hwndParent, HANDLE hInstance, int lParam);

        /// <summary>
        /// The style of the MDI child window.
        /// </summary>
        public enum WindowStyles_MDI : long
        {
            /// <summary>
            /// Creates an MDI child window that is initially minimized. 
            /// </summary>
            WS_MINIMIZE = 0x20000000L,
            /// <summary>
            /// Creates an MDI child window that is initially maximized. 
            /// </summary>
            WS_MAXIMIZE = 0x01000000L,
            /// <summary>
            /// Creates an MDI child window that has a horizontal scroll bar. 
            /// </summary>
            WS_HSCROLL = 0x00100000L,
            /// <summary>
            /// Creates an MDI child window that has a vertical scroll bar. 
            /// </summary>
            WS_VSCROLL = 0x00200000L
        }

        [DllImport("user32")] public static extern int CreateMenu();
        /// <summary>
        /// Creates a drop-down menu, submenu, or shortcut menu. The menu is initially empty. You can insert or append menu items by using the InsertMenuItem function. You can also use the InsertMenu function to insert menu items and the AppendMenu function to append menu items.
        /// <para></para>[Retrun] If the function succeeds, the return value is a handle to the newly created menu.
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly created menu.
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </returns>
		[DllImport("user32")] public static extern IntPtr CreatePopupMenu();
        /// <summary>
        /// Creates an overlapped, pop-up, or child window with an extended window style; otherwise, this function is identical to the CreateWindow function. For more information about creating a window and for full descriptions of the other parameters of CreateWindowEx, see CreateWindow.
        /// <para>Reference Site : https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createwindowexa </para>
        /// </summary>
        /// <param name="dwExStyle">The extended window style of the window being created. 
        /// <para>Use "Extended_Window_Styles" Dictionary in User Class</para></param>
        /// <param name="lpClassName">A null-terminated string or a class atom created by a previous call to the RegisterClass or RegisterClassEx function. The atom must be in the low-order word of lpClassName; the high-order word must be zero. If lpClassName is a string, it specifies the window class name. The class name can be any name registered with RegisterClass or RegisterClassEx, provided that the module that registers the class is also the module that creates the window. The class name can also be any of the predefined system class names.</param>
        /// <param name="lpWindowName">The window name. If the window style specifies a title bar, the window title pointed to by lpWindowName is displayed in the title bar. When using CreateWindow to create controls, such as buttons, check boxes, and static controls, use lpWindowName to specify the text of the control. When creating a static control with the SS_ICON style, use lpWindowName to specify the icon name or identifier. To specify an identifier, use the syntax "#num".</param>
        /// <param name="dwStyle">The style of the window being created. This parameter can be a combination of the window style values, plus the control styles indicated in the Remarks section.
        /// <para>Use "Window_Styles" Dictionary in User Class</para></param>
        /// <param name="x">The initial horizontal position of the window. For an overlapped or pop-up window, the x parameter is the initial x-coordinate of the window's upper-left corner, in screen coordinates. For a child window, x is the x-coordinate of the upper-left corner of the window relative to the upper-left corner of the parent window's client area. If x is set to CW_USEDEFAULT, the system selects the default position for the window's upper-left corner and ignores the y parameter. CW_USEDEFAULT is valid only for overlapped windows; if it is specified for a pop-up or child window, the x and y parameters are set to zero.</param>
        /// <param name="y">The initial vertical position of the window. For an overlapped or pop-up window, the y parameter is the initial y-coordinate of the window's upper-left corner, in screen coordinates. For a child window, y is the initial y-coordinate of the upper-left corner of the child window relative to the upper-left corner of the parent window's client area. For a list box y is the initial y-coordinate of the upper-left corner of the list box's client area relative to the upper-left corner of the parent window's client area. If an overlapped window is created with the WS_VISIBLE style bit set and the x parameter is set to CW_USEDEFAULT, then the y parameter determines how the window is shown. If the y parameter is CW_USEDEFAULT, then the window manager calls ShowWindow with the SW_SHOW flag after the window has been created. If the y parameter is some other value, then the window manager calls ShowWindow with that value as the nCmdShow parameter.</param>
        /// <param name="nWidth">The width, in device units, of the window. For overlapped windows, nWidth is the window's width, in screen coordinates, or CW_USEDEFAULT. If nWidth is CW_USEDEFAULT, the system selects a default width and height for the window; the default width extends from the initial x-coordinates to the right edge of the screen; the default height extends from the initial y-coordinate to the top of the icon area. CW_USEDEFAULT is valid only for overlapped windows; if CW_USEDEFAULT is specified for a pop-up or child window, the nWidth and nHeight parameter are set to zero.</param>
        /// <param name="nHeight">The height, in device units, of the window. For overlapped windows, nHeight is the window's height, in screen coordinates. If the nWidth parameter is set to CW_USEDEFAULT, the system ignores nHeight.</param>
        /// <param name="hwndParent">A handle to the parent or owner window of the window being created. To create a child window or an owned window, supply a valid window handle. This parameter is optional for pop-up windows. To create a message-only window, supply HWND_MESSAGE or a handle to an existing message-only window.</param>
        /// <param name="hMenu">A handle to a menu, or specifies a child-window identifier, depending on the window style. For an overlapped or pop-up window, hMenu identifies the menu to be used with the window; it can be NULL if the class menu is to be used. For a child window, hMenu specifies the child-window identifier, an integer value used by a dialog box control to notify its parent about events. The application determines the child-window identifier; it must be unique for all child windows with the same parent window.</param>
        /// <param name="hInstance">A handle to the instance of the module to be associated with the window.</param>
        /// <param name="lpParam">Pointer to a value to be passed to the window through the CREATESTRUCT structure (lpCreateParams member) pointed to by the lParam param of the WM_CREATE message. This message is sent to the created window by this function before it returns. If an application calls CreateWindow to create a MDI client window, lpParam should point to a CLIENTCREATESTRUCT structure. If an MDI client window calls CreateWindow to create an MDI child window, lpParam should point to a MDICREATESTRUCT structure. lpParam may be NULL if no additional data is needed.</param>
        /// <returns>Type: HWND. If the function succeeds, the return value is a handle to the new window. If the function fails, the return value is NULL. To get extended error information, call GetLastError.</returns>
		[DllImport("user32")] public static extern int CreateWindowEx(
            Extended_Window_Styles dwExStyle, 
            string lpClassName, 
            string lpWindowName,
            Window_Styles dwStyle, 
            int x, 
            int y, 
            int nWidth, 
            int nHeight, 
            HWND hwndParent, 
            HANDLE hMenu, 
            HANDLE hInstance, 
            IntPtr lpParam);
		[DllImport("user32")] public static extern int DdeAbandonTransaction(int idInst, HANDLE hConv, int idTransaction);
		[DllImport("user32")] public static extern int DdeAccessData(HANDLE hData, ref int pcbDataSize);
		[DllImport("user32")] public static extern int DdeAddData(HANDLE hData, Byte pSrc, int cb, int cbOff);
		[DllImport("user32")] public static extern int DdeClientTransaction(Byte pData, int cbData, HANDLE hConv, HANDLE hszItem, int wFmt, int wType, int dwTimeout, ref int pdwResult);
		[DllImport("user32")] public static extern int DdeCmpStringHandles(HANDLE hsz1, HANDLE hsz2);
		[DllImport("user32")] public static extern int DdeConnect(int idInst, HANDLE hszService, HANDLE hszTopic, ref CONVCONTEXT pCC);
		[DllImport("user32")] public static extern int DdeConnectList(int idInst, HANDLE hszService, HANDLE hszTopic, HANDLE hConvList, ref CONVCONTEXT pCC);
		[DllImport("user32")] public static extern int DdeCreateDataHandle(int idInst, Byte pSrc, int cb, int cbOff, HANDLE hszItem, int wFmt, int afCmd);
		[DllImport("user32")] public static extern int DdeCreateStringHandle(int idInst, string psz, int iCodePage);
		[DllImport("user32")] public static extern int DdeDisconnect(HANDLE hConv);
		[DllImport("user32")] public static extern int DdeDisconnectList(HANDLE hConvList);
		[DllImport("user32")] public static extern int DdeEnableCallback(int idInst, HANDLE hConv, int wCmd);
		[DllImport("user32")] public static extern int DdeFreeDataHandle(HANDLE hData);
		[DllImport("user32")] public static extern int DdeFreeStringHandle(int idInst, HANDLE hsz);
		[DllImport("user32")] public static extern int DdeGetData(HANDLE hData, Byte pDst, int cbMax, int cbOff);
		[DllImport("user32")] public static extern int DdeGetLastError(int idInst);
		[DllImport("user32")] public static extern int DdeImpersonateClient(HANDLE hConv);
		[DllImport("user32")] public static extern int DdeKeepStringHandle(int idInst, HANDLE hsz);
		[DllImport("user32")] public static extern int DdeNameService(int idInst, HANDLE hsz1, HANDLE hsz2, int afCmd);
		[DllImport("user32")] public static extern int DdePostAdvise(int idInst, HANDLE hszTopic, HANDLE hszItem);
		[DllImport("user32")] public static extern int DdeQueryConvInfo(HANDLE hConv, int idTransaction, ref CONVINFO pConvInfo);
		[DllImport("user32")] public static extern int DdeQueryNextServer(HANDLE hConvList, HANDLE hConvPrev);
		[DllImport("user32")] public static extern int DdeQueryString(int idInst, HANDLE hsz, string psz, int cchMax, int iCodePage);
		[DllImport("user32")] public static extern int DdeReconnect(HANDLE hConv);
		[DllImport("user32")] public static extern int DdeSetQualityOfService(HWND hwndClient, ref SECURITY_QUALITY_OF_SERVICE pqosNew, ref SECURITY_QUALITY_OF_SERVICE pqosPrev);
		[DllImport("user32")] public static extern int DdeSetUserHandle(HANDLE hConv, int id, HANDLE hUser);
		[DllImport("user32")] public static extern int DdeUnaccessData(HANDLE hData);
		[DllImport("user32")] public static extern int DdeUninitialize(int idInst);
		[DllImport("user32")] public static extern int DefDlgProc(HANDLE hDlg, int wMsg, int wParam, int lParam);
		[DllImport("user32")] public static extern int DefFrameProc(HWND hwnd, HWND hwndMDIClient, int wMsg, int wParam, int lParam);
        /// <summary>
        /// Provides default processing for any window message that the window procedure of a multiple-document interface (MDI) child window does not process. A window message not processed by the window procedure must be passed to the DefMDIChildProc function, not to the DefWindowProc function.
        /// <para></para>[Return] The return value specifies the result of the message processing and depends on the message.
        /// </summary>
        /// <param name="hwnd">A handle to the MDI child window.</param>
        /// <param name="wMsg">The message to be processed.</param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">Additional message-specific information.</param>
        /// <returns>The return value specifies the result of the message processing and depends on the message.</returns>
		[DllImport("user32")] public static extern int DefMDIChildProc(HWND hwnd, int wMsg, int wParam, int lParam);
        /// <summary>
        /// Calls the default window procedure to provide default processing for any window messages that an application does not process. This function ensures that every message is processed. DefWindowProc is called with the same parameters received by the window procedure.
        /// </summary>
        /// <param name="hwnd">A handle to the window procedure that received the message.</param>
        /// <param name="wMsg">The message.</param>
        /// <param name="wParam">Additional message information. The content of this parameter depends on the value of the Msg parameter.</param>
        /// <param name="lParam">Additional message information. The content of this parameter depends on the value of the Msg parameter.</param>
        /// <returns></returns>
		[DllImport("user32")] public static extern int DefWindowProc(HWND hwnd, int wMsg, int wParam, int lParam);
		[DllImport("user32")] public static extern int DeferWindowPos(HANDLE hWinPosInfo, HWND hwnd, HWND hwndInsertAfter, int x, int y, int cx, int cy, int wFlags);
		[DllImport("user32")] public static extern int DeleteMenu(HANDLE hMenu, int nPosition, int wFlags);
		[DllImport("user32")] public static extern int DestroyAcceleratorTable(HANDLE haccel);
		[DllImport("user32")] public static extern int DestroyCaret();
        /// <summary>
        /// Destroys a cursor and frees any memory the cursor occupied. Do not use this function to destroy a shared cursor.
        /// </summary>
        /// <param name="hCursor">A handle to the cursor to be destroyed. The cursor must not be in use.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
		[return : MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32")] public static extern bool DestroyCursor(HANDLE hCursor);
		[DllImport("user32")] public static extern int DestroyIcon(HANDLE hIcon);
		[DllImport("user32")] public static extern int DestroyMenu(HANDLE hMenu);
        /// <summary>
        /// Destroy Window
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
		[DllImport("user32")] public static extern IntPtr DestroyWindow(HWND hwnd);
		[DllImport("user32")] public static extern int DialogBoxIndirectParam(HANDLE hInstance, DLGTEMPLATE hDialogTemplate, HWND hwndParent, ref int lpDialogFunc, int dwInitParam);
        /// <summary>
        /// Dispatches a message to a window procedure. It is typically used to dispatch a message retrieved by the GetMessage function.
        /// <para></para>[Return] The return value specifies the value returned by the window procedure. Although its meaning depends on the message being dispatched, the return value generally is ignored.
        /// </summary>
        /// <param name="lpMsg">A pointer to a structure that contains the message.</param>
        /// <returns>The return value specifies the value returned by the window procedure. Although its meaning depends on the message being dispatched, the return value generally is ignored.</returns>
		[DllImport("user32")] public static extern int DispatchMessage(ref MSG lpMsg);
		[DllImport("user32")] public static extern int DlgDirList(HANDLE hDlg, string lpPathSpec, int nIDListBox, int nIDStaticPath, int wFileType);
		[DllImport("user32")] public static extern int DlgDirListComboBox(HANDLE hDlg, string lpPathSpec, int nIDComboBox, int nIDStaticPath, int wFileType);
		[DllImport("user32")] public static extern int DlgDirSelectComboBoxEx(HWND hwndDlg, string lpszPath, int cbPath, int idComboBox);
		[DllImport("user32")] public static extern int DlgDirSelectEx(HWND hwndDlg, string lpszPath, int cbPath, int idListBox);
        /// <summary>
        /// Captures the mouse and tracks its movement until the user releases the left button, presses the ESC key, or moves the mouse outside the drag rectangle around the specified point. The width and height of the drag rectangle are specified by the SM_CXDRAG and SM_CYDRAG values returned by the GetSystemMetrics function.
        /// </summary>
        /// <param name="hwnd">A handle to the window receiving mouse input.</param>
        /// <param name="pt">Initial position of the mouse, in screen coordinates. The function determines the coordinates of the drag rectangle by using this point.</param>
        /// <returns>
        /// If the user moved the mouse outside of the drag rectangle while holding down the left button, the return value is nonzero.
        /// If the user did not move the mouse outside of the drag rectangle while holding down the left button, the return value is zero.
        /// </returns>
        [return : MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32")] 
        public static extern bool DragDetect(HWND hwnd, POINT pt);

        [Obsolete("관련된 정보 찾아볼 수 없음")]
		[DllImport("user32")] 
        public static extern int DragObject(HWND hwnd1, HWND hwnd2, int un, int dw, HANDLE hCursor);

		[DllImport("user32")] 
        public static extern int DrawAnimatedRects(HWND hwnd, int idAni, ref RECT lprcFrom, ref RECT lprcTo);

		[DllImport("user32")] 
        public static extern int DrawCaption(HWND hwnd, HWND hdc, ref RECT pcRect, int un);

		[DllImport("user32")] 
        public static extern int DrawEdge(HDC hdc, ref RECT qrc, int edge, int grfFlags);

		[DllImport("user32")] 
        public static extern int DrawFocusRect(HDC hdc, ref RECT lpRect);

		[DllImport("user32")] 
        public static extern int DrawFrameControl(HWND hdc, ref RECT lpRect, int un1, int un2);

		[DllImport("user32")] 
        public static extern int DrawIcon(HDC hdc, int x, int y, HANDLE hIcon);

		[DllImport("user32")] 
        public static extern int DrawIconEx(HDC hdc, int xLeft, int yTop, HANDLE hIcon, int cxWidth, int cyWidth, int istepIfAniCur, HANDLE hbrFlickerFreeDraw, int diFlags);
		
        [DllImport("user32")] 
        public static extern int DrawMenuBar(HWND hwnd);

		[DllImport("user32")] 
        public static extern int DrawState(HWND hdc, HANDLE hBrush, ref int lpDrawStateProc, int lParam, int wParam, int n1, int n2, int n3, int n4, int un);

        /// <summary>
        /// The DrawText function draws formatted text in the specified rectangle. 
        /// It formats the text according to the specified method (expanding tabs, justifying characters, breaking lines, and so forth).
        /// <para></para>To specify additional formatting options, use the DrawTextEx function.
        /// </summary>
        /// <param name="hdc">A handle to the device context.</param>
        /// <param name="lpStr">A pointer to the string that specifies the text to be drawn. If the nCount parameter is -1, the string must be null-terminated.
        /// <para></para>If uFormat includes DT_MODIFYSTRING, the function could add up to four additional characters to this string. The buffer containing the string should be large enough to accommodate these extra characters.
        /// </param>
        /// <param name="nCount">The length, in characters, of the string. If nCount is -1, then the lpchText parameter is assumed to be a pointer to a null-terminated string and DrawText computes the character count automatically.</param>
        /// <param name="lpRect">A pointer to a RECT structure that contains the rectangle (in logical coordinates) in which the text is to be formatted.</param>
        /// <param name="wFormat">The method of formatting the text. This parameter can be one or more of the following values.</param>
        /// <returns>
        /// If the function succeeds, the return value is the height of the text in logical units. If DT_VCENTER or DT_BOTTOM is specified, the return value is the offset from lpRect->top to the bottom of the drawn text
        /// If the function fails, the return value is zero.
        /// </returns>
        [DllImport("user32")] 
        public static extern int DrawText(HDC hdc, string lpStr, int nCount, ref RECT lpRect, DrawText_Format wFormat);

        public enum DrawText_Format
        {
            /// <summary>
            /// Justifies the text to the bottom of the rectangle. This value is used only with the DT_SINGLELINE value. 
            /// </summary>
            DT_BOTTOM,
            /// <summary>
            /// Determines the width and height of the rectangle. If there are multiple lines of text, DrawText uses the width of the rectangle pointed to by the lpRect parameter and extends the base of the rectangle to bound the last line of text. If the largest word is wider than the rectangle, the width is expanded. If the text is less than the width of the rectangle, the width is reduced. If there is only one line of text, DrawText modifies the right side of the rectangle so that it bounds the last character in the line. In either case, DrawText returns the height of the formatted text but does not draw the text. 
            /// </summary>
            DT_CALCRECT,
            /// <summary>
            /// Centers text horizontally in the rectangle.
            /// </summary>
            DT_CENTER,
            /// <summary>
            /// Duplicates the text-displaying characteristics of a multiline edit control. Specifically, the average character width is calculated in the same manner as for an edit control, and the function does not display a partially visible last line. 
            /// </summary>
            DT_EDITCONTROL,
            /// <summary>
            /// For displayed text, if the end of a string does not fit in the rectangle, it is truncated and ellipses are added. If a word that is not at the end of the string goes beyond the limits of the rectangle, it is truncated without ellipses. 
            /// <para></para>The string is not modified unless the DT_MODIFYSTRING flag is specified.
            /// <para></para>Compare with DT_PATH_ELLIPSIS and DT_WORD_ELLIPSIS.
            /// </summary>
            DT_END_ELLIPSIS,
            /// <summary>
            /// Expands tab characters. The default number of characters per tab is eight. The DT_WORD_ELLIPSIS, DT_PATH_ELLIPSIS, and DT_END_ELLIPSIS values cannot be used with the DT_EXPANDTABS value.
            /// </summary>
            DT_EXPANDTABS,
            /// <summary>
            /// Includes the font external leading in line height. Normally, external leading is not included in the height of a line of text. 
            /// </summary>
            DT_EXTERNALLEADING,
            /// <summary>
            /// Ignores the ampersand (&) prefix character in the text. The letter that follows will not be underlined, but other mnemonic-prefix characters are still processed. 
            /// </summary>
            DT_HIDEPREFIX,
            /// <summary>
            /// Uses the system font to calculate text metrics. 
            /// </summary>
            DT_INTERNAL,
            /// <summary>
            /// Aligns text to the left. 
            /// </summary>
            DT_LEFT,
            /// <summary>
            /// Modifies the specified string to match the displayed text. This value has no effect unless DT_END_ELLIPSIS or DT_PATH_ELLIPSIS is specified.
            /// </summary>
            DT_MODIFYSTRING,
            /// <summary>
            /// Draws without clipping. DrawText is somewhat faster when DT_NOCLIP is used. 
            /// </summary>
            DT_NOCLIP,
            /// <summary>
            /// Prevents a line break at a DBCS (double-wide character string), so that the line breaking rule is equivalent to SBCS strings. For example, this can be used in Korean windows, for more readability of icon labels. This value has no effect unless DT_WORDBREAK is specified. 
            /// </summary>
            DT_NOFULLWIDTHCHARBREAK,
            /// <summary>
            /// Turns off processing of prefix characters. Normally, DrawText interprets the mnemonic-prefix character & as a directive to underscore the character that follows, and the mnemonic-prefix characters && as a directive to print a single &. By specifying DT_NOPREFIX, this processing is turned off.
            /// </summary>
            DT_NOPREFIX,
            /// <summary>
            /// For displayed text, replaces characters in the middle of the string with ellipses so that the result fits in the specified rectangle. If the string contains backslash (\) characters, DT_PATH_ELLIPSIS preserves as much as possible of the text after the last backslash. 
            /// <para></para>The string is not modified unless the DT_MODIFYSTRING flag is specified.
            /// <para></para>Compare with DT_END_ELLIPSIS and DT_WORD_ELLIPSIS.
            /// </summary>
            DT_PATH_ELLIPSIS,
            /// <summary>
            /// Draws only an underline at the position of the character following the ampersand (&) prefix character. Does not draw any other characters in the string.
            /// </summary>
            DT_PREFIXONLY,
            /// <summary>
            /// Aligns text to the right. 
            /// </summary>
            DT_RIGHT,
            /// <summary>
            /// Layout in right-to-left reading order for bidirectional text when the font selected into the hdc is a Hebrew or Arabic font. The default reading order for all text is left-to-right. 
            /// </summary>
            DT_RTLREADING,
            /// <summary>
            /// Displays text on a single line only. Carriage returns and line feeds do not break the line. 
            /// </summary>
            DT_SINGLELINE,
            /// <summary>
            /// Sets tab stops. Bits 15-8 (high-order byte of the low-order word) of the uFormat parameter specify the number of characters for each tab. The default number of characters per tab is eight. The DT_CALCRECT, DT_EXTERNALLEADING, DT_INTERNAL, DT_NOCLIP, and DT_NOPREFIX values cannot be used with the DT_TABSTOP value.
            /// </summary>
            DT_TABSTOP,
            /// <summary>
            /// Justifies the text to the top of the rectangle.
            /// </summary>
            DT_TOP,
            /// <summary>
            /// Centers text vertically. This value is used only with the DT_SINGLELINE value.
            /// </summary>
            DT_VCENTER,
            /// <summary>
            /// Breaks words. Lines are automatically broken between words if a word would extend past the edge of the rectangle specified by the lpRect parameter. A carriage return-line feed sequence also breaks the line.
            /// <para></para>If this is not specified, output is on one line.
            /// </summary>
            DT_WORDBREAK,
            /// <summary>
            /// Truncates any word that does not fit in the rectangle and adds ellipses. 
            /// <para></para>Compare with DT_END_ELLIPSIS and DT_PATH_ELLIPSIS.
            /// </summary>
            DT_WORD_ELLIPSIS
        }
        /// <summary>
        /// The DrawTextEx function draws formatted text in the specified rectangle.
        /// </summary>
        /// <param name="hdc">A handle to the device context in which to draw.</param>
        /// <param name="lpchText">A pointer to the string that contains the text to draw. If the cchText parameter is -1, the string must be null-terminated.
        /// <para></para>If dwDTFormat includes DT_MODIFYSTRING, the function could add up to four additional characters to this string. The buffer containing the string should be large enough to accommodate these extra characters.</param>
        /// <param name="cchText">The length of the string pointed to by lpchText. If cchText is -1, then the lpchText parameter is assumed to be a pointer to a null-terminated string and DrawTextEx computes the character count automatically.</param>
        /// <param name="lprc">A pointer to a RECT structure that contains the rectangle, in logical coordinates, in which the text is to be formatted.</param>
        /// <param name="format">The formatting options. This parameter can be one or more of the following values.</param>
        /// <param name="lpDrawTextParams">A pointer to a DRAWTEXTPARAMS structure that specifies additional formatting options. This parameter can be NULL.</param>
        /// <returns>
        /// If the function succeeds, the return value is the text height in logical units. If DT_VCENTER or DT_BOTTOM is specified, the return value is the offset from lprc->top to the bottom of the drawn text
        /// If the function fails, the return value is zero.
        /// </returns>
		[DllImport("user32")] 
        public static extern int DrawTextEx(HWND hdc, string lpchText, int cchText, ref RECT lprc, DrawText_Format format, ref tagDRAWTEXTPARAMS lpDrawTextParams);
		
        public struct tagDRAWTEXTPARAMS
        {
            public uint cbSize;
            public int iTabLength;
            public int iLeftMargin;
            public int iRightMargin;
            public uint uiLengthDrawn;
        }
        [DllImport("user32")] public static extern int EmptyClipboard();
		[DllImport("user32")] public static extern int EnableMenuItem(HANDLE hMenu, int wIDEnableItem, int wEnable);
		[DllImport("user32")] public static extern int EnableScrollBar(HWND hwnd, int wSBflags, int wArrows);
		[DllImport("user32")] public static extern int EnableWindow(HWND hwnd, bool fEnable);
		[DllImport("user32")] public static extern int EndDeferWindowPos(HANDLE hWinPosInfo);
		[DllImport("user32")] public static extern int EndDialog(HANDLE hDlg, int nResult);
		[DllImport("user32")] public static extern int EndPaint(HWND hwnd, ref PAINTSTRUCT lpPaint);

        /// <summary>
        /// Enumerates the child windows that belong to the specified parent window by passing the handle to each child window, in turn, to an application-defined callback function. EnumChildWindows continues until the last child window is enumerated or the callback function returns FALSE.
        /// </summary>
        /// <param name="parentHandle">A handle to the parent window whose child windows are to be enumerated. If this parameter is NULL, this function is equivalent to EnumWindows.</param>
        /// <param name="callback">A pointer to an application-defined callback function. For more information, see EnumChildProc.</param>
        /// <param name="lParam">An application-defined value to be passed to the callback function.</param>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32")] public static extern bool EnumChildWindows(IntPtr parentHandle, Win32Callback callback, IntPtr lParam);
        [DllImport("user32")] public static extern int EnumClipboardFormats(int wFormat);
		[DllImport("user32")] public static extern int EnumDesktopWindows(HANDLE hDesktop, ref int lpfn, int lParam);
		[DllImport("user32")] public static extern int EnumDesktops(HANDLE hwinsta, ref int lpEnumFunc, int lParam);
		[DllImport("user32")] public static extern int EnumProps(HWND hwnd, ref int lpEnumFunc);
		[DllImport("user32")] public static extern int EnumPropsEx(HWND hwnd, ref int lpEnumFunc, int lParam);
		[DllImport("user32")] public static extern int EnumThreadWindows(int dwThreadId, ref int lpfn, int lParam);
		[DllImport("user32")] public static extern int EnumWindowStations(int lpEnumFunc, int lParam);
		[DllImport("user32")] public static extern int EnumWindows(int lpEnumFunc, int lParam);

        public static IEnumerable<IntPtr> EnumAllWindows(IntPtr hwnd, string childClassName)
        {
            List<IntPtr> children = GetChildWindows(hwnd);
            if (children == null)
                yield break;
            foreach (IntPtr child in children)
            {
                if (GetWinClass(child) == childClassName)
                    yield return child;
                foreach (var childchild in EnumAllWindows(child, childClassName))
                    yield return childchild;
            }
        }
        public static List<IntPtr> GetChildWindows(IntPtr parent)
        {
            List<IntPtr> result = new List<IntPtr>();
            GCHandle listHandle = GCHandle.Alloc(result);
            try
            {
                WINAPI.Win32Callback childProc = new WINAPI.Win32Callback(EnumWindow);
                User.EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
            }
            finally
            {
                if (listHandle.IsAllocated)
                    listHandle.Free();
            }
            return result;
        }
        /// <summary>
        /// 핸들에 해당하는 윈도우의 이름을 받아온다.
        /// </summary>
        /// <param name="hwnd">이름을 얻을 윈도우의 이름</param>
        /// <returns></returns>
        public static string GetWinClass(IntPtr hwnd)
        {
            if (hwnd == IntPtr.Zero) // 핸들이 IntPtr.Zero인 윈도우는 없다.
                return null;
            StringBuilder classname = new StringBuilder(100);
            int result = User.GetClassName(hwnd, classname, classname.Capacity);
            if (result != 0)
                return classname.ToString();
            return null;
        }
        private static bool EnumWindow(IntPtr handle, IntPtr pointer)
        {
            GCHandle gch = GCHandle.FromIntPtr(pointer);
            List<IntPtr> list = gch.Target as List<IntPtr>;
            if (list == null)
                throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
            list.Add(handle);
            return true;
        }

        [DllImport("user32")] public static extern int EqualRect(ref RECT lpRect1, ref RECT lpRect2);
		[DllImport("user32")] public static extern int ExcludeUpdateRgn(HDC hdc, HWND hwnd);
		[DllImport("user32")] public static extern int ExitWindows(int dwReserved, int uReturnCode);
		[DllImport("user32")] public static extern int ExitWindowsEx(int uFlags, int dwReserved);
        /// <summary>
        /// The FillRect function fills a rectangle by using the specified brush. This function includes the left and top borders, but excludes the right and bottom borders of the rectangle.
        /// <para></para>[Return] If the function succeeds, the return value is a handle to the newly created menu.
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </summary>
        /// <param name="hdc">A handle to the device context.</param>
        /// <param name="lpRect">A pointer to a RECT structure that contains the logical coordinates of the rectangle to be filled.</param>
        /// <param name="hBrush">A handle to the brush used to fill the rectangle.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly created menu.
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </returns>
        [return : MarshalAs(UnmanagedType.Bool)]
		[DllImport("user32")] 
        public static extern bool FillRect(HDC hdc, ref RECT lpRect, HANDLE hBrush);
        /// <summary>
        /// Retrieves a handle to the top-level window whose class name and window name match the specified strings. This function does not search child windows. This function does not perform a case-sensitive search.
        /// <para></para>To search child windows, beginning with a specified child window, use the FindWindowEx function.
        /// <para></para>[Return] If the function succeeds, the return value is a handle to the window that has the specified class name and window name.
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </summary>
        /// <param name="lpClassName">
        /// The class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function. The atom must be in the low-order word of lpClassName; the high-order word must be zero.
        /// <para></para>The class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function. The atom must be in the low-order word of lpClassName; the high-order word must be zero.
        /// <para></para>If lpClassName points to a string, it specifies the window class name. The class name can be any name registered with RegisterClass or RegisterClassEx, or any of the predefined control-class names.
        /// <para></para>If lpClassName is NULL, it finds any window whose title matches the lpWindowName parameter.
        /// </param>
        /// <param name="lpWindowName">The window name (the window's title). If this parameter is NULL, all window names match.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the window that has the specified class name and window name.
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </returns>
		[DllImport("user32")] public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        /// <summary>
        /// Retrieves a handle to a window whose class name and window name match the specified strings. The function searches child windows, beginning with the one following the specified child window. This function does not perform a case-sensitive search.
        /// <para></para>[Return] If the function succeeds, the return value is a handle to the window that has the specified class and window names.
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError. 
        /// </summary>
        /// <param name="hwndParent">
        /// A handle to the parent window whose child windows are to be searched.
        /// <para></para>If hwndParent is NULL, the function uses the desktop window as the parent window. The function searches among windows that are child windows of the desktop. 
        /// <para></para>If hwndParent is HWND_MESSAGE, the function searches all message-only windows. 
        /// </param>
        /// <param name="hwndChildAfter">
        /// A handle to a child window. The search begins with the next child window in the Z order. The child window must be a direct child window of hwndParent, not just a descendant window.
        /// <para></para>If hwndChildAfter is NULL, the search begins with the first child window of hwndParent.
        /// <para></para>Note that if both hwndParent and hwndChildAfter are NULL, the function searches all top-level and message-only windows.
        /// </param>
        /// <param name="lpszClass">
        /// The class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function. The atom must be placed in the low-order word of lpszClass; the high-order word must be zero.
        /// <para></para>If lpszClass is a string, it specifies the window class name. The class name can be any name registered with RegisterClass or RegisterClassEx, or any of the predefined control-class names, or it can be MAKEINTATOM(0x8000). In this latter case, 0x8000 is the atom for a menu class. For more information, see the Remarks section of this topic.
        /// </param>
        /// <param name="lpszWindow">The window name (the window's title). If this parameter is NULL, all window names match. </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the window that has the specified class and window names.
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError. 
        /// </returns>
		[DllImport("user32")] public static extern IntPtr FindWindowEx(HWND hwndParent, HWND hwndChildAfter, string lpszClass, string lpszWindow);
        /// <summary>
        /// Flashes the specified window one time. It does not change the active state of the window.
        /// <para></para>To flash the window a specified number of times, use the FlashWindowEx function.
        /// </summary>
        /// <param name="hwnd">A handle to the window to be flashed. The window can be either open or minimized.</param>
        /// <param name="bInvert">If this parameter is TRUE, the window is flashed from one state to the other. If it is FALSE, the window is returned to its original state (either active or inactive).
        /// <para></para>When an application is minimized and this parameter is TRUE, the taskbar window button flashes active/inactive. If it is FALSE, the taskbar window button flashes inactive, meaning that it does not change colors. It flashes, as if it were being redrawn, but it does not provide the visual invert clue to the user.</param>
        /// <returns></returns>
		[DllImport("user32")] public static extern int FlashWindow(HWND hwnd, int bInvert);
        /// <summary>
        /// Flashes the specified window. It does not change the active state of the window.
        /// </summary>
        /// <param name="pfwi">A pointer to a FLASHWINFO structure.</param>
        /// <returns>The return value specifies the window's state before the call to the FlashWindowEx function. If the window caption was drawn as active before the call, the return value is nonzero. Otherwise, the return value is zero.</returns>
        [DllImport("user32")] public static extern int FlashWindowEx(FLASHWINFO pfwi);
        /// <summary>
        /// Contains the flash status for a window and the number of times the system should flash the window.
        /// </summary>
        public struct FLASHWINFO
        {
            /// <summary>
            /// The size of the structure, in bytes.
            /// </summary>
            public uint cbSize;
            /// <summary>
            /// A handle to the window to be flashed. The window can be either opened or minimized.
            /// </summary>
            public UIntPtr handle;
            /// <summary>
            /// The flash status. This parameter can be one or more of the following values. 
            /// </summary>
            public FLASHWINFO_Flags dwFlags;
            /// <summary>
            /// The number of times to flash the window.
            /// </summary>
            public uint uCount;
            /// <summary>
            /// The rate at which the window is to be flashed, in milliseconds. If dwTimeout is zero, the function uses the default cursor blink rate.
            /// </summary>
            public uint dwTimeout;
        }

        public enum FLASHWINFO_Flags
        {
            /// <summary>
            /// Flash both the window caption and taskbar button. This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags. 
            /// </summary>
            FLASHW_ALL = 0x00000003,
            /// <summary>
            /// Flash the window caption. 
            /// </summary>
            FLASHW_CAPTION = 0x00000001,
            /// <summary>
            /// Stop flashing. The system restores the window to its original state. 
            /// </summary>
            FLASHW_STOP = 0,
            /// <summary>
            /// Flash continuously, until the FLASHW_STOP flag is set. 
            /// </summary>
            FLASHW_TIMER = 0x00000004,
            /// <summary>
            /// Flash continuously until the window comes to the foreground. 
            /// </summary>
            FLASHW_TIMERNOFG = 0x0000000C,
            /// <summary>
            /// Flash the taskbar button. 
            /// </summary>
            FLASHW_TRAY = 0x00000002
        }

        [DllImport("user32")] public static extern int FrameRect(HDC hdc, ref RECT lpRect, HANDLE hBrush);
		[DllImport("user32")] public static extern int FreeDDElParam(int msg, int lParam);
        /// <summary>
        /// Retrieves the window handle to the active window attached to the calling thread's message queue.
        /// </summary>
        /// <returns></returns>
		[DllImport("user32")] public static extern IntPtr GetActiveWindow();
		[DllImport("user32")] public static extern int GetCapture();
		[DllImport("user32")] public static extern int GetCaretBlinkTime();
		[DllImport("user32")] public static extern int GetCaretPos(ref POINT lpPoint);
		[DllImport("user32")] public static extern int GetClassInfo(HANDLE hInstance, string lpClassName, out WNDCLASS lpWndClass);
		[DllImport("user32")] public static extern int GetClassLong(HWND hwnd, int nIndex);
        /// <summary>
        /// Retrieves the name of the class to which the specified window belongs.
        /// <para></para>[Return] If the function succeeds, the return value is the number of characters copied to the buffer, not including the terminating null character.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </summary>
        /// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <param name="strBuilder">StringBuilder Class</param>
        /// <param name="strBuilder_Capacity">StringBuilder Maximum Capacity</param>
        /// <returns>
        /// If the function succeeds, the return value is the number of characters copied to the buffer, not including the terminating null character.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)] 
        public static extern int GetClassName(IntPtr hWnd, System.Text.StringBuilder strBuilder, int strBuilder_Capacity);
        [DllImport("user32", CharSet = CharSet.Auto)] public static extern int GetClassWord(HWND hwnd, int nIndex);
		[DllImport("user32", CharSet = CharSet.Auto)] public static extern int GetClientRect(HWND hwnd, ref RECT lpRect);
		[DllImport("user32", CharSet = CharSet.Auto)] public static extern int GetClipCursor(out RECT lprc);
        /// <summary>
        /// Retrieves data from the clipboard in a specified format. The clipboard must have been opened previously.
        /// </summary>
        /// <param name="wFormat">A clipboard format. For a description of the standard clipboard formats, see Standard Clipboard Formats.</param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to a clipboard object in the specified format.
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </returns>
		[DllImport("user32")] public static extern int GetClipboardData(ClipBoardFormat wFormat);

        public enum ClipBoardFormat
        {
            /// <summary>
            /// A handle to a bitmap (HBITMAP).
            /// </summary>
            CF_BITMAP = 2,
            /// <summary>
            /// A memory object containing a BITMAPINFO structure followed by the bitmap bits.
            /// </summary>
            CF_DIB = 8,
            /// <summary>
            /// A memory object containing a BITMAPV5HEADER structure followed by the bitmap color space information and the bitmap bits.
            /// </summary>
            CF_DIBV5 = 17,
            /// <summary>
            /// Software Arts' Data Interchange Format.
            /// </summary>
            CF_DIF = 5,
            /// <summary>
            /// Bitmap display format associated with a private format. The hMem parameter must be a handle to data that can be displayed in bitmap format in lieu of the privately formatted data.
            /// </summary>
            CF_DSPBITMAP = 0x0082,
            /// <summary>
            /// Enhanced metafile display format associated with a private format. The hMem parameter must be a handle to data that can be displayed in enhanced metafile format in lieu of the privately formatted data.
            /// </summary>
            CF_DSPENHMETAFILE = 0x008E,
            /// <summary>
            /// Metafile-picture display format associated with a private format. The hMem parameter must be a handle to data that can be displayed in metafile-picture format in lieu of the privately formatted data.
            /// </summary>
            CF_DSPMETAFILEPICT = 0x0083,
            /// <summary>
            /// Text display format associated with a private format. The hMem parameter must be a handle to data that can be displayed in text format in lieu of the privately formatted data.
            /// </summary>
            CF_DSPTEXT = 0x0081,
            /// <summary>
            /// A handle to an enhanced metafile (HENHMETAFILE).
            /// </summary>
            CF_ENHMETAFILE = 14,
            /// <summary>
            /// Start of a range of integer values for application-defined GDI object clipboard formats. The end of the range is CF_GDIOBJLAST.
            /// <para></para>Handles associated with clipboard formats in this range are not automatically deleted using the GlobalFree function when the clipboard is emptied. Also, when using values in this range, the hMem parameter is not a handle to a GDI object, but is a handle allocated by the GlobalAlloc function with the GMEM_MOVEABLE flag.
            /// </summary>
            CF_GDIOBJFIRST = 0x0300,
            /// <summary>
            /// See CF_GDIOBJFIRST.
            /// </summary>
            CF_GDIOBJLAST = 0x03FF,
            /// <summary>
            /// A handle to type HDROP that identifies a list of files. An application can retrieve information about the files by passing the handle to the DragQueryFile function.
            /// </summary>
            CF_HDROP = 15,
            /// <summary>
            /// The data is a handle to the locale identifier associated with text in the clipboard. When you close the clipboard, if it contains CF_TEXT data but no CF_LOCALE data, the system automatically sets the CF_LOCALE format to the current input language. You can use the CF_LOCALE format to associate a different locale with the clipboard text. 
            /// <para></para>An application that pastes text from the clipboard can retrieve this format to determine which character set was used to generate the text.
            /// <para></para>Note that the clipboard does not support plain text in multiple character sets. To achieve this, use a formatted text data type such as RTF instead.
            /// <para></para>The system uses the code page associated with CF_LOCALE to implicitly convert from CF_TEXT to CF_UNICODETEXT. Therefore, the correct code page table is used for the conversion.
            /// </summary>
            CF_LOCALE = 16,
            /// <summary>
            /// Handle to a metafile picture format as defined by the METAFILEPICT structure. When passing a CF_METAFILEPICT handle by means of DDE, the application responsible for deleting hMem should also free the metafile referred to by the CF_METAFILEPICT handle.
            /// </summary>
            CF_METAFILEPICT = 3,
            /// <summary>
            /// Text format containing characters in the OEM character set. Each line ends with a carriage return/linefeed (CR-LF) combination. A null character signals the end of the data.
            /// </summary>
            CF_OEMTEXT = 7,
            /// <summary>
            /// Owner-display format. The clipboard owner must display and update the clipboard viewer window, and receive the WM_ASKCBFORMATNAME, WM_HSCROLLCLIPBOARD, WM_PAINTCLIPBOARD, WM_SIZECLIPBOARD, and WM_VSCROLLCLIPBOARD messages. The hMem parameter must be NULL.
            /// </summary>
            CF_OWNERDISPLAY = 0x0080,
            /// <summary>
            /// Handle to a color palette. Whenever an application places data in the clipboard that depends on or assumes a color palette, it should place the palette on the clipboard as well.
            /// <para></para>If the clipboard contains data in the CF_PALETTE (logical color palette) format, the application should use the SelectPalette and RealizePalette functions to realize (compare) any other data in the clipboard against that logical palette.
            /// <para></para>When displaying clipboard data, the clipboard always uses as its current palette any object on the clipboard that is in the CF_PALETTE format.
            /// </summary>
            CF_PALETTE = 9,
            /// <summary>
            /// Data for the pen extensions to the Microsoft Windows for Pen Computing.
            /// </summary>
            CF_PENDATA = 10,
            /// <summary>
            /// Start of a range of integer values for private clipboard formats. The range ends with CF_PRIVATELAST. Handles associated with private clipboard formats are not freed automatically; the clipboard owner must free such handles, typically in response to the WM_DESTROYCLIPBOARD message.
            /// </summary>
            CF_PRIVATEFIRST = 0x0200,
            /// <summary>
            /// See CF_PRIVATEFIRST.
            /// </summary>
            CF_PRIVATELAST = 0x02FF,
            /// <summary>
            /// Represents audio data more complex than can be represented in a CF_WAVE standard wave format.
            /// </summary>
            CF_RIFF = 11,
            /// <summary>
            /// Microsoft Symbolic Link (SYLK) format.
            /// </summary>
            CF_SYLK = 4,
            /// <summary>
            /// Text format. Each line ends with a carriage return/linefeed (CR-LF) combination. A null character signals the end of the data. Use this format for ANSI text.
            /// </summary>
            CF_TEXT = 1,
            /// <summary>
            /// Tagged-image file format.
            /// </summary>
            CF_TIFF = 6,
            /// <summary>
            /// Unicode text format. Each line ends with a carriage return/linefeed (CR-LF) combination. A null character signals the end of the data.
            /// </summary>
            CF_UNICODETEXT = 13,
            /// <summary>
            /// Represents audio data in one of the standard wave formats, such as 11 kHz or 22 kHz PCM.
            /// </summary>
            CF_WAVE = 12
        }
		[DllImport("user32")] public static extern int GetClipboardFormatName(int wFormat, string lpString, int nMaxCount);
		[DllImport("user32")] public static extern int GetClipboardOwner();
		[DllImport("user32")] public static extern int GetClipboardViewer();
		[DllImport("user32")] public static extern int GetCursor();
		[DllImport("user32")] public static extern int GetCursorPos(out POINT lpPoint);
		[DllImport("user32")] public static extern int GetDC(HWND hwnd);
		[DllImport("user32")] public static extern int GetDCEx(HWND hwnd, HANDLE hrgnclip, int fdwOptions);
		[DllImport("user32")] public static extern int GetDesktopWindow();
		[DllImport("user32")] public static extern int GetDialogBaseUnits();
		[DllImport("user32")] public static extern int GetDlgCtrlID(HWND hwnd);
		[DllImport("user32")] public static extern int GetDlgItem(HANDLE hDlg, int nIDDlgItem);
		[DllImport("user32")] public static extern int GetDlgItemInt(HANDLE hDlg, int nIDDlgItem, ref int lpTranslated, int bSigned);
		[DllImport("user32")] public static extern int GetDlgItemText(HANDLE hDlg, int nIDDlgItem, StringBuilder lpString, int nMaxCount);
		[DllImport("user32")] public static extern int GetDoubleClickTime();
		[DllImport("user32")] public static extern int GetFocus();
		[DllImport("user32")] public static extern int GetForegroundWindow();
		[DllImport("user32")] public static extern int GetIconInfo(HANDLE hIcon, out ICONINFO piconinfo);
		[DllImport("user32")] public static extern int GetInputState();
		[DllImport("user32")] public static extern int GetKBCodePage();
		[DllImport("user32")] public static extern int GetKeyNameText(int lParam, StringBuilder lpBuffer, int nSize);
		[DllImport("user32")] public static extern int GetKeyboardLayout(int dwLayout);
		[DllImport("user32")] public static extern int GetKeyboardLayoutList(int nBuff, ref int lpList);
		[DllImport("user32")] public static extern int GetKeyboardLayoutName(string pwszKLID);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32")] public static extern bool GetKeyboardState(VK_Keys pbKeyState);
		[DllImport("user32")] public static extern int GetKeyboardType(int nTypeFlag);
		[DllImport("user32")] public static extern int GetLastActivePopup(HWND hwndOwnder);
		[DllImport("user32")] public static extern int GetMenu(HWND hwnd);
		[DllImport("user32")] public static extern int GetMenuCheckMarkDimensions();
		[DllImport("user32")] public static extern int GetMenuContextHelpId(HANDLE hMenu);
        /// <summary>
        /// Determines the default menu item on the specified menu.
        /// <para></para>[Return] If the function succeeds, the return value is the identifier or position of the menu item.
        /// If the function fails, the return value is -1. To get extended error information, call GetLastError.
        /// </summary>
        /// <param name="hMenu">A handle to the menu for which to retrieve the default menu item.</param>
        /// <param name="fByPos">Indicates whether to retrieve the menu item's identifier or its position. If this parameter is FALSE, the identifier is returned. Otherwise, the position is returned.</param>
        /// <param name="gmdiFlags">Indicates how the function should search for menu items. This parameter can be zero or more of the following values.</param>
        /// <returns>
        /// If the function succeeds, the return value is the identifier or position of the menu item.
        /// If the function fails, the return value is -1. To get extended error information, call GetLastError.
        /// </returns>
		[return : MarshalAs(UnmanagedType.SysUInt)]
        [DllImport("user32")] 
        public static extern uint GetMenuDefaultItem(HANDLE hMenu, uint fByPos, GMDI_Flag gmdiFlags);

        public enum GMDI_Flag
        {
            /// <summary>
            /// If the default item is one that opens a submenu, the function is to search recursively in the corresponding submenu. If the submenu has no default item, the return value identifies the item that opens the submenu. By default, the function returns the first default item on the specified menu, regardless of whether it is an item that opens a submenu.
            /// </summary>
            GMDI_GOINTOPOPUPS = 0x0002,
            /// <summary>
            /// The function is to return a default item, even if it is disabled. By default, the function skips disabled or grayed items. 
            /// </summary>
            GMDI_USEDISABLED = 0x0001
        }
		[DllImport("user32")] public static extern int GetMenuItemCount(HANDLE hMenu);
        /// <summary>
        /// Retrieves the menu item identifier of a menu item located at the specified position in a menu.
        /// <para></para>[Return] The return value is the identifier of the specified menu item. If the menu item identifier is NULL or if the specified item opens a submenu, the return value is -1.
        /// </summary>
        /// <param name="hMenu">A handle to the menu that contains the item whose identifier is to be retrieved.</param>
        /// <param name="nPos">The zero-based relative position of the menu item whose identifier is to be retrieved.</param>
        /// <returns>The return value is the identifier of the specified menu item. If the menu item identifier is NULL or if the specified item opens a submenu, the return value is -1.</returns>
		[DllImport("user32")] 
        public static extern IntPtr GetMenuItemID(HANDLE hMenu, int nPos);
        /// <summary>
        /// Retrieves information about a menu item.
        /// </summary>
        /// <param name="hMenu">A handle to the menu that contains the menu item.</param>
        /// <param name="item">The identifier or position of the menu item to get information about. The meaning of this parameter depends on the value of fByPosition.</param>
        /// <param name="fByPosition">The meaning of uItem. If this parameter is FALSE, uItem is a menu item identifier. Otherwise, it is a menu item position. See Accessing Menu Items Programmatically for more information.</param>
        /// <param name="lpMenuItemInfo">A pointer to a MENUITEMINFO structure that specifies the information to retrieve and receives information about the menu item. Note that you must set the cbSize member to sizeof(MENUITEMINFO) before calling this function.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly created menu.
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </returns>
		[return : MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32")] 
        public static extern bool GetMenuItemInfo(HANDLE hMenu, uint item, bool fByPosition, ref MENUITEMINFO lpMenuItemInfo);
		[DllImport("user32")] 
        public static extern int GetMenuItemRect(HWND hwnd, HANDLE hMenu, int uItem, ref RECT lprcItem);
        /// <summary>
        /// Retrieves the menu flags associated with the specified menu item. If the menu item opens a submenu, this function also returns the number of items in the submenu.
        /// </summary>
        /// <param name="hMenu">A handle to the menu that contains the menu item whose flags are to be retrieved.</param>
        /// <param name="uID">The menu item for which the menu flags are to be retrieved, as determined by the uFlags parameter.</param>
        /// <param name="wFlags">Indicates how the uId parameter is interpreted.</param>
        /// <returns>If the specified item does not exist, the return value is -1.</returns>
        [Obsolete("GetMenuItemInfo 로 대체되었음. 사용은 가능함")]
        [return : MarshalAs(UnmanagedType.SysUInt)]
		[DllImport("user32")]
        public static extern MenuFeaturesReturn_GetMenuState GetMenuState(
            HANDLE hMenu, uint uID, MenuFeatures_GetMenuState wFlags);

        public enum MenuFeatures_GetMenuState
        {
            /// <summary>
            /// Indicates that the uId parameter gives the identifier of the menu item. The MF_BYCOMMAND flag is the default if neither the MF_BYCOMMAND nor MF_BYPOSITION flag is specified. 
            /// </summary>
            MF_BYCOMMAND = 0x00000000,
            /// <summary>
            /// Indicates that the uId parameter gives the zero-based relative position of the menu item. 
            /// </summary>
            MF_BYPOSITION = 0x00000400
        }

        public enum MenuFeaturesReturn_GetMenuState
        {
            /// <summary>
            /// A check mark is placed next to the item (for drop-down menus, submenus, and shortcut menus only). 
            /// </summary>
            MF_CHECKED = 0x00000008,
            /// <summary>
            /// The item is disabled. 
            /// </summary>
            MF_DISABLED = 0x00000002,
            /// <summary>
            /// The item is disabled and grayed. 
            /// </summary>
            MF_GRAYED = 0x00000001,
            /// <summary>
            /// The item is highlighted.
            /// </summary>
            MF_HIGHLIGHT = 0x00000080,
            /// <summary>
            /// This is the same as the MF_MENUBREAK flag, except for drop-down menus, submenus, and shortcut menus, where the new column is separated from the old column by a vertical line.
            /// </summary>
            MF_MENUBARBREAK = 0x00000020,
            /// <summary>
            /// The item is placed on a new line (for menu bars) or in a new column (for drop-down menus, submenus, and shortcut menus) without separating columns. 
            /// </summary>
            MF_MENUBREAK = 0x00000040,
            /// <summary>
            /// The item is owner-drawn.
            /// </summary>
            MF_OWNERDRAW = 0x00000100,
            /// <summary>
            /// Menu item is a submenu.
            /// </summary>
            MF_POPUP = 0x00000010,
            /// <summary>
            /// There is a horizontal dividing line (for drop-down menus, submenus, and shortcut menus only). 
            /// </summary>
            MF_SEPARATOR = 0x00000800
        }
        /// <summary> 사용하지 않으므로 별도 설명 없음. </summary>
        [Obsolete("사용불가. GetMenuItemInfo를 사용해 menu item text를 받아오면 된다.")]
        [DllImport("user32")] 
        public static extern int GetMenuString(HANDLE hMenu, int wIDItem, StringBuilder lpString, int nMaxCount, int wFlag);
        /// <summary>
        /// Retrieves a message from the calling thread's message queue. The function dispatches incoming sent messages until a posted message is available for retrieval.
        /// </summary>
        /// <param name="lpMsg"></param>
        /// <param name="hwnd"></param>
        /// <param name="wMsgFilterMin"></param>
        /// <param name="wMsgFilterMax"></param>
        /// <returns></returns>
		[DllImport("user32")] public static extern bool GetMessage(ref MSG lpMsg, IntPtr hwnd, int MsgFilterMin, int MsgFilterMax);

        public enum GM_MsgFilter
        {
            WM_KEYFIRST = 0x0100,
            WM_MOUSEFIRST = 0x0200,
            /// <summary>
            /// If wMsgFilterMin and wMsgFilterMax are both zero, GetMessage returns all available messages (that is, no range filtering is performed).
            /// </summary>
            WM_NONE = 0
        }
		[DllImport("user32")] public static extern int GetMessageExtraInfo();
		[DllImport("user32")] public static extern int GetMessagePos();
		[DllImport("user32")] public static extern int GetMessageTime();
		[DllImport("user32")] public static extern int GetNextDlgGroupItem(HANDLE hDlg, HANDLE hCtl, int bPrevious);
		[DllImport("user32")] public static extern int GetNextDlgTabItem(HANDLE hDlg, HANDLE hCtl, int bPrevious);
		[DllImport("user32")] public static extern int GetNextWindow(HWND hwnd, int wFlag);
		[DllImport("user32")] public static extern int GetOpenClipboardWindow();
		[DllImport("user32")] public static extern int GetParent(HWND hwnd);
		[DllImport("user32")] public static extern int GetPriorityClipboardFormat(int lpPriorityList, int nCount);
		[DllImport("user32")] public static extern int GetProcessWindowStation();
		[DllImport("user32")] public static extern int GetProp(HWND hwnd, string lpString);
		[DllImport("user32")] public static extern int GetQueueStatus(int fuFlags);
		[DllImport("user32")] public static extern int GetScrollInfo(HWND hwnd, int n, ref SCROLLINFO lpScrollInfo);
		[DllImport("user32")] public static extern int GetScrollPos(HWND hwnd, int nBar);
		[DllImport("user32")] public static extern int GetScrollRange(HWND hwnd, int nBar, ref int lpMinPos, ref int lpMaxPos);
		[DllImport("user32")] public static extern int GetSubMenu(HANDLE hMenu, int nPos);
		[DllImport("user32")] public static extern int GetSysColor(int nIndex);
		[DllImport("user32")] public static extern int GetSysColorBrush(int nIndex);
		[DllImport("user32")] public static extern int GetSystemMenu(HWND hwnd, int bRevert);
		[DllImport("user32")] public static extern int GetSystemMetrics(int nIndex);
		[DllImport("user32")] public static extern int GetTabbedTextExtent(HDC hdc, string lpString, int nCount, int nTabPositions, ref int lpnTabStopPositions);
		[DllImport("user32")] public static extern int GetThreadDesktop(int dwThread);
        /// <summary>
        /// Examines the Z order of the child windows associated with the specified parent window and retrieves a handle to the child window at the top of the Z order.
        /// <para></para>[Return] If the function succeeds, the return value is a handle to the child window at the top of the Z order. If the specified window has no child windows, the return value is NULL. To get extended error information, use the GetLastError function.
        /// </summary>
        /// <param name="hwnd">A handle to the parent window whose child windows are to be examined. If this parameter is NULL, the function returns a handle to the window at the top of the Z order.</param>
        /// <returns>If the function succeeds, the return value is a handle to the child window at the top of the Z order. If the specified window has no child windows, the return value is NULL. To get extended error information, use the GetLastError function.</returns>
		[DllImport("user32")]
        public static extern IntPtr GetTopWindow(HWND hwnd);
		[DllImport("user32")] public static extern int GetUpdateRect(HWND hwnd, ref RECT lpRect, int bErase);
		[DllImport("user32")] public static extern int GetUpdateRgn(HWND hwnd, HANDLE hRgn, int fErase);
		[DllImport("user32")] public static extern int GetUserObjectInformation(HANDLE hObj, int nIndex, IntPtr pvInfo, int nLength, ref int lpnLengthNeeded);
		[DllImport("user32")] public static extern int GetUserObjectSecurity(HANDLE hObj, ref int pSIRequested, ref SECURITY_DESCRIPTOR pSd, int nLength, ref int lpnLengthNeeded);
        /// <summary>
        /// Retrieves a handle to a window that has the specified relationship (Z-Order or owner) to the specified window.
        /// </summary>
        /// <param name="hwnd">A handle to a window. The window handle retrieved is relative to this window, based on the value of the uCmd parameter.</param>
        /// <param name="GW_Param"></param>
        /// <returns></returns>
        [DllImport("user32")] public static extern IntPtr GetWindow(HWND hwnd, GW_Params GW_Param);

        /// <summary>
        /// GetWindow Parameter
        /// </summary>
        public enum GW_Params
        {
            /// <summary>
            /// The retrieved handle identifies the child window at the top of the Z order, if the specified window is a parent window; otherwise, the retrieved handle is NULL. The function examines only child windows of the specified window. It does not examine descendant windows. 
            /// </summary>
            GW_CHILD = 5,
            /// <summary>
            /// The retrieved handle identifies the enabled popup window owned by the specified window (the search uses the first such window found using GW_HWNDNEXT); otherwise, if there are no enabled popup windows, the retrieved handle is that of the specified window. 
            /// </summary>
            GW_ENABLEDPOPUP = 6,
            /// <summary>
            /// The retrieved handle identifies the window of the same type that is highest in the Z order. 
            /// <para></para>If the specified window is a topmost window, the handle identifies a topmost window. If the specified window is a top-level window, the handle identifies a top-level window. If the specified window is a child window, the handle identifies a sibling window.
            /// </summary>
            GW_HWNDFIRST = 0,
            /// <summary>
            /// The retrieved handle identifies the window of the same type that is lowest in the Z order. 
            /// <para></para>If the specified window is a topmost window, the handle identifies a topmost window. If the specified window is a top-level window, the handle identifies a top-level window. If the specified window is a child window, the handle identifies a sibling window.
            /// </summary>
            GW_HWNDLAST = 1,
            /// <summary>
            /// The retrieved handle identifies the window below the specified window in the Z order. 
            /// <para></para>If the specified window is a topmost window, the handle identifies a topmost window. If the specified window is a top-level window, the handle identifies a top-level window. If the specified window is a child window, the handle identifies a sibling window.
            /// </summary>
            GW_HWNDNEXT = 2,
            /// <summary>
            /// The retrieved handle identifies the window above the specified window in the Z order. 
            /// <para></para>If the specified window is a topmost window, the handle identifies a topmost window. If the specified window is a top-level window, the handle identifies a top-level window. If the specified window is a child window, the handle identifies a sibling window.
            /// </summary>
            GW_HWNDPREV = 3,
            /// <summary>
            /// The retrieved handle identifies the specified window's owner window, if any. For more information, see Owned Windows. 
            /// </summary>
            GW_OWNER = 4
        }
		[DllImport("user32")] public static extern int GetWindowContextHelpId(HWND hwnd);
        /// <summary>
        /// This function retrieves information about the specified window. GetWindowLong also retrieves the 32-bit (long) value at the specified offset into the extra window memory of a window.
        /// <para></para>[Return] Window Style
        /// </summary>
        /// <param name="hwnd">Handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <param name="GWL_Value">Specifies the zero-based offset to the value to be retrieved. Valid values are in the range zero through the number of bytes of extra window memory, minus four; for example, if you specified 12 or more bytes of extra memory, a value of 8 would be an index to the third 32-bit integer. To retrieve any other value, specify one of the following values:</param>
        /// <returns>Window Style</returns>
        [DllImport("user32")] 
        public static extern uint GetWindowLong(HWND hwnd, GWL_Value GWL_Value);
		[DllImport("user32")] public static extern int GetWindowDC(HWND hwnd);
        /// <summary>
        /// Retrieves the show state and the restored, minimized, and maximized positions of the specified window.
        /// <para></para>[Return] If the function succeeds, the return value is nonzero.
        /// </summary>
        /// <param name="hwnd">Windows Handle</param>
        /// <param name="lpwndpl">WINDOWPLACEMENT</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// </returns>
		[DllImport("user32")] public static extern int GetWindowPlacement(HWND hwnd, ref WINDOWPLACEMENT lpwndpl);
        /// <summary>
        ///  이 함수를 통해 얻은 Width, Length 등은 Dpi가 모두 반영되어 있는 값이다
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="lpRect"></param>
        /// <returns></returns>
		[DllImport("user32")] public static extern int GetWindowRect(HWND hwnd, ref RECT lpRect);
		[DllImport("user32")] public static extern int GetWindowRgn(HWND hwnd, HANDLE hRgn);
		[DllImport("user32")] public static extern int GetWindowText(HWND hwnd, StringBuilder lpString, int cch);
		[DllImport("user32")] public static extern int GetWindowTextLength(HWND hwnd);
		[DllImport("user32")] public static extern int GetWindowThreadProcessId(HWND hwnd, ref int lpdwProcessId);
		[DllImport("user32")] public static extern int GrayString(HWND hdc, HANDLE hBrush, ref int lpOutputFunc, ref int lpData, int nCount, int X, int Y, int nWidth, int nHeight);
		[DllImport("user32")] public static extern int HideCaret(HWND hwnd);
		[DllImport("user32")] public static extern int HiliteMenuItem(HWND hwnd, HANDLE hMenu, int wIDHiliteItem, int wHilite);
		[DllImport("user32")] public static extern int ImpersonateDdeClientWindow(HWND hwndClient, HWND hwndServer);
        /// <summary>
        /// Determines whether the current window procedure is processing a message that was sent from another thread (in the same process or a different process) by a call to the SendMessage function.
        /// <para></para>To obtain additional information about how the message was sent, use the InSendMessageEx function.
        /// <para></para>[return 1] If the window procedure is processing a message sent to it from another thread using the SendMessage function, the return value is nonzero.
        /// <para></para>[return 0] If the window procedure is not processing a message sent to it from another thread using the SendMessage function, the return value is zero.
        /// </summary>
        /// <returns>
        /// If the window procedure is processing a message sent to it from another thread using the SendMessage function, the return value is nonzero.
        /// If the window procedure is not processing a message sent to it from another thread using the SendMessage function, the return value is zero.
        /// </returns>
		[return : MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32")] public static extern bool InSendMessage();
		[DllImport("user32")] public static extern int InflateRect(ref RECT lpRect, int x, int y);
        /// <summary>
        /// Inserts a new menu item into a menu, moving other items down the menu.
        /// <para></para>To use extended feature, use InsertMenuItem function.
        /// </summary>
        /// <param name="hMenu">A handle to the menu to be changed. </param>
        /// <param name="nPosition">The menu item before which the new menu item is to be inserted, as determined by the uFlags parameter. </param>
        /// <param name="wFlags">Controls the interpretation of the uPosition parameter and the content, appearance, and behavior of the new menu item.</param>
        /// <param name="wIDNewItem">The identifier of the new menu item or, if the uFlags parameter has the MF_POPUP flag set, a handle to the drop-down menu or submenu.</param>
        /// <param name="lpNewItem">The content of the new menu item. The interpretation of lpNewItem depends on whether the uFlags parameter includes the MF_BITMAP, MF_OWNERDRAW, or MF_STRING flag, as follows. </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly created menu.
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </returns>
		[return : MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32")] 
        public static extern bool InsertMenu(HANDLE hMenu, int nPosition, MenuFeatures wFlags, int wIDNewItem, IntPtr lpNewItem);
        /// <summary>
        /// Inserts a new menu item at the specified position in a menu.
        /// </summary>
        /// <param name="hMenu">A handle to the menu in which the new menu item is inserted.</param>
        /// <param name="item">The identifier or position of the menu item before which to insert the new item. The meaning of this parameter depends on the value of fByPosition.</param>
        /// <param name="fByPosition">Controls the meaning of uItem. If this parameter is FALSE, uItem is a menu item identifier. Otherwise, it is a menu item position. See Accessing Menu Items Programmatically for more information.</param>
        /// <param name="lpcMenuItemInfo">A pointer to a MENUITEMINFO structure that contains information about the new menu item.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly created menu.
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32")] 
        public static extern bool InsertMenuItem(HANDLE hMenu, uint item, bool fByPosition, ref MENUITEMINFO lpcMenuItemInfo);
		[DllImport("user32")] public static extern int IntersectRect(ref RECT lpDestRect, ref RECT lpSrc1Rect, ref RECT lpSrc2Rect);
		[DllImport("user32")] public static extern int InvalidateRect(HWND hwnd, ref RECT lpRect, int bErase);
		[DllImport("user32")] public static extern int InvalidateRgn(HWND hwnd, HANDLE hRgn, int bErase);
		[DllImport("user32")] public static extern int InvertRect(HDC hdc, ref RECT lpRect);
		[DllImport("user32")] public static extern int IsCharAlpha(Byte cChar);
		[DllImport("user32")] public static extern int IsCharAlphaNumeric(Byte cChar);
		[DllImport("user32")] public static extern int IsCharLower(Byte cChar);
		[DllImport("user32")] public static extern int IsCharUpper(Byte cChar);
        /// <summary>
        /// Determines whether a window is a child window or descendant window of a specified parent window. A child window is the direct descendant of a specified parent window if that parent window is in the chain of parent windows; the chain of parent windows leads from the original overlapped or pop-up window to the child window.
        /// </summary>
        /// <param name="ParentHandle">A handle to the parent window.</param>
        /// <param name="InspectionTarget">A handle to the window to be tested.</param>
        /// <returns>If the window is a child or descendant window of the specified parent window, the return value is nonzero.</returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32")] public static extern bool IsChild(HWND ParentHandle, HWND TargetHandle);
		[DllImport("user32")] public static extern int IsClipboardFormatAvailable(int wFormat);
		[DllImport("user32")] public static extern int IsDialogMessage(HANDLE hDlg, ref MSG lpMsg);
		[DllImport("user32")] public static extern int IsDlgButtonChecked(HANDLE hDlg, int nIDButton);
		[DllImport("user32")] public static extern int IsIconic(HWND hwnd);
		[DllImport("user32")] public static extern int IsMenu(HANDLE hMenu);
		[DllImport("user32")] public static extern int IsRectEmpty(ref RECT lpRect);
		[DllImport("user32")] public static extern int IsWindow(HWND hwnd);
		[DllImport("user32")] public static extern int IsWindowEnabled(HWND hwnd);
		[DllImport("user32")] public static extern int IsWindowUnicode(HWND hwnd);
		[DllImport("user32")] public static extern int IsWindowVisible(HWND hwnd);
		[DllImport("user32")] public static extern int IsZoomed(HWND hwnd);
		[DllImport("user32")] public static extern int KillTimer(HWND hwnd, int nIDEvent);
		[DllImport("user32")] public static extern int LoadAccelerators(HANDLE hInstance, string lpTableName);
		[DllImport("user32")] public static extern int LoadBitmap(HANDLE hInstance, string lpBitmapName);
		[DllImport("user32")] public static extern int LoadCursor(HANDLE hInstance, string lpCursorName);
		[DllImport("user32")] public static extern int LoadCursorFromFile(string lpFileName);
		[DllImport("user32")] public static extern int LoadIcon(HANDLE hInstance, string lpIconName);
		[DllImport("user32")] public static extern int LoadImage(HANDLE hInst, string lpsz, int un1, int n1, int n2, int un2);
		[DllImport("user32")] public static extern int LoadKeyboardLayout(string pwszKLID, int flags);
		[DllImport("user32")] public static extern int LoadMenu(HANDLE hInstance, string lpString);
		[DllImport("user32")] public static extern int LoadMenuIndirect(int lpMenuTemplate);
		[DllImport("user32")] public static extern int LoadString(HANDLE hInstance, int wID, string lpBuffer, int nBufferMax);
        /// <summary>
        /// The LockWindowUpdate function disables or enables drawing in the specified window. Only one window can be locked at a time.
        /// </summary>
        /// <param name="hwndLock">The window in which drawing will be disabled. If this parameter is NULL, drawing in the locked window is enabled.</param>
        /// <returns></returns>
		[DllImport("user32")] public static extern int LockWindowUpdate(HWND hwndLock);
		[DllImport("user32")] public static extern int LookupIconIdFromDirectory(Byte presbits, int fIcon);
		[DllImport("user32")] public static extern int LookupIconIdFromDirectoryEx(Byte presbits, int fIcon, int cxDesired, int cyDesired, int Flags);
		[DllImport("user32")] public static extern int MapDialogRect(HANDLE hDlg, ref RECT lpRect);
        /// <summary>
        /// Get scan code from virtual keycode.
        /// <para>This translations do not distinguish between the left and right instances of the SHIFT, CTRL, or ALT keys.</para>
        /// <para>ex) B/W VK_LSHIFT, VK_RSHIFT</para>
        /// </summary>
        /// <param name="wCode">Virutal Key</param>
        /// <param name="wMapType">Conversion Type(Rule)</param>
        /// <returns></returns>
		[DllImport("user32")] public static extern ScanCodeShort MapVirtualKey(VK_Keys wCode, ConversionRule wMapType);

        /// <summary>
        /// 주로 MAPVK_VK_TO_VSC (Virtual Key -> Scan Code)의 변환이 많이 쓰인다.
        /// </summary>
        public enum ConversionRule
        {
            /// <summary>
            /// uCode is a virtual-key code and is translated into an unshifted character value in the low-order word of the return value. Dead keys (diacritics) are indicated by setting the top bit of the return value. If there is no translation, the function returns 0. 
            /// </summary>
            MAPVK_VK_TO_CHAR = 2,
            /// <summary>
            /// uCode is a virtual-key code and is translated into a scan code. If it is a virtual-key code that does not distinguish between left- and right-hand keys, the left-hand scan code is returned. If there is no translation, the function returns 0. 
            /// </summary>
            MAPVK_VK_TO_VSC = 0,
            /// <summary>
            /// uCode is a scan code and is translated into a virtual-key code that does not distinguish between left- and right-hand keys. If there is no translation, the function returns 0. 
            /// </summary>
            MAPVK_VSC_TO_VK = 1,
            /// <summary>
            /// uCode is a scan code and is translated into a virtual-key code that distinguishes between left- and right-hand keys. If there is no translation, the function returns 0. 
            /// </summary>
            MAPVK_VSC_TO_VK_EX = 3
        }

        [DllImport("user32")] public static extern int MapVirtualKeyEx(int uCode, int uMapType, int dwhkl);
		[DllImport("user32")] public static extern int MapWindowPoints(HWND hwndFrom, HWND hwndTo, POINT [] lppt, int cPoints);
		[DllImport("user32")] public static extern int MenuItemFromPoint(HWND hwnd, HANDLE hMenu, POINT ptScreen);
		[DllImport("user32")] public static extern int MessageBeep(int wType);
		[DllImport("user32")] public static extern int MessageBox(HWND hwnd, string lpText, string lpCaption, int wType);
		[DllImport("user32")] public static extern int MessageBoxEx(HWND hwnd, string lpText, string lpCaption, int uType, int wLanguageId);
		[DllImport("user32")] public static extern int MessageBoxIndirect(ref MSGBOXPARAMS lpMsgBoxParams);
		[DllImport("user32")] public static extern int ModifyMenu(HANDLE hMenu, int nPosition, int wFlags, int wIDNewItem, IntPtr lpString);
        /// <summary>
        /// Changes the position and dimensions of the specified window. For a top-level window, the position and dimensions are relative to the upper-left corner of the screen. For a child window, they are relative to the upper-left corner of the parent window's client area.
        /// <para></para>[Return] If the function succeeds, the return value is nonzero.
        /// </summary>
        /// <param name="hwnd">A handle to the window.</param>
        /// <param name="x">The new position of the left side of the window.</param>
        /// <param name="y">The new position of the top of the window.</param>
        /// <param name="nWidth">The new width of the window.</param>
        /// <param name="nHeight">The new height of the window.</param>
        /// <param name="bRepaint">Indicates whether the window is to be repainted. If this parameter is TRUE, the window receives a message. If the parameter is FALSE, no repainting of any kind occurs. This applies to the client area, the nonclient area (including the title bar and scroll bars), and any part of the parent window uncovered as a result of moving a child window.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32")] public static extern bool MoveWindow(HWND hwnd, int x, int y, int nWidth, int nHeight, int bRepaint);
		[DllImport("user32")] public static extern int MsgWaitForMultipleObjects(int nCount, ref int pHandles, int fWaitAll, int dwMilliseconds, int dwWakeMask);
		[DllImport("user32")] public static extern int OemKeyScan(int wOemChar);
		[DllImport("user32")] public static extern int OemToChar(string lpszSrc, string lpszDst);
		[DllImport("user32")] public static extern int OemToCharBuff(string lpszSrc, string lpszDst, int cchDstLength);
		[DllImport("user32")] public static extern int OffsetRect(ref RECT lpRect, int x, int y);
		[DllImport("user32")] public static extern int OpenClipboard(HWND hwnd);
		[DllImport("user32")] public static extern int OpenDesktop(string lpszDesktop, int dwFlags, int fInherit, int dwDesiredAccess);
		[DllImport("user32")] public static extern int OpenIcon(HWND hwnd);
		[DllImport("user32")] public static extern int OpenInputDesktop(int dwFlags, int fInherit, int dwDesiredAccess);
		[DllImport("user32")] public static extern int OpenWindowStation(string lpszWinSta, int fInherit, int dwDesiredAccess);
		[DllImport("user32")] public static extern int PackDDElParam(int msg, int uiLo, int uiHi);
		[DllImport("user32")] public static extern int PaintDesktop(HDC hdc);
        /// <summary>
        /// Dispatches incoming sent messages, checks the thread message queue for a posted message, and retrieves the message (if any exist).
        /// <para></para>[Return] If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </summary>
        /// <param name="lpMsg">A pointer to an MSG structure that receives message information.</param>
        /// <param name="hwnd">
        /// A handle to the window whose messages are to be retrieved. The window must belong to the current thread.
        /// <para></para>If hWnd is NULL, PeekMessage retrieves messages for any window that belongs to the current thread, and any messages on the current thread's message queue whose hwnd value is NULL (see the MSG structure). Therefore if hWnd is NULL, both window messages and thread messages are processed.
        /// <para></para>If hWnd is -1, PeekMessage retrieves only messages on the current thread's message queue whose hwnd value is NULL, that is, thread messages as posted by PostMessage (when the hWnd parameter is NULL) or PostThreadMessage.
        /// </param>
        /// <param name="wMsgFilterMin">
        /// The value of the first message in the range of messages to be examined. Use WM_KEYFIRST (0x0100) to specify the first keyboard message or WM_MOUSEFIRST (0x0200) to specify the first mouse message.
        /// <para></para>If wMsgFilterMin and wMsgFilterMax are both zero, PeekMessage returns all available messages (that is, no range filtering is performed).
        /// </param>
        /// <param name="wMsgFilterMax">
        /// The value of the last message in the range of messages to be examined. Use WM_KEYLAST to specify the last keyboard message or WM_MOUSELAST to specify the last mouse message.
        /// <para></para>If wMsgFilterMin and wMsgFilterMax are both zero, PeekMessage returns all available messages (that is, no range filtering is performed).
        /// </param>
        /// <param name="wRemoveMsg">Specifies how messages are to be handled. This parameter can be one or more of the following values.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        [return : MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32")] public static extern bool PeekMessage(ref MSG lpMsg, HWND hwnd, int wMsgFilterMin, int wMsgFilterMax, PeekMessageOption wRemoveMsg);
        
        [Flags]
        public enum PeekMessageOption : uint
        {
            /// <summary>
            /// Messages are not removed from the queue after processing by PeekMessage. 
            /// </summary>
            PM_NOREMOVE = 0x0000,
            /// <summary>
            /// Messages are removed from the queue after processing by PeekMessage. 
            /// </summary>
            PM_REMOVE = 0x0001,
            /// <summary>
            /// Prevents the system from releasing any thread that is waiting for the caller to go idle (see WaitForInputIdle). 
            /// </summary>
            PM_NOYIELD = 0x0002,
            PM_QS_INPUT = QueueStatusFlags.QS_INPUT << 16,
            PM_QS_POSTMESSAGE = (QueueStatusFlags.QS_POSTMESSAGE | QueueStatusFlags.QS_HOTKEY | QueueStatusFlags.QS_TIMER) << 16,
            PM_QS_PAINT = QueueStatusFlags.QS_PAINT << 16,
            PM_QS_SENDMESSAGE = QueueStatusFlags.QS_SENDMESSAGE << 16
        }
        [Flags]
        public enum QueueStatusFlags : uint
        {
            QS_KEY = 0x1,
            QS_MOUSEMOVE = 0x2,
            QS_MOUSEBUTTON = 0x4,
            QS_MOUSE = (QS_MOUSEMOVE | QS_MOUSEBUTTON),
            QS_INPUT = (QS_MOUSE | QS_KEY),
            QS_POSTMESSAGE = 0x8,
            QS_TIMER = 0x10,
            QS_PAINT = 0x20,
            QS_SENDMESSAGE = 0x40,
            QS_HOTKEY = 0x80,
            QS_REFRESH = (QS_HOTKEY | QS_KEY | QS_MOUSEBUTTON | QS_PAINT),
            QS_ALLEVENTS = (QS_INPUT | QS_POSTMESSAGE | QS_TIMER | QS_PAINT | QS_HOTKEY),
            QS_ALLINPUT = (QS_SENDMESSAGE | QS_PAINT | QS_TIMER | QS_POSTMESSAGE | QS_MOUSEBUTTON | QS_MOUSEMOVE | QS_HOTKEY | QS_KEY),
            QS_ALLPOSTMESSAGE = 0x100,
            QS_RAWINPUT = 0x400
        }
        [DllImport("user32")] public static extern int PostMessage(HWND hwnd, int wMsg, int wParam, int lParam);
		[DllImport("user32")] public static extern int PostThreadMessage(int idThread, int msg, int wParam, int lParam);
		[DllImport("user32")] public static extern int PtInRect(ref RECT lpRect, int ptX, int ptY);
		[DllImport("user32")] public static extern int RedrawWindow(HWND hwnd, ref RECT lprcUpdate, HANDLE hrgnUpdate, int fuRedraw);
		[DllImport("user32")] public static extern int RegisterClass(ref WNDCLASS Class);
		[DllImport("user32")] public static extern int RegisterClipboardFormat(string lpString);
		[DllImport("user32")] public static extern int RegisterHotKey(HWND hwnd, int id, int fsModifiers, int vk);
		[DllImport("user32")] public static extern int RegisterWindowMessage(string lpString);
		[DllImport("user32")] public static extern int ReleaseCapture();
		[DllImport("user32")] public static extern int ReleaseDC(HWND hwnd, HDC hdc);
		[DllImport("user32")] public static extern int RemoveMenu(HANDLE hMenu, int nPosition, int wFlags);
		[DllImport("user32")] public static extern int RemoveProp(HWND hwnd, string lpString);
        /// <summary>
        /// Replies to a message sent from another thread by the SendMessage function.
        /// <para></para>[Returns 1] If the calling thread was processing a message sent from another thread or process, the return value is nonzero.
        /// <para></para>[Returns 0] If the calling thread was not processing a message sent from another thread or process, the return value is zero.
        /// </summary>
        /// <param name="lReply">The result of the message processing. The possible values are based on the message sent.</param>
        /// <returns>
        /// If the calling thread was processing a message sent from another thread or process, the return value is nonzero.
        /// If the calling thread was not processing a message sent from another thread or process, the return value is zero.
        /// </returns>
		[return : MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32")] public static extern bool ReplyMessage(int lReply);
		[DllImport("user32")] public static extern int ReuseDDElParam(int lParam, int msgIn, int msgOut, int uiLo, int uiHi);
        /// <summary>
        /// The ScreenToClient function converts the screen coordinates of a specified point on the screen to client-area coordinates.
        /// <para></para>[Return] If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </summary>
        /// <param name="hwnd">A handle to the window whose client area will be used for the conversion.</param>
        /// <param name="lpPoint">A pointer to a POINT structure that specifies the screen coordinates to be converted.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
		[return : MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32")] 
        public static extern bool ScreenToClient(HWND hwnd, ref POINT lpPoint);
		[DllImport("user32")] public static extern int ScrollDC(HDC hdc, int dx, int dy, ref RECT lprcScroll, ref RECT lprcClip, HANDLE hrgnUpdate, ref RECT lprcUpdate);
		[Obsolete("구버전이므로 ScrollWindowEx 함수를 이용해야 한다.")]
        [DllImport("user32")] public static extern int ScrollWindow(HWND hwnd, int XAmount, int YAmount, ref RECT lpRect, ref RECT lpClipRect);
        /// <summary>
        /// The ScrollWindowEx function scrolls the contents of the specified window's client area.
        /// </summary>
        /// <param name="hwnd">Handle to the window where the client area is to be scrolled.</param>
        /// <param name="dx">Specifies the amount, in device units, of horizontal scrolling. This parameter must be a negative value to scroll to the left.</param>
        /// <param name="dy">Specifies the amount, in device units, of vertical scrolling. This parameter must be a negative value to scroll up.</param>
        /// <param name="lprcScroll">Pointer to a RECT structure that specifies the portion of the client area to be scrolled. If this parameter is NULL, the entire client area is scrolled.</param>
        /// <param name="lprcClip">Pointer to a RECT structure that contains the coordinates of the clipping rectangle. Only device bits within the clipping rectangle are affected. Bits scrolled from the outside of the rectangle to the inside are painted; bits scrolled from the inside of the rectangle to the outside are not painted. This parameter may be NULL.</param>
        /// <param name="hrgnUpdate">Handle to the region that is modified to hold the region invalidated by scrolling. This parameter may be NULL.</param>
        /// <param name="lprcUpdate">Pointer to a RECT structure that receives the boundaries of the rectangle invalidated by scrolling. This parameter may be NULL.</param>
        /// <param name="fuScroll">Specifies flags that control scrolling. This parameter can be a combination of the following values.</param>
        /// <returns></returns>
        [DllImport("user32")] 
        public static extern int ScrollWindowEx(HWND hwnd, int dx, int dy, ref RECT lprcScroll, ref RECT lprcClip, HANDLE hrgnUpdate, HANDLE lprcUpdate, ScrollWindowEx_Flags fuScroll);

        /// <summary>
        /// Retrieves the wheel-delta value from the specified WPARAM value.
        /// </summary>
        /// <param name="wParam">The value to be converted.</param>
        public static int GET_WHEEL_DELTA_WPARAM(int wParam)
        {
            int HighWord = 0x0;
            HighWord = (wParam & 0x11110000) >> 4;
            return HighWord;
        }

        /// <summary>
        /// Specifies flags that control scrolling. This parameter can be a combination of the following values.
        /// </summary>
        public enum ScrollWindowEx_Flags
        {
            /// <summary>
            /// Erases the newly invalidated region by sending a WM_ERASEBKGND message to the window when specified with the SW_INVALIDATE flag. 
            /// </summary>
            SW_ERASE,
            /// <summary>
            /// Invalidates the region identified by the hrgnUpdate parameter after scrolling.
            /// </summary>
            SW_INVALIDATE,
            /// <summary>
            /// Scrolls all child windows that intersect the rectangle pointed to by the prcScroll parameter. The child windows are scrolled by the number of pixels specified by the dx and dy parameters. The system sends a WM_MOVE message to all child windows that intersect the prcScroll rectangle, even if they do not move.
            /// </summary>
            SW_SCROLLCHILDREN,
            /// <summary>
            /// Scrolls using smooth scrolling. Use the HIWORD portion of the flags parameter to indicate how much time, in milliseconds, the smooth-scrolling operation should take.
            /// </summary>
            SW_SMOOTHSCROLL
        }

		[DllImport("user32")] public static extern int SendDlgItemMessage(HANDLE hDlg, int nIDDlgItem, int wMsg, int wParam, int lParam);
        /// <summary>
        /// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message.
        /// <para></para>To send a message and return immediately, use the SendMessageCallback or SendNotifyMessage function. To post a message to a thread's message queue and return immediately, use the PostMessage or PostThreadMessage function.
        /// <para></para>[Return] The return value specifies the result of the message processing; it depends on the message sent.
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.
        /// <para></para>Message sending is subject to UIPI. The thread of a process can send messages only to message queues of threads in processes of lesser or equal integrity level.
        /// </param>
        /// <param name="wMsg">
        /// The message to be sent.
        /// <para>For lists of the system-provided messages, see System-Defined Messages.</para>
        /// </param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">Additional message-specific information.</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		[DllImport("user32")] public static extern int SendMessage(HWND hwnd, int wMsg, int wParam, IntPtr lParam);
		[DllImport("user32")] public static extern int SendMessageCallback(HWND hwnd, int msg, int wParam, int lParam, ref int lpResultCallBack, int dwData);
		[DllImport("user32")] public static extern int SendMessageTimeout(HWND hwnd, int msg, int wParam, int lParam, int fuFlags, int uTimeout, ref int lpdwResult);
		[DllImport("user32")] public static extern int SendNotifyMessage(HWND hwnd, int msg, int wParam, int lParam);
		[DllImport("user32")] public static extern int SetActiveWindow(HWND hwnd);
		[DllImport("user32")] public static extern int SetCapture(HWND hwnd);
		[DllImport("user32")] public static extern int SetCaretBlinkTime(int wMSeconds);
		[DllImport("user32")] public static extern int SetCaretPos(int x, int y);
		[DllImport("user32")] public static extern int SetClassLong(HWND hwnd, int nIndex, int dwNewLong);
		[DllImport("user32")] public static extern int SetClassWord(HWND hwnd, int nIndex, int wNewWord);
		[DllImport("user32")] public static extern int SetClipboardData(int wFormat, HANDLE hMem);
		[DllImport("user32")] public static extern int SetClipboardViewer(HWND hwnd);
		[DllImport("user32")] public static extern int SetCursor(HANDLE hCursor);
		[DllImport("user32")] public static extern int SetCursorPos(int x, int y);
		[DllImport("user32")] public static extern int SetDlgItemInt(HANDLE hDlg, int nIDDlgItem, int wValue, int bSigned);
		[DllImport("user32")] public static extern int SetDlgItemText(HANDLE hDlg, int nIDDlgItem, string lpString);
		[DllImport("user32")] public static extern int SetDoubleClickTime(int wCount);
        /// <summary>
        /// Sets the keyboard focus to the specified window. The window must be attached to the calling thread's message queue.
        /// </summary>
        /// <param name="hwnd">A handle to the window that will receive the keyboard input. If this parameter is NULL, keystrokes are ignored.</param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the window that previously had the keyboard focus. If the hWnd parameter is invalid or the window is not attached to the calling thread's message queue, the return value is NULL. To get extended error information, call GetLastError.
        /// </returns>
		[DllImport("user32")] public static extern int SetFocus(HWND hwnd);
		[DllImport("user32")] public static extern int SetForegroundWindow(HWND hwnd);
		[DllImport("user32")] public static extern int SetKeyboardState(Byte lppbKeyState);
		[DllImport("user32")] public static extern int SetMenu(HWND hwnd, HANDLE hMenu);
		[DllImport("user32")] public static extern int SetMenuContextHelpId(HANDLE hMenu, int dw);
		[DllImport("user32")] public static extern int SetMenuDefaultItem(HANDLE hMenu, int uItem, int fByPos);
		[DllImport("user32")] public static extern int SetMenuItemBitmaps(HANDLE hMenu, int nPosition, int wFlags, HANDLE hBitmapUnchecked, HANDLE hBitmapChecked);
		[DllImport("user32")] public static extern int SetMenuItemInfo(HANDLE hMenu, int un, bool b, ref MENUITEMINFO lpcMenuItemInfo);
		[DllImport("user32")] public static extern int SetMessageExtraInfo(int lParam);
		[DllImport("user32")] public static extern int SetMessageQueue(int cMessagesMax);
        /// <summary>
        /// Changes the parent window of the specified child window.
        /// <para></para>[Return] If the function succeeds, the return value is a handle to the previous parent window.
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </summary>
        /// <param name="hwndChild"></param>
        /// <param name="hwndNewParent"></param>
        [DllImport("user32")] public static extern IntPtr SetParent(HWND hwndChild, HWND hwndNewParent);
		[DllImport("user32")] public static extern int SetProcessWindowStation(HANDLE hWinSta);
		[DllImport("user32")] public static extern int SetProp(HWND hwnd, string lpString, HANDLE hData);
		[DllImport("user32")] public static extern int SetRect(ref RECT lpRect, int X1, int Y1, int X2, int Y2);
		[DllImport("user32")] public static extern int SetRectEmpty(ref RECT lpRect);
		[DllImport("user32")] public static extern int SetScrollInfo(HWND hwnd, int n, ref SCROLLINFO lpcScrollInfo, bool redraw);
		[DllImport("user32")] public static extern int SetScrollPos(HWND hwnd, int nBar, int nPos, int bRedraw);
		[DllImport("user32")] public static extern int SetScrollRange(HWND hwnd, int nBar, int nMinPos, int nMaxPos, int bRedraw);
		[DllImport("user32")] public static extern int SetSysColors(int nChanges, ref int lpSysColor, ref int lpColorValues);
        /// <summary>
        /// Enables an application to customize the system cursors. It replaces the contents of the system cursor specified by the id parameter with the contents of the cursor specified by the hcur parameter and then destroys hcur.
        /// </summary>
        /// <param name="hcur">A handle to the cursor. The function replaces the contents of the system cursor specified by id with the contents of the cursor handled by hcur.
        /// <para></para>The system destroys hcur by calling the DestroyCursor function. Therefore, hcur cannot be a cursor loaded using the LoadCursor function. To specify a cursor loaded from a resource, copy the cursor using the CopyCursor function, then pass the copy to SetSystemCursor.</param>
        /// <param name="id">The system cursor to replace with the contents of hcur. This parameter can be one of the following values.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
		[return : MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32")] public static extern bool SetSystemCursor(HANDLE hcur, int id);
        public enum CursorID
        {
            /// <summary>
            /// Standard arrow and small hourglass 
            /// </summary>
            OCR_APPSTARTING = 32650,
            /// <summary>
            /// Standard arrow 
            /// </summary>
            OCR_NORMAL = 32512,
            /// <summary>
            /// Crosshair 
            /// </summary>
            OCR_CROSS = 32515,
            /// <summary>
            /// Hand 
            /// </summary>
            OCR_HAND = 32649,
            /// <summary>
            /// Arrow and question mark 
            /// </summary>
            OCR_HELP = 32651,
            /// <summary>
            /// I-beam 
            /// </summary>
            OCR_IBEAM = 32513,
            /// <summary>
            /// Slashed circle 
            /// </summary>
            OCR_NO = 32648,
            /// <summary>
            /// Four-pointed arrow pointing north, south, east, and west 
            /// </summary>
            OCR_SIZEALL = 32646,
            /// <summary>
            /// Double-pointed arrow pointing northeast and southwest 
            /// </summary>
            OCR_SIZENESW = 32643,
            /// <summary>
            /// Double-pointed arrow pointing north and south 
            /// </summary>
            OCR_SIZENS = 32645,
            /// <summary>
            /// Double-pointed arrow pointing northwest and southeast 
            /// </summary>
            OCR_SIZENWSE = 32642,
            /// <summary>
            /// Double-pointed arrow pointing west and east 
            /// </summary>
            OCR_SIZEWE = 32644,
            /// <summary>
            /// Vertical arrow 
            /// </summary>
            OCR_UP = 32516,
            /// <summary>
            /// Hourglass 
            /// </summary>
            OCR_WAIT = 32514
        }
		[DllImport("user32")] public static extern int SetThreadDesktop(HANDLE hDesktop);
		[DllImport("user32")] public static extern int SetTimer(HWND hwnd, int nIDEvent, int uElapse, ref int lpTimerFunc);
		[DllImport("user32")] public static extern int SetUserObjectInformation(HANDLE hObj, int nIndex, IntPtr pvInfo, int nLength);
		[DllImport("user32")] public static extern int SetUserObjectSecurity(HANDLE hObj, ref int pSIRequested, ref SECURITY_DESCRIPTOR pSd);
		[DllImport("user32")] public static extern int SetWindowContextHelpId(HWND hwnd, int dw);
        /// <summary>
        /// Changes an attribute of the specified window. The function also sets the 32-bit (long) value at the specified offset into the extra window memory.
        /// </summary>
        /// <param name="hwnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <param name="GWL_Index">The zero-based offset to the value to be set. Valid values are in the range zero through the number of bytes of extra window memory, minus the size of an integer. To set any other value, specify one of the following values.</param>
        /// <param name="dwNewLong">The replacement (style) vlalue.</param>
        /// <returns>If the function succeeds, the return value is the previous value of the specified 32-bit integer.</returns>
		[DllImport("user32")] public static extern Int32 SetWindowLong(HWND hwnd, GWL_Value GWL_Index, int dwNewLong);
        /// <summary>
        /// hwnd에 해당하는 윈도우를 lpwndpl에 따라 재조정한다.
        /// </summary>
        /// <param name="hwnd">Window Handle</param>
        /// <param name="lpwndpl">WINDOWPLACEMENT</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32")] public static extern bool SetWindowPlacement(HWND hwnd, ref WINDOWPLACEMENT lpwndpl);

        /// <summary>
        /// hwnd에 해당하는 윈도우를 lpwndpl에 따라 재조정한다.
        /// <para></para>[Return] If the function succeeds, the return value is nonzero.
        /// </summary>
        /// <param name="Handle">Window Handle</param>
        /// <param name="WindowPlacementInfoStruct">WINDOWPLACEMENT</param>
        /// <returns></returns>
        public static bool SetWindowPlacement_Wrapper(IntPtr Handle, ref WINDOWPLACEMENT WindowPlacementInfoStruct)
        {
            WindowPlacementInfoStruct.Length = (uint)Marshal.SizeOf(WindowPlacementInfoStruct);
            return SetWindowPlacement(Handle, ref WindowPlacementInfoStruct);
        }
        [DllImport("user32")] public static extern int SetWindowPos(HWND hwnd, HWND hwndInsertAfter, int x, int y, int cx, int cy, int wFlags);
		[DllImport("user32")] public static extern int SetWindowRgn(HWND hwnd, HANDLE hRgn, int bRedraw);
		[DllImport("user32")] public static extern int SetWindowText(HWND hwnd, string lpString);
		[DllImport("user32")] public static extern int SetWindowWord(HWND hwnd, int nIndex, int wNewWord);
		[DllImport("user32")] public static extern int SetWindowsHook(int nFilterType, ref int pfnFilterProc);
        /// <summary>
        /// This function helps the developers to hook procedure and do some work. By calling this funcion, developer can install a code for particular hook procedures.
        /// The code is installed at the beginning of the correspoding hook chain; after installed, whenever an event occurs that is monitored by a particular type of hook, the system calls the procedure (installed code) at the beginning of the hook chain associated with the hook.
        /// <para>Main purpose of this function is to determine whether to pass this event to the next procedure or not.
        /// If the event has to be passed, you can pass by calling CallNextHookEx function.</para>
        /// <para>Hook Chains : The system supports many different types of hooks; each type provides access to a different aspect of its message-handling mechanism. For example, an application can use the WH_MOUSE hook to monitor the message traffic for mouse messages. : </para>
        /// <para>Hook : Mechanism by which an application can intercept events, such as messages, mouse actions, and keystrokes</para>
        /// <para>Hook Type : Global Hook, Thread-Specific Hook</para>
        /// </summary>
        /// <param name="idHook">Hook Id.</param>
        /// <param name="lpfn">Refer CBTProc description.</param>
        /// <param name="hmod">A handle to the DLL containing the hook procedure pointed to by the lpfn parameter. The hMod parameter must be set to NULL(IntPtr.Zero) if the dwThreadId parameter specifies a thread created by the current process and if the hook procedure is within the code associated with the current process.</param>
        /// <param name="dwThreadId">The identifier of the thread with which the hook procedure is to be associated. For desktop apps, if this parameter is zero, the hook procedure is associated with all existing threads running in the same desktop as the calling thread. For Windows Store apps, see the Remarks section.</param>
        /// <returns>the handle to the HookProcedure</returns>
		[DllImport("user32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)] 
        public static extern IntPtr SetWindowsHookEx(WindowHook idHook, CBTProc lpfn, HANDLE hmod, AppHook.HookProcedureHandle dwThreadId);

        /// <summary>
        /// This function helps the developers to hook procedure and do some work. By calling this funcion, developer can install a code for particular hook procedures.
        /// The code is installed at the beginning of the correspoding hook chain; after installed, whenever an event occurs that is monitored by a particular type of hook, the system calls the procedure (installed code) at the beginning of the hook chain associated with the hook.
        /// <para>Main purpose of this function is to determine whether to pass this event to the next procedure or not.
        /// If the event has to be passed, you can pass by calling CallNextHookEx function.</para>
        /// <para>Hook Chains : The system supports many different types of hooks; each type provides access to a different aspect of its message-handling mechanism. For example, an application can use the WH_MOUSE hook to monitor the message traffic for mouse messages. : </para>
        /// <para>Hook : Mechanism by which an application can intercept events, such as messages, mouse actions, and keystrokes</para>
        /// <para>Hook Type : Global Hook, Thread-Specific Hook</para>
        /// </summary>
        /// <param name="idHook">Hook Id.</param>
        /// <param name="lpfn">Refer CBTProc description.</param>
        /// <param name="hmod">A handle to the DLL containing the hook procedure pointed to by the lpfn parameter. The hMod parameter must be set to NULL(IntPtr.Zero) if the dwThreadId parameter specifies a thread created by the current process and if the hook procedure is within the code associated with the current process.</param>
        /// <param name="dwThreadId">The identifier of the thread with which the hook procedure is to be associated. For desktop apps, if this parameter is zero, the hook procedure is associated with all existing threads running in the same desktop as the calling thread. For Windows Store apps, see the Remarks section.</param>
        /// <returns>the handle to the HookProcedure</returns>
        [DllImport("user32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(WindowHook idHook, MouseProc lpfn, HANDLE hmod, AppHook.HookProcedureHandle dwThreadId);

        /// <summary>
        /// This function helps the developers to hook procedure and do some work. By calling this funcion, developer can install a code for particular hook procedures.
        /// The code is installed at the beginning of the correspoding hook chain; after installed, whenever an event occurs that is monitored by a particular type of hook, the system calls the procedure (installed code) at the beginning of the hook chain associated with the hook.
        /// <para>Main purpose of this function is to determine whether to pass this event to the next procedure or not.
        /// If the event has to be passed, you can pass by calling CallNextHookEx function.</para>
        /// <para>Hook Chains : The system supports many different types of hooks; each type provides access to a different aspect of its message-handling mechanism. For example, an application can use the WH_MOUSE hook to monitor the message traffic for mouse messages. : </para>
        /// <para>Hook : Mechanism by which an application can intercept events, such as messages, mouse actions, and keystrokes</para>
        /// <para>Hook Type : Global Hook, Thread-Specific Hook</para>
        /// </summary>
        /// <param name="idHook">Hook Id.</param>
        /// <param name="lpfn">Refer CBTProc description.</param>
        /// <param name="hmod">A handle to the DLL containing the hook procedure pointed to by the lpfn parameter. The hMod parameter must be set to NULL(IntPtr.Zero) if the dwThreadId parameter specifies a thread created by the current process and if the hook procedure is within the code associated with the current process.</param>
        /// <param name="dwThreadId">The identifier of the thread with which the hook procedure is to be associated. For desktop apps, if this parameter is zero, the hook procedure is associated with all existing threads running in the same desktop as the calling thread. For Windows Store apps, see the Remarks section.</param>
        /// <returns>the handle to the HookProcedure</returns>
        [DllImport("user32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(WindowHook idHook, KeyBoardProc lpfn, HANDLE hmod, AppHook.HookProcedureHandle dwThreadId);


        /// <summary>
        /// This function helps the developers to hook procedure and do some work. By calling this funcion, developer can install a code for particular hook procedures.
        /// The code is installed at the beginning of the correspoding hook chain; after installed, whenever an event occurs that is monitored by a particular type of hook, the system calls the procedure (installed code) at the beginning of the hook chain associated with the hook.
        /// <para>Main purpose of this function is to determine whether to pass this event to the next procedure or not.
        /// If the event has to be passed, you can pass by calling CallNextHookEx function.</para>
        /// <para>Hook Chains : The system supports many different types of hooks; each type provides access to a different aspect of its message-handling mechanism. For example, an application can use the WH_MOUSE hook to monitor the message traffic for mouse messages. : </para>
        /// <para>Hook : Mechanism by which an application can intercept events, such as messages, mouse actions, and keystrokes</para>
        /// <para>Hook Type : Global Hook, Thread-Specific Hook</para>
        /// </summary>
        /// <param name="idHook">Hook Id.</param>
        /// <param name="lpfn">Refer CBTProc description.</param>
        /// <param name="hmod">A handle to the DLL containing the hook procedure pointed to by the lpfn parameter. The hMod parameter must be set to NULL(IntPtr.Zero) if the dwThreadId parameter specifies a thread created by the current process and if the hook procedure is within the code associated with the current process.</param>
        /// <param name="dwThreadId">The identifier of the thread with which the hook procedure is to be associated. For desktop apps, if this parameter is zero, the hook procedure is associated with all existing threads running in the same desktop as the calling thread. For Windows Store apps, see the Remarks section.</param>
        /// <returns>the handle to the HookProcedure</returns>
        [DllImport("user32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(WindowHook idHook, CBTProc_Hook lpfn, HANDLE hmod, IntPtr dwThreadId);

        /// <summary>
        /// This function helps the developers to hook procedure and do some work. By calling this funcion, developer can install a code for particular hook procedures.
        /// The code is installed at the beginning of the correspoding hook chain; after installed, whenever an event occurs that is monitored by a particular type of hook, the system calls the procedure (installed code) at the beginning of the hook chain associated with the hook.
        /// <para>Main purpose of this function is to determine whether to pass this event to the next procedure or not.
        /// If the event has to be passed, you can pass by calling CallNextHookEx function.</para>
        /// <para>Hook Chains : The system supports many different types of hooks; each type provides access to a different aspect of its message-handling mechanism. For example, an application can use the WH_MOUSE hook to monitor the message traffic for mouse messages. : </para>
        /// <para>Hook : Mechanism by which an application can intercept events, such as messages, mouse actions, and keystrokes</para>
        /// <para>Hook Type : Global Hook, Thread-Specific Hook</para>
        /// </summary>
        /// <param name="idHook">Hook Id.</param>
        /// <param name="lpfn">Refer CBTProc description.</param>
        /// <param name="hmod">A handle to the DLL containing the hook procedure pointed to by the lpfn parameter. The hMod parameter must be set to NULL(IntPtr.Zero) if the dwThreadId parameter specifies a thread created by the current process and if the hook procedure is within the code associated with the current process.</param>
        /// <param name="dwThreadId">The identifier of the thread with which the hook procedure is to be associated. For desktop apps, if this parameter is zero, the hook procedure is associated with all existing threads running in the same desktop as the calling thread. For Windows Store apps, see the Remarks section.</param>
        /// <returns>the handle to the HookProcedure</returns>
        [DllImport("user32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(WindowHook idHook, CBTProc_Hook lpfn, HANDLE hmod, AppHook.HookProcedureHandle dwThreadId);

        /// <summary>
        /// The repeat count. The value is the number of times the keystroke is repeated as a result of the user's holding down the key.
        /// </summary>
        /// <param name="lParam">KeyboardProc lParam</param>
        /// <returns></returns>
        public static int KeyBoardHook_GetRepeatCount(int lParam)
        {
            return (lParam & 0x0000FFFF);
        }
        /// <summary>
        /// The scan code. The value depends on the OEM.
        /// </summary>
        /// <param name="lParam">KeyboardProc lParam</param>
        /// <returns></returns>
        public static int KeyBoardHook_GetScanCode(int lParam)
        {
            return (lParam & 0x00FF0000)<<16;
        }
        /// <summary>
        /// Indicates whether the key is an extended key, such as a function key or a key on the numeric keypad. The value is 1 if the key is an extended key; otherwise, it is 0.
        /// </summary>
        /// <param name="lParam">KeyboardProc lParam</param>
        /// <returns></returns>
        public static bool KeyBoardHook_IsExtendedKey(int lParam)
        {
            bool Result = false;
            bool.TryParse(((lParam & 0x01000000) << 24).ToString(), out Result);
            return Result;
        }
        /// <summary>
        /// The context code. The value is 1 if the ALT key is down; otherwise, it is 0.
        /// </summary>
        /// <param name="lParam">KeyboardProc lParam</param>
        /// <returns></returns>
        public static bool KeyBoardHook_IsAltDown(int lParam)
        {
            bool Result = false;
            bool.TryParse(((lParam & 0xD0000000) << 29).ToString(), out Result);
            return Result;
        }
        /// <summary>
        /// The previous key state. The value is 1 if the key is down before the message is sent; it is 0 if the key is up.
        /// </summary>
        /// <param name="lParam">KeyboardProc lParam</param>
        /// <returns></returns>
        public static bool KeyBoardHook_PreviousKeyState(int lParam)
        {
            bool Result = false;
            bool.TryParse(((lParam & 0xE0000000) << 30).ToString(), out Result);
            return Result;
        }
        /// <summary>
        /// The transition state. The value is 0 if the key is being pressed and 1 if it is being released.
        /// </summary>
        /// <param name="lParam">KeyboardProc lParam</param>
        /// <returns></returns>
        public static bool KeyBoardHook_IsKeyHold(int lParam)
        {
            bool Result = false;
            bool.TryParse(((lParam & 0xF0000000) << 31).ToString(), out Result);
            return Result;
        }
        public delegate IntPtr HookProcedure(int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32")] public static extern int ShowCaret(HWND hwnd);
		[DllImport("user32")] public static extern int ShowCursor(int bShow);
		[DllImport("user32")] public static extern int ShowOwnedPopups(HWND hwnd, int fShow);
		[DllImport("user32")] public static extern int ShowScrollBar(HWND hwnd, int wBar, int bShow);
		[DllImport("user32")] public static extern int ShowWindow(HWND hwnd, int nCmdShow);
		[DllImport("user32")] public static extern int ShowWindowAsync(HWND hwnd, int nCmdShow);
		[DllImport("user32")] public static extern int SubtractRect(ref RECT lprcDst, ref RECT lprcSrc1, ref RECT lprcSrc2);
		[DllImport("user32")] public static extern int SwapMouseButton(int bSwap);
		[DllImport("user32")] public static extern int SwitchDesktop(HANDLE hDesktop);
		[DllImport("user32")] public static extern int SystemParametersInfo(int uAction, int uParam, ref IntPtr lpvParam, int fuWinIni);
		[DllImport("user32")] public static extern int TabbedTextOut(HDC hdc, int x, int y, string lpString, int nCount, int nTabPositions, ref int lpnTabStopPositions, int nTabOrigin);
		[DllImport("user32")] public static extern int ToAscii(int uVirtKey, int uScanCode, Byte lpbKeyState, ref int lpwTransKey, int fuState);
		[DllImport("user32")] public static extern int ToAsciiEx(int uVirtKey, int uScanCode, Byte lpKeyState, short lpChar, int uFlags, int dwhkl);
		[DllImport("user32")] public static extern int ToUnicode(int wVirtKey, int wScanCode, Byte lpKeyState, string pwszBuff, int cchBuff, int wFlags);
		[DllImport("user32")] public static extern int TrackPopupMenu(HANDLE hMenu, int wFlags, int x, int y, int nReserved, HWND hwnd, ref RECT lprc);
		[DllImport("user32")] public static extern int TrackPopupMenuEx(HANDLE hMenu, int un, int n1, int n2, HWND hwnd, ref TPMPARAMS lpTPMParams);
		[DllImport("user32")] public static extern int TranslateAccelerator(HWND hwnd, HANDLE hAccTable, ref MSG lpMsg);
		[DllImport("user32")] public static extern int TranslateMDISysAccel(HWND hwndClient, ref MSG lpMsg);
		[DllImport("user32")] public static extern int TranslateMessage(ref MSG lpMsg);
        
        [DllImport("user32")] 
        public static extern bool UnhookWindowsHook(int nCode, ref int pfnFilterProc);
        /// <summary>
        /// Removes a hook procedure installed in a hook chain by the SetWindowsHookEx function.
        /// <para></para>[Returns]
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </summary>
        /// <param name="hHook">
        /// A handle to the hook to be removed. This parameter is a hook handle obtained by a previous call to SetWindowsHookEx.
        /// </param>

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32")] 
        public static extern bool UnhookWindowsHookEx(HANDLE hHook);
		[DllImport("user32")] public static extern int UnionRect(ref RECT lpDestRect, ref RECT lpSrc1Rect, ref RECT lpSrc2Rect);
		[DllImport("user32")] public static extern int UnloadKeyboardLayout(HANDLE hKL);
		[DllImport("user32")] public static extern int UnpackDDElParam(int msg, int lParam, ref int puiLo, ref int puiHi);
		[DllImport("user32")] public static extern int UnregisterClass(string lpClassName, HANDLE hInstance);
		[DllImport("user32")] public static extern int UnregisterHotKey(HWND hwnd, int id);
		[DllImport("user32")] public static extern int UpdateWindow(HWND hwnd);
		[DllImport("user32")] public static extern int ValidateRect(HWND hwnd, ref RECT lpRect);
		[DllImport("user32")] public static extern int ValidateRgn(HWND hwnd, HANDLE hRgn);
		[DllImport("user32")] public static extern int WaitForInputIdle(HANDLE hProcess, int dwMilliseconds);
		[DllImport("user32")] public static extern int WaitMessage();
		[DllImport("user32")] public static extern int WinHelp(HWND hwnd, string lpHelpFile, int wCommand, int dwData);
		[DllImport("user32")] public static extern int WindowFromDC(HDC hdc);
        /// <summary>
        /// This function retrieves the handle to the window that contains the specified point.
        /// <para></para>[Return] A handle to the window that contains the point indicates success. NULL indicates that no window exists at the specified point. A handle to the window under the static text control indicates that the point is over a static text control.
        /// </summary>
        /// <param name="xPoint"></param>
        /// <param name="yPoint"></param>
        /// <returns>A handle to the window that contains the point indicates success. NULL indicates that no window exists at the specified point. A handle to the window under the static text control indicates that the point is over a static text control.</returns>
		[DllImport("user32")] public static extern IntPtr WindowFromPoint(int xPoint, int yPoint);
		[DllImport("user32")] public static extern short CascadeWindows(HWND hwndParent, int wHow, ref RECT lpRect, int cKids, ref int lpkids);
		[DllImport("user32")] public static extern short GetAsyncKeyState(int vKey);
        /// <summary>
        /// true면 KeyDown, false면 KeyUp
        /// </summary>
        /// <param name="nVirtKey"></param>
        /// <returns></returns>
        public static bool GetKeyState_Down(VK_Keys nVirtKey)
        {
            if ((WINAPI.User.GetKeyState(nVirtKey) & 0x8000) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// true면 KeyUp, false면 KeyDown
        /// </summary>
        /// <param name="nVirtKey"></param>
        /// <returns></returns>
        public static bool GetKeyState_Up(VK_Keys nVirtKey)
        {
            if ((WINAPI.User.GetKeyState(nVirtKey) & 0x8000) <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Retrieves the status of the specified virtual key. The status specifies whether the key is up, down, or toggled (on, off—alternating each time the key is pressed).
        /// <para></para>If the high-order bit is 1, the key is down; otherwise, it is up.
        /// <para></para>If the low-order bit is 1, the key is toggled. A key, such as the CAPS LOCK key, is toggled if it is turned on. The key is off and untoggled if the low-order bit is 0. A toggle key's indicator light (if any) on the keyboard will be on when the key is toggled, and off when the key is untoggled.
        /// </summary>
        /// <param name="nVirtKey">가상키
        /// <para></para> 참고사이트 : https://docs.microsoft.com/ko-kr/windows/win32/inputdev/virtual-key-codes
        /// <para></para> 코드사이트 : https://referencesource.microsoft.com/#WindowsBase/Shared/MS/Win32/NativeMethodsOther.cs,d2106c28bf76ae2c
        /// </param>
        /// <returns></returns>
		[DllImport("user32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)] 
        public static extern short GetKeyState(VK_Keys nVirtKey);
		[DllImport("user32")] public static extern short GetWindowWord(HWND hwnd, int nIndex);
		[DllImport("user32")] public static extern short RegisterClassEx(ref WNDCLASSEX pcWndClassEx);
        /// <summary>
        /// Tiles the specified child windows of the specified parent window. (윈도우 이어붙이기)
        /// </summary>
        /// <param name="hwndParent">A handle to the parent window. If this parameter is NULL, the desktop window is assumed.</param>
        /// <param name="Orientation">The tiling flags. This parameter can be one of the following values—optionally combined with MDITILE_SKIPDISABLED to prevent disabled MDI child windows from being tiled.</param>
        /// <param name="RectsOfWindows">A pointer to a structure that specifies the rectangular area, in client coordinates, within which the windows are arranged. If this parameter is NULL, the client area of the parent window is used.</param>
        /// <param name="TotalCounts">The number of elements in the array specified by the lpKids parameter. This parameter is ignored if lpKids is NULL.</param>
        /// <param name="HwndsOfWindows">An array of handles to the child windows to arrange. If a specified child window is a top-level window with the style WS_EX_TOPMOST or WS_EX_TOOLWINDOW, the child window is not arranged. If this parameter is NULL, all child windows of the specified parent window (or of the desktop window) are arranged.</param>
        /// <returns>If the function succeeds, the return value is the number of windows arranged.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
		[DllImport("user32")] public static extern ushort TileWindows(HWND hwndParent, MDITILE_STYLE Orientation, RECT[] RectsOfWindows, int TotalCounts, IntPtr[] HwndsOfWindows);
		public enum MDITILE_STYLE 
        {
            /// <summary>
            /// Tiles windows horizontally. 
            /// </summary>
            MDITILE_HORIZONTAL = 0x0001,
            /// <summary>
            /// Tiles windows vertically. 
            /// </summary>
            MDITILE_VERTICAL = 0x0000
        }
        [DllImport("user32")] public static extern short VkKeyScan(Byte cChar);
		[DllImport("user32")] public static extern short VkKeyScanEx(Byte ch, int dwhkl);
		[DllImport("user32")] public static extern string CharLower(string lpsz);
		[DllImport("user32")] public static extern string CharNext(string lpsz);
		[DllImport("user32")] public static extern string CharPrev(string lpszStart, string lpszCurrent);
		[DllImport("user32")] public static extern string CharUpper(string lpsz);
		[DllImport("user32")] public static extern void PostQuitMessage(int nExitCode);
        /// <summary>
        /// Synthesizes a keystroke. The system can use such a synthesized keystroke to generate a WM_KEYUP or WM_KEYDOWN message. The keyboard driver's interrupt handler calls the keybd_event function.
        /// </summary>
        /// <param name="Virtual_Keycode"></param>
        /// <param name="KeyScanCode">Virtual_Keycode Scan Code. (When not Used, input 0. Normally, this var is not used.)</param>
        /// <param name="dwFlags">0이면 KeyDown, 2면 KeyUp상태</param>
        /// <param name="dwExtraInfo"></param>
		[DllImport("user32")] public static extern void keybd_event(VK_Keys Virtual_Keycode, Byte KeyScanCode, int dwFlags, int dwExtraInfo);
        /// <summary>
        /// The mouse_event function synthesizes mouse motion and button clicks.
        /// <para>Note!! This function has been superseded. Use SendInput instead.</para>
        /// </summary>
        /// <param name="dwFlags">Controls various aspects of mouse motion and button clicking. This parameter can be certain combinations of the following values.</param>
        /// <param name="dx">The mouse's absolute position along the x-axis or its amount of motion since the last mouse event was generated, depending on the setting of MOUSEEVENTF_ABSOLUTE. Absolute data is specified as the mouse's actual x-coordinate; relative data is specified as the number of mickeys moved. A mickey is the amount that a mouse has to move for it to report that it has moved.</param>
        /// <param name="dy">The mouse's absolute position along the y-axis or its amount of motion since the last mouse event was generated, depending on the setting of MOUSEEVENTF_ABSOLUTE. Absolute data is specified as the mouse's actual y-coordinate; relative data is specified as the number of mickeys moved.</param>
        /// <param name="dwData">
        /// If dwFlags contains MOUSEEVENTF_WHEEL, then dwData specifies the amount of wheel movement. A positive value indicates that the wheel was rotated forward, away from the user; a negative value indicates that the wheel was rotated backward, toward the user. One wheel click is defined as WHEEL_DELTA, which is 120.
        /// <para>If dwFlags contains MOUSEEVENTF_HWHEEL, then dwData specifies the amount of wheel movement. A positive value indicates that the wheel was tilted to the right; a negative value indicates that the wheel was tilted to the left.</para>
        /// <para>If dwFlags contains MOUSEEVENTF_XDOWN or MOUSEEVENTF_XUP, then dwData specifies which X buttons were pressed or released. This value may be any combination of the following flags.</para>
        /// <para>If dwFlags is not MOUSEEVENTF_WHEEL, MOUSEEVENTF_XDOWN, or MOUSEEVENTF_XUP, then dwData should be zero.</para>
        /// <para></para> Ref Site : https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-mouse_event
        /// </param>
        /// <param name="dwExtraInfo">An additional value associated with the mouse event. An application calls GetMessageExtraInfo to obtain this extra information.
        /// <para></para> Ref Site : https://docs.microsoft.com/ko-kr/windows/win32/api/winuser/nf-winuser-setmessageextrainfo
        /// </param>
		[DllImport("user32")]
        public static extern void mouse_event(MOUSE_EVENT dwFlags, int dx, int dy, int dwData, UIntPtr dwExtraInfo);

        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT
        {
            internal InputType type;
            internal InputUnion U;
            internal static int Size
            {
                get { return Marshal.SizeOf(typeof(INPUT)); }
            }
        }

        internal enum InputType : uint
        {
            /// <summary>
            /// The event is a mouse event. Use the mi structure of the union. 
            /// </summary>
            INPUT_MOUSE = 0,
            /// <summary>
            /// The event is a keyboard event. Use the ki structure of the union. 
            /// </summary>
            INPUT_KEYBOARD = 1,
            /// <summary>
            /// The event is a hardware event. Use the hi structure of the union. 
            /// </summary>
            INPUT_HARDWARE = 2
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct InputUnion
        {
            [FieldOffset(0)]
            internal MOUSEINPUT _MOUSEINPUT;
            [FieldOffset(0)]
            internal KEYBDINPUT _KEYBDINPUT;
            [FieldOffset(0)]
            internal HARDWAREINPUT _HARDWAREINPUT;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct MOUSEINPUT
        {
            internal int dx;
            internal int dy;
            internal int mouseData;
            internal MOUSEEVENTF dwFlags;
            internal uint time;
            internal UIntPtr dwExtraInfo;
        }
        [Flags]
        internal enum MOUSEEVENTF : uint
        {
            ABSOLUTE = 0x8000,
            HWHEEL = 0x01000,
            MOVE = 0x0001,
            MOVE_NOCOALESCE = 0x2000,
            LEFTDOWN = 0x0002,
            LEFTUP = 0x0004,
            RIGHTDOWN = 0x0008,
            RIGHTUP = 0x0010,
            MIDDLEDOWN = 0x0020,
            MIDDLEUP = 0x0040,
            VIRTUALDESK = 0x4000,
            WHEEL = 0x0800,
            XDOWN = 0x0080,
            XUP = 0x0100
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct KEYBDINPUT
        {
            internal VK_Keys wVk;
            internal ScanCodeShort wScan;
            internal KEYEVENTF dwFlags;
            internal int time;
            internal UIntPtr dwExtraInfo;
        }

        [Flags]
        internal enum KEYEVENTF : uint
        {
            /// <summary>
            /// If specified, the scan code was preceded by a prefix byte that has the value 0xE0 (224).
            /// </summary>
            EXTENDEDKEY = 0x0001,
            /// <summary>
            /// If specified, the key is being released. If not specified, the key is being pressed.
            /// </summary>
            KEYUP = 0x0002,
            /// <summary>
            /// If specified, wScan identifies the key and wVk is ignored. 
            /// </summary>
            SCANCODE = 0x0008,
            /// <summary>
            /// If specified, the system synthesizes a VK_PACKET keystroke. The wVk parameter must be zero. This flag can only be combined with the KEYEVENTF_KEYUP flag. For more information, see the Remarks section.
            /// </summary>
            UNICODE = 0x0004
        }

        internal enum VirtualKeyShort : short
        {
            ///<summary>
            ///Left mouse button
            ///</summary>
            LBUTTON = 0x01,
            ///<summary>
            ///Right mouse button
            ///</summary>
            RBUTTON = 0x02,
            ///<summary>
            ///Control-break processing
            ///</summary>
            CANCEL = 0x03,
            ///<summary>
            ///Middle mouse button (three-button mouse)
            ///</summary>
            MBUTTON = 0x04,
            ///<summary>
            ///Windows 2000/XP: X1 mouse button
            ///</summary>
            XBUTTON1 = 0x05,
            ///<summary>
            ///Windows 2000/XP: X2 mouse button
            ///</summary>
            XBUTTON2 = 0x06,
            ///<summary>
            ///BACKSPACE key
            ///</summary>
            BACK = 0x08,
            ///<summary>
            ///TAB key
            ///</summary>
            TAB = 0x09,
            ///<summary>
            ///CLEAR key
            ///</summary>
            CLEAR = 0x0C,
            ///<summary>
            ///ENTER key
            ///</summary>
            RETURN = 0x0D,
            ///<summary>
            ///SHIFT key
            ///</summary>
            SHIFT = 0x10,
            ///<summary>
            ///CTRL key
            ///</summary>
            CONTROL = 0x11,
            ///<summary>
            ///ALT key
            ///</summary>
            MENU = 0x12,
            ///<summary>
            ///PAUSE key
            ///</summary>
            PAUSE = 0x13,
            ///<summary>
            ///CAPS LOCK key
            ///</summary>
            CAPITAL = 0x14,
            ///<summary>
            ///Input Method Editor (IME) Kana mode
            ///</summary>
            KANA = 0x15,
            ///<summary>
            ///IME Hangul mode
            ///</summary>
            HANGUL = 0x15,
            ///<summary>
            ///IME Junja mode
            ///</summary>
            JUNJA = 0x17,
            ///<summary>
            ///IME final mode
            ///</summary>
            FINAL = 0x18,
            ///<summary>
            ///IME Hanja mode
            ///</summary>
            HANJA = 0x19,
            ///<summary>
            ///IME Kanji mode
            ///</summary>
            KANJI = 0x19,
            ///<summary>
            ///ESC key
            ///</summary>
            ESCAPE = 0x1B,
            ///<summary>
            ///IME convert
            ///</summary>
            CONVERT = 0x1C,
            ///<summary>
            ///IME nonconvert
            ///</summary>
            NONCONVERT = 0x1D,
            ///<summary>
            ///IME accept
            ///</summary>
            ACCEPT = 0x1E,
            ///<summary>
            ///IME mode change request
            ///</summary>
            MODECHANGE = 0x1F,
            ///<summary>
            ///SPACEBAR
            ///</summary>
            SPACE = 0x20,
            ///<summary>
            ///PAGE UP key
            ///</summary>
            PRIOR = 0x21,
            ///<summary>
            ///PAGE DOWN key
            ///</summary>
            NEXT = 0x22,
            ///<summary>
            ///END key
            ///</summary>
            END = 0x23,
            ///<summary>
            ///HOME key
            ///</summary>
            HOME = 0x24,
            ///<summary>
            ///LEFT ARROW key
            ///</summary>
            LEFT = 0x25,
            ///<summary>
            ///UP ARROW key
            ///</summary>
            UP = 0x26,
            ///<summary>
            ///RIGHT ARROW key
            ///</summary>
            RIGHT = 0x27,
            ///<summary>
            ///DOWN ARROW key
            ///</summary>
            DOWN = 0x28,
            ///<summary>
            ///SELECT key
            ///</summary>
            SELECT = 0x29,
            ///<summary>
            ///PRINT key
            ///</summary>
            PRINT = 0x2A,
            ///<summary>
            ///EXECUTE key
            ///</summary>
            EXECUTE = 0x2B,
            ///<summary>
            ///PRINT SCREEN key
            ///</summary>
            SNAPSHOT = 0x2C,
            ///<summary>
            ///INS key
            ///</summary>
            INSERT = 0x2D,
            ///<summary>
            ///DEL key
            ///</summary>
            DELETE = 0x2E,
            ///<summary>
            ///HELP key
            ///</summary>
            HELP = 0x2F,
            ///<summary>
            ///0 key
            ///</summary>
            KEY_0 = 0x30,
            ///<summary>
            ///1 key
            ///</summary>
            KEY_1 = 0x31,
            ///<summary>
            ///2 key
            ///</summary>
            KEY_2 = 0x32,
            ///<summary>
            ///3 key
            ///</summary>
            KEY_3 = 0x33,
            ///<summary>
            ///4 key
            ///</summary>
            KEY_4 = 0x34,
            ///<summary>
            ///5 key
            ///</summary>
            KEY_5 = 0x35,
            ///<summary>
            ///6 key
            ///</summary>
            KEY_6 = 0x36,
            ///<summary>
            ///7 key
            ///</summary>
            KEY_7 = 0x37,
            ///<summary>
            ///8 key
            ///</summary>
            KEY_8 = 0x38,
            ///<summary>
            ///9 key
            ///</summary>
            KEY_9 = 0x39,
            ///<summary>
            ///A key
            ///</summary>
            KEY_A = 0x41,
            ///<summary>
            ///B key
            ///</summary>
            KEY_B = 0x42,
            ///<summary>
            ///C key
            ///</summary>
            KEY_C = 0x43,
            ///<summary>
            ///D key
            ///</summary>
            KEY_D = 0x44,
            ///<summary>
            ///E key
            ///</summary>
            KEY_E = 0x45,
            ///<summary>
            ///F key
            ///</summary>
            KEY_F = 0x46,
            ///<summary>
            ///G key
            ///</summary>
            KEY_G = 0x47,
            ///<summary>
            ///H key
            ///</summary>
            KEY_H = 0x48,
            ///<summary>
            ///I key
            ///</summary>
            KEY_I = 0x49,
            ///<summary>
            ///J key
            ///</summary>
            KEY_J = 0x4A,
            ///<summary>
            ///K key
            ///</summary>
            KEY_K = 0x4B,
            ///<summary>
            ///L key
            ///</summary>
            KEY_L = 0x4C,
            ///<summary>
            ///M key
            ///</summary>
            KEY_M = 0x4D,
            ///<summary>
            ///N key
            ///</summary>
            KEY_N = 0x4E,
            ///<summary>
            ///O key
            ///</summary>
            KEY_O = 0x4F,
            ///<summary>
            ///P key
            ///</summary>
            KEY_P = 0x50,
            ///<summary>
            ///Q key
            ///</summary>
            KEY_Q = 0x51,
            ///<summary>
            ///R key
            ///</summary>
            KEY_R = 0x52,
            ///<summary>
            ///S key
            ///</summary>
            KEY_S = 0x53,
            ///<summary>
            ///T key
            ///</summary>
            KEY_T = 0x54,
            ///<summary>
            ///U key
            ///</summary>
            KEY_U = 0x55,
            ///<summary>
            ///V key
            ///</summary>
            KEY_V = 0x56,
            ///<summary>
            ///W key
            ///</summary>
            KEY_W = 0x57,
            ///<summary>
            ///X key
            ///</summary>
            KEY_X = 0x58,
            ///<summary>
            ///Y key
            ///</summary>
            KEY_Y = 0x59,
            ///<summary>
            ///Z key
            ///</summary>
            KEY_Z = 0x5A,
            ///<summary>
            ///Left Windows key (Microsoft Natural keyboard) 
            ///</summary>
            LWIN = 0x5B,
            ///<summary>
            ///Right Windows key (Natural keyboard)
            ///</summary>
            RWIN = 0x5C,
            ///<summary>
            ///Applications key (Natural keyboard)
            ///</summary>
            APPS = 0x5D,
            ///<summary>
            ///Computer Sleep key
            ///</summary>
            SLEEP = 0x5F,
            ///<summary>
            ///Numeric keypad 0 key
            ///</summary>
            NUMPAD0 = 0x60,
            ///<summary>
            ///Numeric keypad 1 key
            ///</summary>
            NUMPAD1 = 0x61,
            ///<summary>
            ///Numeric keypad 2 key
            ///</summary>
            NUMPAD2 = 0x62,
            ///<summary>
            ///Numeric keypad 3 key
            ///</summary>
            NUMPAD3 = 0x63,
            ///<summary>
            ///Numeric keypad 4 key
            ///</summary>
            NUMPAD4 = 0x64,
            ///<summary>
            ///Numeric keypad 5 key
            ///</summary>
            NUMPAD5 = 0x65,
            ///<summary>
            ///Numeric keypad 6 key
            ///</summary>
            NUMPAD6 = 0x66,
            ///<summary>
            ///Numeric keypad 7 key
            ///</summary>
            NUMPAD7 = 0x67,
            ///<summary>
            ///Numeric keypad 8 key
            ///</summary>
            NUMPAD8 = 0x68,
            ///<summary>
            ///Numeric keypad 9 key
            ///</summary>
            NUMPAD9 = 0x69,
            ///<summary>
            ///Multiply key
            ///</summary>
            MULTIPLY = 0x6A,
            ///<summary>
            ///Add key
            ///</summary>
            ADD = 0x6B,
            ///<summary>
            ///Separator key
            ///</summary>
            SEPARATOR = 0x6C,
            ///<summary>
            ///Subtract key
            ///</summary>
            SUBTRACT = 0x6D,
            ///<summary>
            ///Decimal key
            ///</summary>
            DECIMAL = 0x6E,
            ///<summary>
            ///Divide key
            ///</summary>
            DIVIDE = 0x6F,
            ///<summary>
            ///F1 key
            ///</summary>
            F1 = 0x70,
            ///<summary>
            ///F2 key
            ///</summary>
            F2 = 0x71,
            ///<summary>
            ///F3 key
            ///</summary>
            F3 = 0x72,
            ///<summary>
            ///F4 key
            ///</summary>
            F4 = 0x73,
            ///<summary>
            ///F5 key
            ///</summary>
            F5 = 0x74,
            ///<summary>
            ///F6 key
            ///</summary>
            F6 = 0x75,
            ///<summary>
            ///F7 key
            ///</summary>
            F7 = 0x76,
            ///<summary>
            ///F8 key
            ///</summary>
            F8 = 0x77,
            ///<summary>
            ///F9 key
            ///</summary>
            F9 = 0x78,
            ///<summary>
            ///F10 key
            ///</summary>
            F10 = 0x79,
            ///<summary>
            ///F11 key
            ///</summary>
            F11 = 0x7A,
            ///<summary>
            ///F12 key
            ///</summary>
            F12 = 0x7B,
            ///<summary>
            ///F13 key
            ///</summary>
            F13 = 0x7C,
            ///<summary>
            ///F14 key
            ///</summary>
            F14 = 0x7D,
            ///<summary>
            ///F15 key
            ///</summary>
            F15 = 0x7E,
            ///<summary>
            ///F16 key
            ///</summary>
            F16 = 0x7F,
            ///<summary>
            ///F17 key  
            ///</summary>
            F17 = 0x80,
            ///<summary>
            ///F18 key  
            ///</summary>
            F18 = 0x81,
            ///<summary>
            ///F19 key  
            ///</summary>
            F19 = 0x82,
            ///<summary>
            ///F20 key  
            ///</summary>
            F20 = 0x83,
            ///<summary>
            ///F21 key  
            ///</summary>
            F21 = 0x84,
            ///<summary>
            ///F22 key, (PPC only) Key used to lock device.
            ///</summary>
            F22 = 0x85,
            ///<summary>
            ///F23 key  
            ///</summary>
            F23 = 0x86,
            ///<summary>
            ///F24 key  
            ///</summary>
            F24 = 0x87,
            ///<summary>
            ///NUM LOCK key
            ///</summary>
            NUMLOCK = 0x90,
            ///<summary>
            ///SCROLL LOCK key
            ///</summary>
            SCROLL = 0x91,
            ///<summary>
            ///Left SHIFT key
            ///</summary>
            LSHIFT = 0xA0,
            ///<summary>
            ///Right SHIFT key
            ///</summary>
            RSHIFT = 0xA1,
            ///<summary>
            ///Left CONTROL key
            ///</summary>
            LCONTROL = 0xA2,
            ///<summary>
            ///Right CONTROL key
            ///</summary>
            RCONTROL = 0xA3,
            ///<summary>
            ///Left MENU key
            ///</summary>
            LMENU = 0xA4,
            ///<summary>
            ///Right MENU key
            ///</summary>
            RMENU = 0xA5,
            ///<summary>
            ///Windows 2000/XP: Browser Back key
            ///</summary>
            BROWSER_BACK = 0xA6,
            ///<summary>
            ///Windows 2000/XP: Browser Forward key
            ///</summary>
            BROWSER_FORWARD = 0xA7,
            ///<summary>
            ///Windows 2000/XP: Browser Refresh key
            ///</summary>
            BROWSER_REFRESH = 0xA8,
            ///<summary>
            ///Windows 2000/XP: Browser Stop key
            ///</summary>
            BROWSER_STOP = 0xA9,
            ///<summary>
            ///Windows 2000/XP: Browser Search key 
            ///</summary>
            BROWSER_SEARCH = 0xAA,
            ///<summary>
            ///Windows 2000/XP: Browser Favorites key
            ///</summary>
            BROWSER_FAVORITES = 0xAB,
            ///<summary>
            ///Windows 2000/XP: Browser Start and Home key
            ///</summary>
            BROWSER_HOME = 0xAC,
            ///<summary>
            ///Windows 2000/XP: Volume Mute key
            ///</summary>
            VOLUME_MUTE = 0xAD,
            ///<summary>
            ///Windows 2000/XP: Volume Down key
            ///</summary>
            VOLUME_DOWN = 0xAE,
            ///<summary>
            ///Windows 2000/XP: Volume Up key
            ///</summary>
            VOLUME_UP = 0xAF,
            ///<summary>
            ///Windows 2000/XP: Next Track key
            ///</summary>
            MEDIA_NEXT_TRACK = 0xB0,
            ///<summary>
            ///Windows 2000/XP: Previous Track key
            ///</summary>
            MEDIA_PREV_TRACK = 0xB1,
            ///<summary>
            ///Windows 2000/XP: Stop Media key
            ///</summary>
            MEDIA_STOP = 0xB2,
            ///<summary>
            ///Windows 2000/XP: Play/Pause Media key
            ///</summary>
            MEDIA_PLAY_PAUSE = 0xB3,
            ///<summary>
            ///Windows 2000/XP: Start Mail key
            ///</summary>
            LAUNCH_MAIL = 0xB4,
            ///<summary>
            ///Windows 2000/XP: Select Media key
            ///</summary>
            LAUNCH_MEDIA_SELECT = 0xB5,
            ///<summary>
            ///Windows 2000/XP: Start Application 1 key
            ///</summary>
            LAUNCH_APP1 = 0xB6,
            ///<summary>
            ///Windows 2000/XP: Start Application 2 key
            ///</summary>
            LAUNCH_APP2 = 0xB7,
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard.
            ///</summary>
            OEM_1 = 0xBA,
            ///<summary>
            ///Windows 2000/XP: For any country/region, the '+' key
            ///</summary>
            OEM_PLUS = 0xBB,
            ///<summary>
            ///Windows 2000/XP: For any country/region, the ',' key
            ///</summary>
            OEM_COMMA = 0xBC,
            ///<summary>
            ///Windows 2000/XP: For any country/region, the '-' key
            ///</summary>
            OEM_MINUS = 0xBD,
            ///<summary>
            ///Windows 2000/XP: For any country/region, the '.' key
            ///</summary>
            OEM_PERIOD = 0xBE,
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard.
            ///</summary>
            OEM_2 = 0xBF,
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard. 
            ///</summary>
            OEM_3 = 0xC0,
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard. 
            ///</summary>
            OEM_4 = 0xDB,
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard. 
            ///</summary>
            OEM_5 = 0xDC,
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard. 
            ///</summary>
            OEM_6 = 0xDD,
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard. 
            ///</summary>
            OEM_7 = 0xDE,
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard.
            ///</summary>
            OEM_8 = 0xDF,
            ///<summary>
            ///Windows 2000/XP: Either the angle bracket key or the backslash key on the RT 102-key keyboard
            ///</summary>
            OEM_102 = 0xE2,
            ///<summary>
            ///Windows 95/98/Me, Windows NT 4.0, Windows 2000/XP: IME PROCESS key
            ///</summary>
            PROCESSKEY = 0xE5,
            ///<summary>
            ///Windows 2000/XP: Used to pass Unicode characters as if they were keystrokes.
            ///The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information,
            ///see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP
            ///</summary>
            PACKET = 0xE7,
            ///<summary>
            ///Attn key
            ///</summary>
            ATTN = 0xF6,
            ///<summary>
            ///CrSel key
            ///</summary>
            CRSEL = 0xF7,
            ///<summary>
            ///ExSel key
            ///</summary>
            EXSEL = 0xF8,
            ///<summary>
            ///Erase EOF key
            ///</summary>
            EREOF = 0xF9,
            ///<summary>
            ///Play key
            ///</summary>
            PLAY = 0xFA,
            ///<summary>
            ///Zoom key
            ///</summary>
            ZOOM = 0xFB,
            ///<summary>
            ///Reserved 
            ///</summary>
            NONAME = 0xFC,
            ///<summary>
            ///PA1 key
            ///</summary>
            PA1 = 0xFD,
            ///<summary>
            ///Clear key
            ///</summary>
            OEM_CLEAR = 0xFE
        }
        public enum ScanCodeShort : short
        {
            LBUTTON = 0,
            RBUTTON = 0,
            CANCEL = 70,
            MBUTTON = 0,
            XBUTTON1 = 0,
            XBUTTON2 = 0,
            BACK = 14,
            TAB = 15,
            CLEAR = 76,
            RETURN = 28,
            SHIFT = 42,
            CONTROL = 29,
            MENU = 56,
            PAUSE = 0,
            CAPITAL = 58,
            KANA = 0,
            HANGUL = 0,
            JUNJA = 0,
            FINAL = 0,
            HANJA = 0,
            KANJI = 0,
            ESCAPE = 1,
            CONVERT = 0,
            NONCONVERT = 0,
            ACCEPT = 0,
            MODECHANGE = 0,
            SPACE = 57,
            PRIOR = 73,
            NEXT = 81,
            END = 79,
            HOME = 71,
            LEFT = 75,
            UP = 72,
            RIGHT = 77,
            DOWN = 80,
            SELECT = 0,
            PRINT = 0,
            EXECUTE = 0,
            SNAPSHOT = 84,
            INSERT = 82,
            DELETE = 83,
            HELP = 99,
            KEY_0 = 11,
            KEY_1 = 2,
            KEY_2 = 3,
            KEY_3 = 4,
            KEY_4 = 5,
            KEY_5 = 6,
            KEY_6 = 7,
            KEY_7 = 8,
            KEY_8 = 9,
            KEY_9 = 10,
            KEY_A = 30,
            KEY_B = 48,
            KEY_C = 46,
            KEY_D = 32,
            KEY_E = 18,
            KEY_F = 33,
            KEY_G = 34,
            KEY_H = 35,
            KEY_I = 23,
            KEY_J = 36,
            KEY_K = 37,
            KEY_L = 38,
            KEY_M = 50,
            KEY_N = 49,
            KEY_O = 24,
            KEY_P = 25,
            KEY_Q = 16,
            KEY_R = 19,
            KEY_S = 31,
            KEY_T = 20,
            KEY_U = 22,
            KEY_V = 47,
            KEY_W = 17,
            KEY_X = 45,
            KEY_Y = 21,
            KEY_Z = 44,
            LWIN = 91,
            RWIN = 92,
            APPS = 93,
            SLEEP = 95,
            NUMPAD0 = 82,
            NUMPAD1 = 79,
            NUMPAD2 = 80,
            NUMPAD3 = 81,
            NUMPAD4 = 75,
            NUMPAD5 = 76,
            NUMPAD6 = 77,
            NUMPAD7 = 71,
            NUMPAD8 = 72,
            NUMPAD9 = 73,
            MULTIPLY = 55,
            ADD = 78,
            SEPARATOR = 0,
            SUBTRACT = 74,
            DECIMAL = 83,
            DIVIDE = 53,
            F1 = 59,
            F2 = 60,
            F3 = 61,
            F4 = 62,
            F5 = 63,
            F6 = 64,
            F7 = 65,
            F8 = 66,
            F9 = 67,
            F10 = 68,
            F11 = 87,
            F12 = 88,
            F13 = 100,
            F14 = 101,
            F15 = 102,
            F16 = 103,
            F17 = 104,
            F18 = 105,
            F19 = 106,
            F20 = 107,
            F21 = 108,
            F22 = 109,
            F23 = 110,
            F24 = 118,
            NUMLOCK = 69,
            SCROLL = 70,
            LSHIFT = 42,
            RSHIFT = 54,
            LCONTROL = 29,
            RCONTROL = 29,
            LMENU = 56,
            RMENU = 56,
            BROWSER_BACK = 106,
            BROWSER_FORWARD = 105,
            BROWSER_REFRESH = 103,
            BROWSER_STOP = 104,
            BROWSER_SEARCH = 101,
            BROWSER_FAVORITES = 102,
            BROWSER_HOME = 50,
            VOLUME_MUTE = 32,
            VOLUME_DOWN = 46,
            VOLUME_UP = 48,
            MEDIA_NEXT_TRACK = 25,
            MEDIA_PREV_TRACK = 16,
            MEDIA_STOP = 36,
            MEDIA_PLAY_PAUSE = 34,
            LAUNCH_MAIL = 108,
            LAUNCH_MEDIA_SELECT = 109,
            LAUNCH_APP1 = 107,
            LAUNCH_APP2 = 33,
            OEM_1 = 39,
            OEM_PLUS = 13,
            OEM_COMMA = 51,
            OEM_MINUS = 12,
            OEM_PERIOD = 52,
            OEM_2 = 53,
            OEM_3 = 41,
            OEM_4 = 26,
            OEM_5 = 43,
            OEM_6 = 27,
            OEM_7 = 40,
            OEM_8 = 0,
            OEM_102 = 86,
            PROCESSKEY = 0,
            PACKET = 0,
            ATTN = 0,
            CRSEL = 0,
            EXSEL = 0,
            EREOF = 93,
            PLAY = 0,
            ZOOM = 98,
            NONAME = 0,
            PA1 = 0,
            OEM_CLEAR = 0,
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct HARDWAREINPUT
        {
            internal int uMsg;
            internal short wParamL;
            internal short wParamH;
        }

        /// <summary>
        /// Synthesizes keystrokes, mouse motions, and button clicks.
        /// <para></para>The function returns the number of events that it successfully inserted into the keyboard or mouse input stream. If the function returns zero, the input was already blocked by another thread. To get extended error information, call GetLastError.
        /// <para></para>This function fails when it is blocked by UIPI. Note that neither GetLastError nor the return value will indicate the failure was caused by UIPI blocking.
        /// </summary>
        /// <param name="nInputs">The number of structures in the pInputs array.</param>
        /// <param name="pInputs">An array of INPUT structures. Each structure represents an event to be inserted into the keyboard or mouse input stream.</param>
        /// <param name="cbSize">The size, in bytes, of an INPUT structure. If cbSize is not the size of an INPUT structure, the function fails.</param>
        /// <returns>
        /// The function returns the number of events that it successfully inserted into the keyboard or mouse input stream. If the function returns zero, the input was already blocked by another thread. To get extended error information, call GetLastError.
        /// <para></para>This function fails when it is blocked by UIPI. Note that neither GetLastError nor the return value will indicate the failure was caused by UIPI blocking.
        /// </returns>
        [DllImport("user32")]
        internal static extern uint SendInput(uint nInputs,
           [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs,
           int cbSize);

        /// <summary>
        /// Synthesizes keystrokes, mouse motions, and button clicks.
        /// <para></para>The function returns the number of events that it successfully inserted into the keyboard or mouse input stream. If the function returns zero, the input was already blocked by another thread. To get extended error information, call GetLastError.
        /// <para></para>This function fails when it is blocked by UIPI. Note that neither GetLastError nor the return value will indicate the failure was caused by UIPI blocking.
        /// </summary>
        /// <param name="nInputs">The number of structures in the pInputs array.</param>
        /// <param name="pInputs">An array of INPUT structures. Each structure represents an event to be inserted into the keyboard or mouse input stream.</param>
        /// <param name="cbSize">The size, in bytes, of an INPUT structure. If cbSize is not the size of an INPUT structure, the function fails.</param>
        /// <returns>
        /// The function returns the number of events that it successfully inserted into the keyboard or mouse input stream. If the function returns zero, the input was already blocked by another thread. To get extended error information, call GetLastError.
        /// <para></para>This function fails when it is blocked by UIPI. Note that neither GetLastError nor the return value will indicate the failure was caused by UIPI blocking.
        /// </returns>
        public static uint SendKey(VK_Keys Key)
        {
            int cbSize = INPUT.Size;
            uint nInputs = 1;
            INPUT[] pInputs = new INPUT[1];
            INPUT input = new INPUT();
            pInputs[0] = input;
            input.type = InputType.INPUT_KEYBOARD;
            var KeyInput = input.U._KEYBDINPUT;
            KeyInput.wScan = MapVirtualKey(Key, ConversionRule.MAPVK_VSC_TO_VK);
            KeyInput.time = 0;
            KeyInput.wVk = Key;
            KeyInput.dwExtraInfo = new UIntPtr(0);
            KeyInput.dwFlags = KEYEVENTF.SCANCODE;
            return SendInput(nInputs, pInputs, cbSize);
        }

        [DllImport("user32")] public static extern void SetDebugErrorLevel(int dwLevel);
		[DllImport("user32")] public static extern void SetLastErrorEx(int dwErrCode, int dwType);

        public enum WindowHook
        {
            /// <summary>
            /// CBT : Computer-Based Training
            /// <para></para>The system calls a WH_CBT hook procedure before activating, creating, destroying, minimizing, maximizing, moving, or sizing a window; before completing a system command; before removing a mouse or keyboard event from the system message queue; before setting the input focus; or before synchronizing with the system message queue. The value the hook procedure returns determines whether the system allows or prevents one of these operations.
            /// <para></para>[HookProc] CBTProc
            /// </summary>
            WH_CBT = 5,
            /// <summary>
            /// Installs a hook procedure that monitors messages before the system sends them to the destination window procedure. For more information, see the CallWndProc hook procedure. 
            /// <para></para>[HookProc] CallWndProc
            /// </summary>
            WH_CALLWNDPROC = 4,
            /// <summary>
            /// Installs a hook procedure that monitors messages after they have been processed by the destination window procedure. For more information, see the CallWndRetProc hook procedure. 
            /// <para></para>[HookProc] CallWndRetProc
            /// </summary>
            WH_CALLWNDPROCRET = 12,
            /// <summary>
            /// Installs a hook procedure useful for debugging other hook procedures. For more information, see the DebugProc hook procedure. 
            /// <para></para>[HookProc] DebugProc
            /// </summary>
            WH_DEBUG = 9,
            /// <summary>
            /// Installs a hook procedure that will be called when the application's foreground thread is about to become idle. This hook is useful for performing low priority tasks during idle time. For more information, see the ForegroundIdleProc hook procedure. 
            /// <para></para>[HookProc] ForegroundIdleProc
            /// </summary>
            WH_FOREGROUNDIDLE = 11,
            /// <summary>
            /// Installs a hook procedure that monitors messages posted to a message queue. For more information, see the GetMsgProc hook procedure. 
            /// <para></para>[WPARAM] PM_NOREMOVE = 0x0000
            /// <para></para>The message has not been removed from the queue. (An application called the PeekMessage function, specifying the PM_NOREMOVE flag.)
            /// <para></para>[WPARAM] PM_REMOVE = 0x0001
            /// <para></para>The message has been removed from the queue. (An application called GetMessage, or it called the PeekMessage function, specifying the PM_REMOVE flag.)
            /// <para></para>[LPARAM] A pointer to an MSG structure that contains details about the message.
            /// </summary>
            WH_GETMESSAGE = 3,
            /// <summary>
            /// [HookProc] KeyBoardProc
            /// </summary>
            WH_KEYBOARD = 2,
            /// <summary>
            /// [HookProc] LowLevelKeyBoardProc
            /// </summary>
            WH_KEYBOARD_LL = 13,
            /// <summary>
            /// [HookProc] MouseProc
            /// </summary>
            WH_MOUSE = 7,
            /// <summary>
            /// [HookProc] LowLevelMouseProc
            /// </summary>
            WH_MOUSE_LL = 14,
            /// <summary>
            /// Installs a hook procedure that posts messages previously recorded by a WH_JOURNALRECORD hook procedure. For more information, see the JournalPlaybackProc hook procedure. 
            /// <para></para>[HookProc] JournalPlaybackProc
            /// </summary>
            WH_JOURNALPLAYBACK = 1,
            /// <summary>
            /// Installs a hook procedure that records input messages posted to the system message queue. This hook is useful for recording macros. For more information, see the JournalRecordProc hook procedure. 
            /// <para></para>[HookProc] JournalRecordProc
            /// </summary>
            WH_JOURNALRECORD = 0,
            /// <summary>
            /// more information, see the ShellProc hook procedure. 
            /// <para></para>[HookProc] ShellProc
            /// </summary>
            WH_SHELL = 10,
            /// <summary>
            /// Installs a hook procedure that monitors messages generated as a result of an input event in a dialog box, message box, menu, or scroll bar. The hook procedure monitors these messages for all applications in the same desktop as the calling thread. For more information, see the SysMsgProc hook procedure. 
            /// <para></para>[HookProc] SysMsgProc
            /// </summary>
            WH_SYSMSGFILTER = 6
        }
        
        public enum Extended_Window_Styles : uint
        {
            /// <summary>
            /// The window accepts drag-drop files.
            /// </summary>
            WS_EX_ACCEPTFILES = 0x0000010,
            /// <summary>
            /// Forces a top-level window onto the taskbar when the window is visible. 
            /// </summary>
            WS_EX_APPWINDOW = 0x00040000,
            /// <summary>
            /// The window has a border with a sunken edge.
            /// </summary>
            WS_EX_CLIENTEDGE = 0x00000200,
            /// <summary>
            /// Paints all descendants of a window in bottom-to-top painting order using double-buffering. For more information, see Remarks. This cannot be used if the window has a class style of either CS_OWNDC or CS_CLASSDC. Windows 2000: This style is not supported.
            /// </summary>
            WS_EX_COMPOSITED = 0x02000000,
            /// <summary>
            /// The title bar of the window includes a question mark. When the user clicks the question mark, the cursor changes to a question mark with a pointer. If the user then clicks a child window, the child receives a WM_HELP message. The child window should pass the message to the parent window procedure, which should call the WinHelp function using the HELP_WM_HELP command. The Help application displays a pop-up window that typically contains help for the child window.
            /// <para>WS_EX_CONTEXTHELP cannot be used with the WS_MAXIMIZEBOX or WS_MINIMIZEBOX styles.</para>
            /// </summary>
            WS_EX_CONTEXTHELP = 0x00000400,
            /// <summary>
            /// The window itself contains child windows that should take part in dialog box navigation. If this style is specified, the dialog manager recurses into children of this window when performing navigation operations such as handling the TAB key, an arrow key, or a keyboard mnemonic.
            /// </summary>
            WS_EX_CONTROLPARENT = 0x00010000,
            /// <summary>
            /// The window has a double border; the window can, optionally, be created with a title bar by specifying the WS_CAPTION style in the dwStyle parameter.
            /// </summary>
            WS_EX_DLGMODALFRAME = 0x00000001,
            /// <summary>
            /// The window is a layered window. This style cannot be used if the window has a class style of either CS_OWNDC or CS_CLASSDC.
            /// <para>Windows 8: The WS_EX_LAYERED style is supported for top-level windows and child windows. Previous Windows versions support WS_EX_LAYERED only for top-level windows.</para>
            /// </summary>
            WS_EX_LAYERED = 0x00080000,
            /// <summary>
            /// If the shell language is Hebrew, Arabic, or another language that supports reading order alignment, the horizontal origin of the window is on the right edge. Increasing horizontal values advance to the left. 
            /// </summary>
            WS_EX_LAYOUTRTL = 0x00400000,
            /// <summary>
            /// The window has generic left-aligned properties. This is the default.
            /// </summary>
            WS_EX_LEFT = 0x00000000,
            /// <summary>
            /// If the shell language is Hebrew, Arabic, or another language that supports reading order alignment, the vertical scroll bar (if present) is to the left of the client area. For other languages, the style is ignored.
            /// </summary>
            WS_EX_LEFTSCROLLBAR = 0x00004000,
            /// <summary>
            /// The window text is displayed using left-to-right reading-order properties. This is the default.
            /// </summary>
            WS_EX_LTRREADING = 0x00000000,
            /// <summary>
            /// The window is a MDI (Multi-Document Interface) child window.
            /// </summary>
            WS_EX_MDICHILD = 0x00000040,
            /// <summary>
            /// A top-level window created with this style does not become the foreground window when the user clicks it. The system does not bring this window to the foreground when the user minimizes or closes the foreground window.
            /// The window should not be activated through programmatic access or via keyboard navigation by accessible technology, such as Narrator.
            /// <para></para>To activate the window, use the SetActiveWindow or SetForegroundWindow function.
            /// <para></para>The window does not appear on the taskbar by default. To force the window to appear on the taskbar, use the WS_EX_APPWINDOW style.
            /// </summary>
            WS_EX_NOACTIVATE = 0x08000000,
            /// <summary>
            /// The window does not pass its window layout to its child windows.
            /// </summary>
            WS_EX_NOINHERITLAYOUT = 0x00100000,
            /// <summary>
            /// The child window created with this style does not send the WM_PARENTNOTIFY message to its parent window when it is created or destroyed.
            /// </summary>
            WS_EX_NOPARENTNOTIFY = 0x00000004,
            /// <summary>
            /// The window does not render to a redirection surface. This is for windows that do not have visible content or that use mechanisms other than surfaces to provide their visual.
            /// </summary>
            WS_EX_NOREDIRECTIONBITMAP = 0x00200000,
            /// <summary>
            /// The window has generic "right-aligned" properties. This depends on the window class. This style has an effect only if the shell language is Hebrew, Arabic, or another language that supports reading-order alignment; otherwise, the style is ignored.
            /// <para></para>Using the WS_EX_RIGHT style for static or edit controls has the same effect as using the SS_RIGHT or ES_RIGHT style, respectively.Using this style with button controls has the same effect as using BS_RIGHT and BS_RIGHTBUTTON styles.
            /// </summary>
            WS_EX_RIGHT = 0x00001000,
            /// <summary>
            /// The vertical scroll bar (if present) is to the right of the client area. This is the default.
            /// </summary>
            WS_EX_RIGHTSCROLLBAR = 0x00000000,
            /// <summary>
            /// If the shell language is Hebrew, Arabic, or another language that supports reading-order alignment, the window text is displayed using right-to-left reading-order properties. For other languages, the style is ignored.
            /// </summary>
            WS_EX_RTLREADING = 0x00002000,
            /// <summary>
            /// The window has a three-dimensional border style intended to be used for items that do not accept user input.
            /// </summary>
            WS_EX_STATICEDGE = 0x00020000,
            /// <summary>
            /// The window is intended to be used as a floating toolbar. A tool window has a title bar that is shorter than a normal title bar, and the window title is drawn using a smaller font. A tool window does not appear in the taskbar or in the dialog that appears when the user presses ALT+TAB. If a tool window has a system menu, its icon is not displayed on the title bar. However, you can display the system menu by right-clicking or by typing ALT+SPACE. 
            /// </summary>
            WS_EX_TOOLWINDOW = 0x00000080,
            /// <summary>
            /// The window should be placed above all non-topmost windows and should stay above them, even when the window is deactivated. To add or remove this style, use the SetWindowPos function.
            /// </summary>
            WS_EX_TOPMOST = 0x00000008,
            /// <summary>
            /// The window should not be painted until siblings beneath the window (that were created by the same thread) have been painted. The window appears transparent because the bits of underlying sibling windows have already been painted.
            /// <para></para>To achieve transparency without these restrictions, use the SetWindowRgn function.
            /// </summary>
            WS_EX_TRANSPARENT = 0x00000020,
            /// <summary>
            /// The window has a border with a raised edge.
            /// </summary>
            WS_EX_WINDOWEDGE = 0x00000100
        }

        public enum Window_Styles
        {
            /// <summary>
            /// The window has a thin-line border.
            /// </summary>
            WS_BORDER = 0x00800000,
            /// <summary>
            /// The window has a title bar (includes the WS_BORDER style).
            /// </summary>
            WS_CAPTION = 0x00C00000,
            /// <summary>
            /// The window is a child window. A window with this style cannot have a menu bar. This style cannot be used with the WS_POPUP style.
            /// </summary>
            WS_CHILD = 0x40000000,
            /// <summary>
            /// Same as the WS_CHILD style.
            /// </summary>
            WS_CHILDWINDOW = 0x40000000,
            /// <summary>
            /// Excludes the area occupied by child windows when drawing occurs within the parent window. This style is used when creating the parent window.
            /// </summary>
            WS_CLIPCHILDREN = 0x02000000,
            /// <summary>
            /// Clips child windows relative to each other; that is, when a particular child window receives a WM_PAINT message, the WS_CLIPSIBLINGS style clips all other overlapping child windows out of the region of the child window to be updated. If WS_CLIPSIBLINGS is not specified and child windows overlap, it is possible, when drawing within the client area of a child window, to draw within the client area of a neighboring child window.
            /// </summary>
            WS_CLIPSIBLINGS = 0x04000000,
            /// <summary>
            /// The window is initially disabled. A disabled window cannot receive input from the user. To change this after a window has been created, use the EnableWindow function.
            /// </summary>
            WS_DISABLED = 0x08000000,
            /// <summary>
            /// The window has a border of a style typically used with dialog boxes. A window with this style cannot have a title bar.
            /// </summary>
            WS_DLGFRAME = 0x00400000,
            /// <summary>
            /// The window is the first control of a group of controls. The group consists of this first control and all controls defined after it, up to the next control with the WS_GROUP style. The first control in each group usually has the WS_TABSTOP style so that the user can move from group to group. The user can subsequently change the keyboard focus from one control in the group to the next control in the group by using the direction keys.
            /// <para></para>You can turn this style on and off to change dialog box navigation. To change this style after a window has been created, use the SetWindowLong function.
            /// </summary>
            WS_GROUP = 0x00020000,
            /// <summary>
            /// The window has a horizontal scroll bar.
            /// </summary>
            WS_HSCROLL = 0x00100000,
            /// <summary>
            /// The window is initially maximized.
            /// </summary>
            WS_MAXIMIZE = 0x01000000,
            /// <summary>
            /// The window has a maximize button. Cannot be combined with the WS_EX_CONTEXTHELP style. The WS_SYSMENU style must also be specified. 
            /// </summary>
            WS_MAXIMIZEBOX = 0x00010000,
            /// <summary>
            /// The window is initially minimized. Same as the WS_ICONIC style.
            /// </summary>
            WS_MINIMIZE = 0x20000000,
            /// <summary>
            /// The window has a minimize button. Cannot be combined with the WS_EX_CONTEXTHELP style. The WS_SYSMENU style must also be specified. 
            /// </summary>
            WS_MINIMIZEBOX = 0x00020000,
            /// <summary>
            /// The window is an overlapped window. An overlapped window has a title bar and a border. Same as the WS_TILED style.
            /// </summary>
            WS_OVERLAPPED = 0x00000000,
            /// <summary>
            /// The window has a sizing border. Same as the WS_THICKFRAME style.
            /// </summary>
            WS_SIZEBOX = 0x00040000,
            /// <summary>
            /// The window has a window menu on its title bar. The WS_CAPTION style must also be specified.
            /// </summary>
            WS_SYSMENU = 0x00080000,
            /// <summary>
            /// The window is a control that can receive the keyboard focus when the user presses the TAB key. Pressing the TAB key changes the keyboard focus to the next control with the WS_TABSTOP style.
            /// <para></para>You can turn this style on and off to change dialog box navigation. To change this style after a window has been created, use the SetWindowLong function. For user-created windows and modeless dialogs to work with tab stops, alter the message loop to call the IsDialogMessage function.
            /// </summary>
            WS_TABSTOP = 0x00010000,
            /// <summary>
            /// The window is initially visible.
            /// <para></para>This style can be turned on and off by using the ShowWindow or SetWindowPos function.
            /// </summary>
            WS_VISIBLE = 0x00000000,
            /// <summary>
            /// The window has a vertical scroll bar.
            /// </summary>
            WS_VSCROLL = 0x00200000
        }


        public enum VK_Keys : int
        {
            /// <summary>
            /// Left mouse button
            /// </summary>
            VK_LBUTTON = 0x01,
            /// <summary>
            /// Right mouse button
            /// </summary>
            VK_RBUTTON = 0x02,
            /// <summary>
            /// Control-break processing
            /// </summary>
            VK_CANCEL = 0x03,
            /// <summary>
            /// Middle mouse button (three-button mouse)
            /// </summary>
            VK_MBUTTON = 0x04,
            /// <summary>
            /// X1 mouse button
            /// </summary>
            VK_XBUTTON1 = 0x05,
            /// <summary>
            /// X2 mouse button
            /// </summary>
            VK_XBUTTON2 = 0x06,
            /// <summary>
            /// BACKSPACE key
            /// </summary>
            VK_BACK = 0x08,
            /// <summary>
            /// TAB key
            /// </summary>
            VK_TAB = 0x09,
            /// <summary>
            /// CLEAR key
            /// </summary>
            VK_CLEAR = 0x0C,
            /// <summary>
            /// ENTER key
            /// </summary>
            VK_RETURN = 0x0D,
            VK_SHIFT = 0x10,
            VK_CONTROL = 0x11,
            VK_ALT = 0x12,
            VK_PAUSE = 0x13,
            VK_SPACE = 0x20,
            VK_PAGE_UP = 0x21,
            VK_PAGE_DOWN = 0x22,
            VK_END = 0x23,
            VK_HOME = 0x24,
            VK_LEFT = 0x25,
            VK_UP = 0x26,
            VK_RIGHT = 0x27,
            VK_DOWN = 0x28,
            VK_PRINTSCREENSHOT = 0x2C,
            VK_INSERT = 0x2D,
            VK_DELETE = 0x2E,
            VK_HELP = 0x2F,
            VK_ESCAPE = 0x1B,
            VK_0 = 0x30,
            VK_1 = 0x31,
            VK_2 = 0x32,
            VK_3 = 0x33,
            VK_4 = 0x34,
            VK_5 = 0x35,
            VK_6 = 0x36,
            VK_7 = 0x37,
            VK_8 = 0x38,
            VK_9 = 0x39,
            VK_A = 0x41,
            VK_B = 0x42,
            VK_C = 0x43,
            VK_D = 0x44,
            VK_E = 0x45,
            VK_F = 0x46,
            VK_G = 0x47,
            VK_H = 0x48,
            VK_I = 0x49,
            VK_J = 0x4A,
            VK_K = 0x4B,
            VK_L = 0x4C,
            VK_M = 0x4D,
            VK_N = 0x4E,
            VK_O = 0x4F,
            VK_P = 0x50,
            VK_Q = 0x51,
            VK_R = 0x52,
            VK_S = 0x53,
            VK_T = 0x54,
            VK_U = 0x55,
            VK_V = 0x56,
            VK_W = 0x57,
            VK_X = 0x58,
            VK_Y = 0x59,
            VK_Z = 0x5A,
            VK_LWIN = 0x5B,
            VK_RWIN = 0x5C,
            VK_SLEEP = 0x5F,
            VK_NUMPAD0 = 0x60,
            VK_NUMPAD1 = 0x61,
            VK_NUMPAD2 = 0x62,
            VK_NUMPAD3 = 0x63,
            VK_NUMPAD4 = 0x64,
            VK_NUMPAD5 = 0x65,
            VK_NUMPAD6 = 0x66,
            VK_NUMPAD7 = 0x67,
            VK_NUMPAD8 = 0x68,
            VK_NUMPAD9 = 0x69,
            VK_MULTIPLY = 0x6A,
            VK_ADD = 0x6B,
            VK_SEPARATOR = 0x6C,
            VK_SUBTRACT = 0x6D,
            VK_DECIMAL = 0x6E,
            VK_DIVIDE = 0x6F,
            VK_F1 = 0x70,
            VK_F2 = 0x71,
            VK_F3 = 0x72,
            VK_F4 = 0x73,
            VK_F5 = 0x74,
            VK_F6 = 0x75,
            VK_F7 = 0x76,
            VK_F8 = 0x77,
            VK_F9 = 0x78,
            VK_F10 = 0x79,
            VK_F11 = 0x7A,
            VK_F12 = 0x7B,
            VK_NUMLOCK = 0x90,
            VK_SCROLL = 0x91,
            VK_RSHIFT = 0xA1,
            VK_LSHIFT = 0xA0,
            VK_LCONTROL = 0xA2,
            VK_RCONTROL = 0xA3,
            VK_LALT = 0xA4,
            VK_RALT = 0xA5
        }

        public enum MOUSE_EVENT
        {
            /// <summary>
            /// The dx and dy parameters contain normalized absolute coordinates. If not set, those parameters contain relative data: the change in position since the last reported position. This flag can be set, or not set, regardless of what kind of mouse or mouse-like device, if any, is connected to the system. For further information about relative mouse motion, see the following Remarks section. 
            /// </summary>
            MOUSEEVENTF_ABSOLUTE = 0x8000,
            MOUSEEVENTF_LEFTDOWN = 0x0002,
            MOUSEEVENTF_LEFTUP = 0x0004,
            MOUSEEVENTF_MIDDLEDOWN = 0x0020,
            MOUSEEVENTF_MIDDLEUP = 0x0040,
            MOUSEEVENTF_MOVE = 0x0001,
            MOUSEEVENTF_RIGHTDOWN = 0x0008,
            MOUSEEVENTF_RIGHTUP = 0x0010,
            MOUSEEVENTF_WHEEL = 0x0800,
            MOUSEEVENTF_XDOWN = 0x0080,
            MOUSEEVENTF_XUP = 0x0100,
            MOUSEEVENTF_WHEEL_V = 0x0800,
            MOUSEEVENTF_WHEEL_H = 0x01000
        }
    }
}


