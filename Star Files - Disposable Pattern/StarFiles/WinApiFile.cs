﻿using iQuest.StarFiles.WinApi;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace iQuest.StarFiles
{
    internal class WinApiFile : IDisposable
    {
        public const uint INVALID_SET_FILE_POINTER = 0xFFFFFFFF;

        private IntPtr fileHandle;

        public string FileName { get; }

        private bool isDisposed = false;

        public WinApiFile(string fileName)
        {
            if (fileName == null) throw new ArgumentNullException(nameof(fileName));
            if (fileName.Length == 0) throw new ArgumentNullException(nameof(fileName));

            FileName = fileName;
            Open();
        }

        private void Open()
        {
            const DesiredAccess access = DesiredAccess.GENERIC_READ | DesiredAccess.GENERIC_WRITE;

            fileHandle = Kernel32.CreateFile(FileName, access, ShareMode.FILE_SHARE_READ, IntPtr.Zero,
                CreationDisposition.OPEN_ALWAYS, FlagsAndAttributes.NONE, IntPtr.Zero);

            if (fileHandle.ToInt32() == -1)
                ThrowLastWin32Err();
        }

        private static void ThrowLastWin32Err()
        {
            Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
        }

        public string ReadAll()
        {
            MoveFilePointer(0, MoveMethod.FILE_BEGIN);

            using (MemoryStream stream = new MemoryStream())
            {
                byte[] buffer = new byte[10240];

                uint actualReadCount = 0;

                while (true)
                {
                    bool success = Kernel32.ReadFile(fileHandle, buffer, (uint)buffer.Length, ref actualReadCount, IntPtr.Zero);

                    if (!success)
                        ThrowLastWin32Err();

                    if (actualReadCount == 0)
                        break;

                    stream.Write(buffer, 0, (int)actualReadCount);
                }

                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        public void Write(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            uint actualWriteCount = 0;

            bool success = Kernel32.WriteFile(fileHandle, bytes, (uint)bytes.Length, ref actualWriteCount, IntPtr.Zero);
            if (!success)
                ThrowLastWin32Err();
        }

        private void MoveFilePointer(int distance, MoveMethod moveMethod)
        {
            if (fileHandle == IntPtr.Zero)
                return;

            uint result = Kernel32.SetFilePointer(fileHandle, distance, IntPtr.Zero, moveMethod);
            if (result == INVALID_SET_FILE_POINTER)
                ThrowLastWin32Err();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool isDisposing)
        {
            if (!this.isDisposed)
            {
                if (isDisposing)
                {
                    CloseHandle(fileHandle);
                    fileHandle = IntPtr.Zero;
                }

                isDisposed = true;
            }
        }
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);
    }
}