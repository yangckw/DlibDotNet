﻿using System;

namespace DlibDotNet
{

    public abstract class DlibObject : IDisposable
    {

        #region Fields

        #endregion

        #region Constructors

        #endregion

        #region Properties

        public bool IsDisposed
        {
            get;
            private set;
        }

        private IntPtr _NativePtr;

        public IntPtr NativePtr
        {
            get
            {
                return this._NativePtr;
            }
            protected set
            {
                this._NativePtr = value;
            }
        }

        #endregion

        #region Methods

        internal void ThrowIfDisposed()
        {
            if (this.IsDisposed)
                throw new ObjectDisposedException(this.GetType().FullName);
        }

        internal void ThrowIfDisposed(string objectName)
        {
            if (this.IsDisposed)
                throw new ObjectDisposedException(objectName);
        }

        #region Overrides

        protected virtual void DisposeManaged()
        {

        }

        protected virtual void DisposeUnmanaged()
        {

        }

        #endregion

        #endregion

        #region IDisposable メンバ

        /// <summary>
        /// Releases all resources used by this <see cref="DlibObject"/>.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose(true);
        }

        /// <summary>
        /// Releases all resources used by this <see cref="DlibObject"/>.
        /// </summary>
        /// <param name="disposing">Indicate value whether <see cref="IDisposable.Dispose"/> method was called.</param>
        private void Dispose(bool disposing)
        {
            if (this.IsDisposed)
            {
                return;
            }

            this.IsDisposed = true;

            if (disposing)
            {
                this.DisposeManaged();   
            }

            this.DisposeUnmanaged();

            this._NativePtr = IntPtr.Zero;            
        }

        #endregion

    }

}
