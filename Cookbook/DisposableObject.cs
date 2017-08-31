using System;
using System.Diagnostics;

namespace Cookbook
{
    public abstract class DisposableObject : IDisposable
    {
#if DEBUG
        private readonly StackFrame creatingStackTrace = new StackFrame(skipFrames: 1, fNeedFileInfo: false);
#endif

        private bool isDisposed;

        ~DisposableObject()
        {
#if DEBUG
            Debug.Assert(
                condition: false,
                message: $"Object is being finalized: {ObjectName}.{Environment.NewLine}Object creation stack trace:{Environment.NewLine}{creatingStackTrace}"
            );
#endif

            TryDispose(disposing: false);
        }

        public bool IsDisposed => isDisposed;

        protected virtual string ObjectName => GetType().FullName;

        public void Dispose()
        {
            TryDispose(disposing: true);
        }

        protected abstract void Dispose(bool disposing);

        protected void MarkAsDisposed()
        {
            GC.SuppressFinalize(this);

            isDisposed = true;
        }

        private void TryDispose(bool disposing)
        {
            if (!isDisposed)
            {
                Dispose(disposing);
                MarkAsDisposed();
            }
        }
    }
}