using System;

namespace Common
{
    /// <summary>
    /// 抽象Disposable
    /// <para>已實作 IDisposable 相關方法</para>
    /// <para>僅自行將實作DisposeManagedObject()，將需物件的釋放資源方法放置其中即可</para>
    /// <para>有提供釋放非受控物件用的DisposeUnmanagedObject()方法，需自行new 取代即可</para>
    /// </summary>
    public abstract class AbstractDisposable
    {
        private bool disposedValue;

        protected abstract void DisposeManagedObject();
        protected virtual void DisposeUnmanagedObject() { }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    DisposeManagedObject();
                    // TODO: 處置受控狀態 (受控物件)
                }
                DisposeUnmanagedObject();
                // TODO: 釋出非受控資源 (非受控物件) 並覆寫完成項
                // TODO: 將大型欄位設為 Null
                disposedValue = true;
            }
        }

        // // TODO: 僅有當 'Dispose(bool disposing)' 具有會釋出非受控資源的程式碼時，才覆寫完成項
        // ~AbstractController()
        // {
        //     // 請勿變更此程式碼。請將清除程式碼放入 'Dispose(bool disposing)' 方法
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // 請勿變更此程式碼。請將清除程式碼放入 'Dispose(bool disposing)' 方法
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
